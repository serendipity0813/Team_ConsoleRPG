using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using Team_ConsoleRPG;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    public enum ItemType 
    {
        Weapon = 0,
        SubWeapon,
        Armor,
        Shield,
        Accessory,
        Energy,
        activeitem,
        ingredient,
        MaxEquipItem,
        Max
    }

    public interface IItem      //아이템 인터페이스
    {
        int ID { get; }
        bool Equip { get; set; }        //장착여부 메소드로 수정 가능
        bool Have { get; set; }         //아이템 구매, 판매 메소드로 수정 가능
        string Name { get; }
        ItemType Type { get; }
        int Attack { get; }
        int Defend { get; }
        int Health { get; }
        int Price { get; }

    }
    public class Item : IItem {
        public int ID { get; }
        public bool Equip { get; set; }     //장착여부 메소드로 수정 가능
        public bool Have { get; set; }      //아이템 구매, 판매 메소드로 수정 가능
        public string Name { get; private set; }
        public ItemType Type { get; }
        public int Attack { get; }
        public int Defend { get; }
        public int Health { get; }
        public int Price { get; }

        //public static Item[] items;     //아이템 클래스 배열 선언
        public static int ItemCnt = 0;      //아이템 개수 카운터


        public Item(int id, string name, ItemType type, int attack, int defend, int health, int price, bool have = false, bool equip = false) {
            //아이템 클래스 속성
            ID = id;
            Name = name;
            Type = type;
            Attack = attack;
            Defend = defend;
            Health = health;
            Price = price;
            Equip = equip;
            Have = have;
        }
       
        public void PrintItemData()     //아이템 데이터 출력 함수 
        {
            int maxNameLength = 30; //글자수제한
            int maxPrice = 15;
            if (Type != ItemType.activeitem)
            {
                if (Equip)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;        //아이템 장착시 출력
                    Console.Write("[E]");
                    Console.ResetColor();
                }
                else if (Have)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;      //아이템 보유시 출력
                    Console.Write("[I]");
                    Console.ResetColor();
                }
                else
                    Console.Write("   ");                   //아이템 이름, 가격 등 출력 후 아이템 효과중 0이 아닌 효과 출력
            }




            int padLen = maxNameLength - Encoding.Default.GetBytes(Name).Length;
            string itemName = Name + new string(' ', padLen);
            Console.Write($"이름|| {itemName}");
            Console.Write(" || ");
            string priceTex = $"가격 : {Price}";
            padLen = maxPrice - Encoding.Default.GetBytes(priceTex).Length;
            priceTex = priceTex + new string(' ', padLen);
            if (Price != 0) Console.Write(priceTex);
            Console.Write(" || ");
            if (Attack != 0) Console.Write($"Atk {(Attack >= 0 ? "+" : "")}{Attack} ");
            if (Defend != 0) Console.Write($"Def {(Defend >= 0 ? "+" : "")}{Defend} ");
            if (Health != 0) Console.Write($"Hp {(Health >= 0 ? "+" : "")}{Health}");
            if (Type == ItemType.activeitem) Console.Write($"수량 : {(ItemCnt >= 0 ? "+" : "")}{ItemCnt}");
            Console.WriteLine();
            Console.WriteLine("====================================================================================");

        }

        
        public void UseactiveItem() //아이템 사용 구현 임시구현
        {
            if (Type == ItemType.activeitem)
            {
                Console.WriteLine($"{Name}을 사용하였습니다.");
                Console.WriteLine($"{Health} 만큼 회복하였습니다.");
                Player.GetInst.Health += Health; //유저 피 회복
            }
            else
            {
                Console.WriteLine("그아이템은 사용할수 없어");
            }
        }
        
        
    }
}

