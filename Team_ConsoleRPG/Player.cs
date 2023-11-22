using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Remoting.Activation;
using Team_ConsoleRPG;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    public enum Jop
    {
        프로그래머,
        게임디렉터,
        QA테스터,
        게임프로듀서,
        스토리라이터
    }

    public class Player : Character      //플레이어 캐릭터 클래스
    {
        //캐릭터 클래스 필드
        public Jop Job { get; private set; }
        public int Level { get; set; }      //지속적으로 변경되어 프로퍼티 - get, set
        public int MP { get; set; }         //플레이어 마나
        public int exp = 0;                 //플레이어 경험치 - 일정수치 이상 획득시 레벨업
        public int ticket = 0;              //던전 진행시 얻는 아이템

        public List<Item> equipItems;
        public List<Item> inventory { get; private set; }

        public List<Quest> questList { get; private set; }

        public void PlayerDataSetting(string name, Jop job, int level, int health, int mp, int attack, int defend, int money)
        {
            Name = name;
            Job = job;
            Level = level;
            Health = health;
            MP = mp;
            Attack = attack;
            Defend = defend;
            Money = money;

            equipItems = new List<Item>((int)ItemType.MaxEquipItem);
            for (int i = 0; i < (int)ItemType.MaxEquipItem; ++i) 
            {
                equipItems.Add(null);
            }

            inventory = new List<Item>();
            questList = new List<Quest> ();
        }

        public override void TakeDamage(int damage)      //던전 진행시 몬스터에게 데미지를 받는 메소드
        {
           
            if (Defend < damage) 
            {
                Health -= (damage - Defend);     //몬스터 공격력 - 플레이어 방어력 만큼 체력 감소
                if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
                else Console.WriteLine($"{Name}이(가) {damage - Defend}의 데미지를 받았습니다. 남은 체력: {Health}");
            }
            else if (Defend == damage || Defend > damage)
            {
                Health -= 0;
                Console.WriteLine("방어력이 데미지보다 높아 데미지가 들어오지 않았습니다.");
            }            
        }

        public int GetBonusAttack()      //현재 장착한 아이템 공격력 합 만큼 반환 
        {
            int sum = 0;
            for (int i = 0; i < equipItems.Count; i++)
            {
                if (equipItems[i] != null)
                    sum += equipItems[i].Attack;
            }
            return sum;
        }

        public int GetBonusDefend()      //방어력 합산 반환
        {
            int sum = 0;
            for (int i = 0; i < equipItems.Count; i++)
            {
                if (equipItems[i] != null)
                    sum += equipItems[i].Defend;
            }
            return sum;
        }

        public int GetBonusHealth()      //체력 합산 반환
        {
            int sum = 0;
            for (int i = 0; i < equipItems.Count; i++)
            {
                if (equipItems[i] != null)
                    sum += equipItems[i].Health;
            }
            return sum;
        }

        public void BuyItem(Item item) 
        {
            if (DataManager.Items[item.ID].Have == true)      //아이템을 이미 가지고 있는 경우 아이템샵 씬 다시 호출
            {
                Console.WriteLine("이미 가지고 있는 물건입니다.");
                Console.ReadKey();
                GameManager.DisplayShop();
            } 
            
            else if (Player.GetInst.Money < item.Price)      //아이템 가격보다 보유 금액이 부족한 경우 아이템샵 씬 다시 호출
            {
                Console.WriteLine("잔액이 부족합니다.");
                Console.ReadKey();
                GameManager.DisplayShop();
            } 
            
            else 
            {
                Player.GetInst.Money -= item.Price;          //아이템 금액만큼 보유금액 차감 후 아이템 보유 bool값을 true로 전환
                Player.GetInst.inventory.Add(item);
                item.Have = true;
                Console.WriteLine($"{item.Price} 을 지불하고 {item.Name} 을 구입하였습니다.");
                Console.WriteLine("Enter를 누르면 상점으로 돌아갑니다.");
                Console.ReadKey();
                GameManager.DisplayShop();
            }
        }

        public void EquipItem(Item item)       //아이템 장착 메소드
        {
            if(item.Type <= ItemType.MaxEquipItem) 
            {
                Console.WriteLine("장착아이템이 아니에요.");
            }

            if (item.Have != true) 
            {
                Console.WriteLine("가지고 있는 아이템을 선택해주세요.");
            } 
            else 
            {
                if (item.Equip)       //이미 장착중인 아이템의 경우 출력
                {
                    Console.WriteLine("이미 장착중인 아이템입니다.");
                }

                else 
                {
                    if(equipItems[(int)item.Type] == null) 
                    {
                        equipItems[(int)item.Type] = item;
                        item.Equip = true;                       //선택한 아이템을 장착하며 아이템 효과를 캐릭터 속성에 추가 합산하여 적용
                        Player.GetInst.Attack += item.Attack;
                        Player.GetInst.Defend += item.Defend;
                        Player.GetInst.Health += item.Health;
                    }

                    else 
                    {
                        Player.GetInst.Attack -= equipItems[(int)item.Type].Attack;
                        Player.GetInst.Defend -= equipItems[(int)item.Type].Defend;
                        Player.GetInst.Health -= equipItems[(int)item.Type].Health;
                        equipItems[(int)item.Type].Equip = false;

                        equipItems[(int)item.Type] = item;
                        item.Equip = true;                       //선택한 아이템을 장착하며 아이템 효과를 캐릭터 속성에 추가 합산하여 적용
                        Player.GetInst.Attack += item.Attack;
                        Player.GetInst.Defend += item.Defend;
                        Player.GetInst.Health += item.Health;
                    }
                }
            }
        }

        public static void SellItem(Item item)        //아이템 판매 메소드
        {
            List<Item> items = DataManager.Items;
            if (items[item.ID].Have == true) 
            {
                int sellmoney;
                sellmoney = items[item.ID].Price / 10 * 8;      //판매금액을 아이템 가격의 80%로 계산하여 저장
                Player.GetInst.Money += sellmoney;           //판매 금액만큼 플레이어 보유 금액 추가합산
                items[item.ID].Have = false;
                if (items[item.ID].Equip)
                    items[item.ID].Equip = false;       //아이템을 장착하고 있었다면 해제하고 아이템 소지 bool값을 false로 전환
                Player.GetInst.inventory.Remove(item);
            }
        }

        public void DropGetItem(Item item) // 아이템 드랍 흭득 메소드
        {
            if (item.Have == true)
            {
                Player.instance.Money += item.Price;
            }
            else
            {
                Player.GetInst.inventory.Add(item);
                item.Have = true;
            }
        }

        public void Save() 
        {
            DataManager.SaveData(this, DataManager.PLAYER);
        }

        public bool Load() 
        {
            string fullPath = DataManager.GetProjectPath() + DataManager.PLAYER + ".json";

            if (File.Exists(fullPath)) 
            {
                instance = DataManager.LoadData<Player>(DataManager.PLAYER);
                SetItemData();
                return true;
            }

            return false;
        }

        private void SetItemData() 
        {
            for(int i = 0; i < instance.equipItems.Count; i++) 
            {
                if (instance.equipItems[i] != null) 
                {
                    DataManager.Items[instance.equipItems[i].ID].Equip = true;
                    DataManager.Items[instance.equipItems[i].ID].Have = true;
                }
            }

            for (int i = 0; i < instance.inventory.Count; i++) {
                if (instance.inventory[i] != null) {
                    DataManager.Items[instance.inventory[i].ID].Have = true;
                }
            }
        }
        public void GainExperience(int amount)
        {
            exp += amount;

            if (exp >= Level * 15)
            {
                Levelup();
            }
        }



        private void Levelup()
        {
            Level++;
            exp = 0;
            Console.WriteLine($"{Name}이(가) {Level} 레벨로 올라갔습니다");
        }

        public void UpdateQuest(List<Monster> mon) {
            for(int i = 0; i < questList.Count; ++i) {
                questList[i].UpdateQuest( mon );
            }
        }

        private static Player instance;

        private Player() 
        {
            equipItems = new List<Item>();
            inventory = new List<Item>();
        }

        public static Player GetInst 
        {
            get {
                if (instance == null) 
                {
                    instance = new Player();
                }
                return instance;
            }
        }
    }

}
