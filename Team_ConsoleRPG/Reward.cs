using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Team_ConsoleRPG;

namespace ConsoleRPG
{
    public class Reward
    {
        public static void ShowReward(bool win)
        {
            bool End = false;

            Console.Clear();

            if (DataManager.monsters[0].Name == DataManager.Company[30].Name)
            {
                End = true;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" [전투결과] : ");

            if (win == true)
            {
                Player.GetInst.UpdateQuest(DataManager.monsters);

                int totalexp = 0;
                int totalmoney = 0;
                Battle.winpoint = 0;
                MonsterDropTable Dropmonster = new MonsterDropTable();

                for (int i = 0; i < DataManager.monsters.Count; i++)
                {
                    totalexp += DataManager.monsters[i].Level;
                    totalmoney += DataManager.monsters[i].Money;
                }

                Player.GetInst.exp += totalexp;
                Player.GetInst.Money += totalmoney;

                Console.WriteLine("Player Win!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Player.GetInst.Name}가 전투에서 승리하였습니다!");
                Console.WriteLine();

                Console.WriteLine($"{totalexp}만큼 경험치를 획득합니다.");
                Console.WriteLine($"{totalmoney}만큼 돈을 획득합니다.");
                Dropmonster.Droptable(); //드랍 테이블

                Console.ResetColor();
                Console.WriteLine();

                if (Player.GetInst.exp > Player.GetInst.Level * Player.GetInst.Level * 5)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("LEVEL UP! - 공격력, 방어력, 체력이 일정수치 상승합니다.");
                    Console.ResetColor();
                    Player.GetInst.exp -= Player.GetInst.Level * 5;      //경험치를 줄이고 레벨이 상승하며 모든 스텟 상승
                    Player.GetInst.Level++;
                    Player.GetInst.Attack += 5;
                    Player.GetInst.Defend += 5;
                    Player.GetInst.Health += 50;
                }

                DataManager.monsters.Clear();

                if (End)
                {
                    Console.WriteLine(" 보스 몬스터를 처치하였습니다!");
                    Console.ReadKey();
                    Ending.EndingScene();
                }
                else
                {
                    Console.WriteLine("Enter키를 누르면 집으로 돌아갑니다.");
                    Console.ReadKey();
                    GameManager.DisplayHome();
                }

            }

            else if (win == false)
            {
                DataManager.monsters.Clear();

                Battle.winpoint = 0;

                Console.WriteLine("Player Defeat...");
                Console.WriteLine();
                Console.ResetColor();
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
