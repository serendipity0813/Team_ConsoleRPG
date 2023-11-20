using ConsoleRPG;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Team_ConsoleRPG 
{
    public static class DataManager 
    {
        public static readonly string ITEM = "ItemInfos";
        public static readonly string MONSTER = "MonsterInfo";
        public static readonly string PLAYER = "PlayerInfo";

        public static List<Item> Items { get; private set; }
        public static List<Monster> Companys { get; private set; }

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
            Companys = LoadData<List<Monster>>(MONSTER);
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
            Companys = new List<Monster>();

            Companys.Add(new Monster(" ", 1, 1, 1, 1));
            Companys.Add(new Monster("아르바이트", 100, 10, 5, 10));
            Companys.Add(new Monster("중소기업", 250, 40, 15, 50));
            Companys.Add(new Monster("중견기업", 400, 70, 25, 250));
            Companys.Add(new Monster("대기업", 550, 100, 35, 1250));
            Companys.Add(new Monster("글로벌기업", 700, 130, 45, 6250));
            Companys.Add(new Monster("스파르타코딩클럽", 1000, 180, 60, 50000));
        }
    }
}
