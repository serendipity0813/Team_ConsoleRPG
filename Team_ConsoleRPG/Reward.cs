using System;
using System.Collections.Generic;
using System.IO;
using Team_ConsoleRPG;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    public  class Reward
    {
        public static void ShowReward(bool win)
        {
            Console.Clear();

            Console.WriteLine();
            Console.Write(" [전투결과] : ");


            if (win == true)
            {
                int exp = 0;
                int money = 0;

                for (int i = 0; i < DataManager.monsters.Count; i++)
                {
                    exp += DataManager.monsters[i].Level;
                    money += DataManager.monsters[i].Money;
                }

                Player.GetInst.exp += exp;
                Player.GetInst.Money += money;

                Console.WriteLine("Player Win!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"{Player.GetInst.Name}가 전투에서 승리하였습니다!");
                Console.WriteLine();
                Console.WriteLine($"{exp}만큼 경험치를 획득합니다.");
                Console.WriteLine($"{money}만큼 돈을 획득합니다.");
                Console.WriteLine();

                if(Player.GetInst.exp > Player.GetInst.Level * Player.GetInst.Level * 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("LEVEL UP! - 공격력, 방어력, 체력이 일정수치 상승합니다.");
                    Player.GetInst.exp -= Player.GetInst.Level * 5;      //경험치를 줄이고 레벨이 상승하며 모든 스텟 상승
                    Player.GetInst.Level++;
                    Player.GetInst.Attack += 5;
                    Player.GetInst.Defend += 5;
                    Player.GetInst.Health += 50;
                }


                for (int i = 0; i < DataManager.monsters.Count; i++)
                {
                    DataManager.monsters.RemoveAt(i);
                }

                Console.WriteLine("Enter키를 누르면 집으로 돌아갑니다.");
                Console.ReadKey();
                GameManager.DisplayHome();


            }

            else if (win == false)
            {

                for (int i = 0; i < DataManager.monsters.Count; i++)
                {
                    DataManager.monsters.RemoveAt(i);
                }

                Console.WriteLine("Player Defeat...");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Monster가 전투에서 승리하였습니다.");
                Console.WriteLine();
                Console.WriteLine("Enter 키를 누르면 집으로 돌아갑니다.");
                Console.ReadKey();
                GameManager.DisplayHome();

            }


        }


    }
}
