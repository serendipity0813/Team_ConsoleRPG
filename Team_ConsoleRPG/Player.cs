using System;
using System.Runtime.Remoting.Activation;
using Team_ConsoleRPG;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    public enum Jop {
        student,
        junior,
        senior,
        leader,
        Max
    }

    public class Player : Character      //플레이어 캐릭터 클래스
    {
        //캐릭터 클래스 필드
        public Jop Job { get; private set; }
        public int Level { get; set; }      //지속적으로 변경되어 프로퍼티 - get, set
        public int exp = 0;                 //플레이어 경험치 - 일정수치 이상 획득시 레벨업
        public int ticket = 0;              //던전 진행시 얻는 아이템

        public void PlayerDataSetting(string name, Jop job, int level, int health, int attack, int defend, int money)
        {
            Name = name;
            Job = job;
            Level = level;
            Health = health;
            Attack = attack;
            Defend = defend;
            Money = money;
        }

        public override void TakeDamage(int damage)      //던전 진행시 몬스터에게 데미지를 받는 메소드
        {
            Health -= (damage - Defend);     //몬스터 공격력 - 플레이어 방어력 만큼 체력 감소
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage - Defend}의 데미지를 받았습니다. 남은 체력: {Health}");
        }

        public int GetBonusAttack()      //현재 장착한 아이템 공격력 합 만큼 반환 
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (Item.items[i].Equip)
                    sum += Item.items[i].Attack;
            }
            return sum;
        }

        public int GetBonusDefend()      //방어력 합산 반환
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (Item.items[i].Equip)
                    sum += Item.items[i].Defend;
            }
            return sum;
        }

        public int GetBonusHealth()      //체력 합산 반환
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (Item.items[i].Equip)
                    sum += Item.items[i].Health;
            }

            return sum;
        }

        private static Player instance;

        private Player() { }

        public static Player GetInst {
            get {
                if (instance == null) {
                    instance = new Player();
                }
                return instance;
            }
        }
    }

}
