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
            //MonsterSetting();

            //SaveData(Items, ITEM);
            //SaveData(Companys, MONSTER);

            Items = LoadData<List<Item>>(ITEM);
            Company = LoadData<List<Monster>>(MONSTER);
        }

        public static void ItemSetting() 
        {
            Items = new List<Item>();

            Items.Add(new Item(0, " ", ItemType.Max, 1, 1, 1, 1, false, false));
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

            Company.Add(new Monster(1, "0", 1, 1, 1, 1));
            Company.Add(new Monster(1, "1", 100, 10, 5, 10));
            Company.Add(new Monster(1, "2", 1, 1, 1, 1));
            Company.Add(new Monster(1, "3", 1, 1, 1, 1));
            Company.Add(new Monster(1, "4", 1, 1, 1, 1));
            Company.Add(new Monster(1, "5", 1, 1, 1, 1));
            Company.Add(new Monster(1, "6", 1, 1, 1, 1));
            Company.Add(new Monster(1, "7", 1, 1, 1, 1));
            Company.Add(new Monster(1, "8", 1, 1, 1, 1));
            Company.Add(new Monster(1, "9", 1, 1, 1, 1));
            Company.Add(new Monster(2, "10", 1, 1, 1, 1));
            Company.Add(new Monster(2, "11", 250, 40, 15, 50));
            Company.Add(new Monster(2,"12", 1, 1, 1, 1));
            Company.Add(new Monster(2,"13", 1, 1, 1, 1));
            Company.Add(new Monster(2,"14", 1, 1, 1, 1));
            Company.Add(new Monster(2,"15", 1, 1, 1, 1));
            Company.Add(new Monster(2,"16", 1, 1, 1, 1));
            Company.Add(new Monster(2,"17", 1, 1, 1, 1));
            Company.Add(new Monster(2,"18", 1, 1, 1, 1));
            Company.Add(new Monster(2,"19", 1, 1, 1, 1));
            Company.Add(new Monster(3,"20", 1, 1, 1, 1));
            Company.Add(new Monster(3,"21", 400, 70, 25, 250));
            Company.Add(new Monster(3,"22", 1, 1, 1, 1));
            Company.Add(new Monster(3,"23", 1, 1, 1, 1));
            Company.Add(new Monster(3,"24", 1, 1, 1, 1));
            Company.Add(new Monster(3,"25", 1, 1, 1, 1));
            Company.Add(new Monster(3,"26", 1, 1, 1, 1));
            Company.Add(new Monster(3,"27", 1, 1, 1, 1));
            Company.Add(new Monster(3,"28", 1, 1, 1, 1));
            Company.Add(new Monster(3,"29", 1, 1, 1, 1));
            Company.Add(new Monster(4,"30", 1, 1, 1, 1));
            Company.Add(new Monster(4,"31", 550, 100, 35, 1250));
            Company.Add(new Monster(4,"32", 1, 1, 1, 1));
            Company.Add(new Monster(4,"33", 1, 1, 1, 1));
            Company.Add(new Monster(4,"34", 1, 1, 1, 1));
            Company.Add(new Monster(4,"35", 1, 1, 1, 1));
            Company.Add(new Monster(4,"36", 1, 1, 1, 1));
            Company.Add(new Monster(4,"37", 1, 1, 1, 1));
            Company.Add(new Monster(4,"38", 1, 1, 1, 1));
            Company.Add(new Monster(4,"39", 1, 1, 1, 1));
            Company.Add(new Monster(5,"40", 1, 1, 1, 1));
            Company.Add(new Monster(5,"41", 700, 130, 45, 6250));
            Company.Add(new Monster(5,"42", 1, 1, 1, 1));
            Company.Add(new Monster(5,"43", 1, 1, 1, 1));
            Company.Add(new Monster(5,"44", 1, 1, 1, 1));
            Company.Add(new Monster(5,"45", 1, 1, 1, 1));
            Company.Add(new Monster(5,"46", 1, 1, 1, 1));
            Company.Add(new Monster(5,"47", 1, 1, 1, 1));
            Company.Add(new Monster(5,"48", 1, 1, 1, 1));
            Company.Add(new Monster(5,"49", 1, 1, 1, 1));
            Company.Add(new Monster(6,"50", 1000, 180, 60, 50000));
        }
    }
}
