using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_ConsoleRPG
{
    public interface Use
    {
        int Number { get; }
        string Name { get; }
        int Have { get; set; }
        int Price { get; }
    }

    public class UseItem : Use
    {
        public int Number { get; } // 이름
        public string Name { get; } // 이름

        public int Have { get; set; }
        public int Price { get; } // 가격

        public static UseItem[] useitems; //인벤토리
        public static int ItemCnt = 0; // 수량 표현

        public UseItem(int number, string name, int price, int have)
        {
            Number = number;
            Name = name;
            Price = price;
            Have = have;
        }

        public static void BuyItem(int input) //구매 메소드
        {
            while (true)
            {
                if (input > 6)
                {
                    Console.WriteLine("잘못된 값을 입력하였습니다.");
                }
                else if (input == 0)
                {
                    Console.WriteLine("");
                    GameManager.DisplayShop();
                }
                else
                {
                    Console.WriteLine($"{useitems[input - 1].Price} 을 지불하고 {useitems[input - 1].Name}을 구매하였습니다.");
                    GameManager.DisplayShop();
                }

            }
        }
        public void PrintItemDate() // 사용했을시 창
        {
            Console.Write($"이름 : {Name}");
            Console.Write(" | ");
            Console.Write($"가격 : {Price} ");
            Console.Write($"수량 : {Have}");
            Console.WriteLine();
        }
        public static void AddUseItem(UseItem useitem) // 배열 추가 메소드
        {
            if (UseItem.ItemCnt == useitems.Length) return;
            useitems[UseItem.ItemCnt] = useitem;
            UseItem.ItemCnt++;
        }

        public static void UseItemSet()
        {
            UseItem.useitems = new UseItem[10];

            UseItem.AddUseItem(new UseItem(0, "", 0,0 ));
            UseItem.AddUseItem(new UseItem(1, "우리집삼다수", 100,0));
            UseItem.AddUseItem(new UseItem(2, "콜드여섯", 100,0));
            UseItem.AddUseItem(new UseItem(3, "괴물체력", 100,0));
            UseItem.AddUseItem(new UseItem(4, "르탄콜라", 100,0));
            UseItem.AddUseItem(new UseItem(5, "이세계 HP포션", 1000,0));
            UseItem.AddUseItem(new UseItem(6, "한효승 매니저님이 화나서 던진 커피", 1000, 0));
        }

        public static void BuyuseItem(int input)
        {
            if (useitems[input].Have >= 99)
            {
                Console.WriteLine("최대 수량을 가지고 있습니다.");
                Console.ReadKey();
                GameManager.DisplayShop();
            }
            else if (Player.player.Money < useitems[input].Price)      //아이템 가격보다 보유 금액이 부족한 경우 아이템샵 씬 다시 호출
            {
                Console.WriteLine("잔액이 부족합니다.");
                Console.ReadKey();
                GameManager.DisplayShop();
            }
            else
            {
                Player.player.Money -= useitems[input].Price;          //아이템 금액만큼 보유금액 차감 후 아이템 보유 bool값을 true로 전환
                useitems[input].Have += 1;
                Console.WriteLine($"{useitems[input].Price} 을 지불하고 {useitems[input].Name} 을 구입하였습니다.");
                Console.WriteLine("Enter를 누르면 상점으로 돌아갑니다.");
                Console.ReadKey();
                GameManager.DisplayShop();
            }
        }


    }
}
