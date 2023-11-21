using ConsoleRPG;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleRPG 
{
    public static class DataManager 
    {
        public static readonly string ITEM = "ItemInfos";
        public static readonly string MONSTER = "MonsterInfo";
        public static readonly string PLAYER = "PlayerInfo";

        public static List<Item> Items { get; private set; }
        public static List<Monster> Company { get; private set; }
        public static List<Monster> monsters { get; private set; }

        public static string GetProjectPath() 
        {
            string fullPath = Directory.GetCurrentDirectory();
            string[] pathSegments = fullPath.Split(new[] { "bin" }, StringSplitOptions.None);
            return pathSegments[0];
        }

        public static void SaveData(object obj, string fileName) 
        {
            string jsonSting = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(GetProjectPath() + fileName + ".json", jsonSting);
        }

        public static T LoadData<T>(string fileName) 
        {
            string fullPath = GetProjectPath() + fileName + ".json";

            if (!File.Exists(fullPath))
                throw new InvalidOperationException("파일이 존재하지 않음");

            string jsonData = File.ReadAllText(fullPath);
            T loadData = JsonConvert.DeserializeObject<T>(jsonData);
            return loadData;
        }

        public static List<Item> GetItemsByType(ItemType type) 
        {
            List<Item> itemsByType = new List<Item>();
            for(int i = 0; i < Items.Count; i++) 
            {
                if (Items[i].Type == type)
                    itemsByType.Add(Items[i]);
            }
            return itemsByType;
        }

        public static void DataSetting() 
        {
            //ItemSetting();
            MonsterSetting();

            //SaveData(Items, ITEM);
            //SaveData(Companys, MONSTER);

            Items = LoadData<List<Item>>(ITEM);
            //Company = LoadData<List<Monster>>(MONSTER);
        }

        public static void ItemSetting() 
        {
            Items = new List<Item>();

            Items.Add(new Item(0, " ", ItemType.Max, 1, 0, 1, 0, false, false));
            Items.Add(new Item(1, "물려받은 키보드", ItemType.Weapon, 20, 0, 0, 10, false, false));
            Items.Add(new Item(2, "다이소 키보드", ItemType.Weapon, 40, 0, 0, 50, false, false));
            Items.Add(new Item(3, "보급형 기계식 키보드", ItemType.Weapon, 60, 0, 0, 250, false, false));
            Items.Add(new Item(4, "전문 브랜드 기계식 키보드", ItemType.Weapon, 80, 0, 0, 1250, false, false));
            Items.Add(new Item(5, "장인의 맞춤제작 키보드", ItemType.Weapon, 100, 0, 0, 6250, false, false));
            Items.Add(new Item(6, "다이소 마우스", ItemType.SubWeapon, 10, 5, 0, 10, false, false));
            Items.Add(new Item(7, "무선 마우스", ItemType.SubWeapon, 20, 10, 0, 50, false, false));
            Items.Add(new Item(8, "무선 버티컬 마우스", ItemType.SubWeapon, 30, 15, 0, 250, false, false));
            Items.Add(new Item(9, "전문 브랜드 마우스", ItemType.SubWeapon, 40, 20, 0, 1250, false, false));
            Items.Add(new Item(10, "장인의 맞춤제작 마우스", ItemType.SubWeapon, 50, 25, 0, 6250, false, false));
            Items.Add(new Item(11, "후드티&츄리닝 세트", ItemType.Armor, 0, 0, 100, 10, false, false));
            Items.Add(new Item(12, "장인 맞춤제작 정장", ItemType.Armor, 0, 0, 200, 50, false, false));
            Items.Add(new Item(13, "물려받은 정장", ItemType.Armor, 0, 0, 300, 250, false, false));
            Items.Add(new Item(14, "깔끔한 댄디룩 스타일", ItemType.Armor, 0, 0, 400, 1250, false, false));
            Items.Add(new Item(15, "아이언맨 슈트", ItemType.Armor, 0, 0, 500, 6250, false, false));
            Items.Add(new Item(16, "귀마개", ItemType.Shield, 0, 8, 0, 10, false, false));
            Items.Add(new Item(17, "유선 이어폰", ItemType.Shield, 0, 16, 0, 50, false, false));
            Items.Add(new Item(18, "저가형 무선 이어폰", ItemType.Shield, 0, 24, 0, 250, false, false));
            Items.Add(new Item(19, "고급 브랜드 무선 이어폰", ItemType.Shield, 0, 32, 0, 1250, false, false));
            Items.Add(new Item(20, "최상급 브랜드 고오급 해드셋 ", ItemType.Shield, 0, 40, 0, 6250, false, false));
            Items.Add(new Item(21, "손목보호대", ItemType.Accessory, 0, 2, 50, 10, false, false));
            Items.Add(new Item(22, "등받이 쿠션", ItemType.Accessory, 0, 4, 100, 50, false, false));
            Items.Add(new Item(23, "웹캠", ItemType.Accessory, 0, 6, 150, 250, false, false));
            Items.Add(new Item(24, "더블 모니터", ItemType.Accessory, 0, 8, 200, 1250, false, false));
            Items.Add(new Item(25, "전문 브랜드 맞춤 의자", ItemType.Weapon, 0, 10, 250, 6250, false, false));
            Items.Add(new Item(26, "전설의 기운", ItemType.Energy, 10, 10, 10, 0, false, false));
            Items.Add(new Item(27, "힘의 기운", ItemType.Energy, 10, 0, 0, 0, false, false));
            Items.Add(new Item(28, "방어의 기운", ItemType.Energy, 0, 10, 0, 0, false, false));
            Items.Add(new Item(29, "체력의 기운", ItemType.Energy, 0, 0, 10, 0, false, false));
            Items.Add(new Item(30, "나태의 기운", ItemType.Energy, -10, -10, -10, 0, false, false));
        }

        public static void MonsterSetting() 
        {
            Company = new List<Monster>();
            monsters = new List<Monster>();

            Company.Add(new Monster(1, "쿠키런[데브시스터즈]", 100, 10, 5, 10));
            Company.Add(new Monster(1, "DJMAX[네오위즈]", 100, 10, 5, 10));
            Company.Add(new Monster(1, "검은사막[펄어비스]", 100, 10, 5, 10));
            Company.Add(new Monster(1, "라그라로크온라인[그라비티]", 100, 10, 5, 10));
            Company.Add(new Monster(1, "미르[위메이드]", 100, 10, 5, 10));
            Company.Add(new Monster(2, "서머너즈워[컴투스]", 175, 25, 10, 40));
            Company.Add(new Monster(2, "몬스터헌터[캡콤]", 175, 25, 10, 40));
            Company.Add(new Monster(2, "북두의 권[겅호온라인]", 175, 25, 10, 40));
            Company.Add(new Monster(2, "엘리온[카카오게임즈]", 175, 25, 10, 40));
            Company.Add(new Monster(2, "로스트아크[스마일게이트]", 175, 25, 10, 40));
            Company.Add(new Monster(3, "배틀그라운드[크래프톤]", 250, 40, 15, 150));
            Company.Add(new Monster(3, "세븐나이츠[넷마블]", 250, 40, 15, 150));
            Company.Add(new Monster(3, "리니지[엔씨소프트]", 250, 40, 15, 150));
            Company.Add(new Monster(3, "로블록스[로블록스]", 250, 40, 15, 150));
            Company.Add(new Monster(3, "어쎄신크리드[유비소프트]", 250, 40, 15, 150));
            Company.Add(new Monster(4, "메탈기어솔리드[코나미]", 325, 55, 20, 500));
            Company.Add(new Monster(4, "메이플스토리[넥슨]", 325, 55, 20, 500));
            Company.Add(new Monster(4, "FootballManager[세가사미]", 325, 55, 20, 500));
            Company.Add(new Monster(4, "카운터스트라이크[엠브레이서]", 325, 55, 20, 500));
            Company.Add(new Monster(4, "파이널판타지[스퀘어에닉스]", 325, 55, 20, 500));
            Company.Add(new Monster(5, "GTA[테이크투인터랙티브]", 400, 70, 25, 1250));
            Company.Add(new Monster(5, "우마무스메[사이버에이전트]", 400, 70, 25, 1250));
            Company.Add(new Monster(5, "FIFA[일렉트로닉 아츠]", 400, 70, 25, 1250));
            Company.Add(new Monster(5, "Diablo[블리자드] - 9.79조", 400, 70, 25, 1250));
            Company.Add(new Monster(5, "엘든링[반다이남코]", 400, 70, 25, 1250));
            Company.Add(new Monster(6, "포켓몬[닌텐도]", 475, 85, 30, 3000));
            Company.Add(new Monster(6, "제5 인격[넷이즈]", 475, 85, 30, 3000));
            Company.Add(new Monster(6, "갓 오브 워[소니]", 475, 85, 30, 3000));
            Company.Add(new Monster(6, "리그오브레전드 (라이엇)", 475, 85, 30, 3000));
            Company.Add(new Monster(6, "Minecraft(마이크로소프트)", 475, 85, 30, 3000));
            Company.Add(new Monster(7, "BOSS : 스파르타코딩클럽", 1500, 250, 100, 231030));
            
        }
    }
}
