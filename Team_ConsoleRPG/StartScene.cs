using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public static class StartScene
    {
        public static void StartMain()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------[ W e l c o m e ]------------------");
            Console.WriteLine();
            Console.WriteLine("--------스파르타 던전에 오신 여러분 환영합니다.---------");
            Console.WriteLine();
            Console.WriteLine("------------------[ W e l c o m e ]------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    원하시는 이름을 설정해주세요");
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
            Console.Write("    이름 : ");
            string playerName = Console.ReadLine();
          
            Console.WriteLine();
            if (playerName.ToLower() == "비둘기")
            {
                GameManager.AdminMode();
                return;
            }
            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------[ W e l c o m e ]------------------");
            Console.WriteLine();
            Console.WriteLine("--------스파르타 던전에 오신 여러분 환영합니다.---------");
            Console.WriteLine();
            Console.WriteLine("------------------[ W e l c o m e ]------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"  플레이어의 이름이 {playerName}으로 설정되었습니다");
            Console.WriteLine();
            Console.WriteLine("  캐릭터의 직업을 선택해주세요");

            List<string> jobOptions = new List<string> { "프로그래머", "게임 디렉터", "QA 테스터", "게임 프로듀서", "스토리 라이터" };
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < jobOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {jobOptions[i]}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("    직업 : ");

            int jobChoice = int.Parse(Console.ReadLine()) - 1;
            string selectedJob = jobOptions[jobChoice];
            Console.WriteLine();
            Console.WriteLine($"플레이어의 직업이 {selectedJob}으로 설정되었습니다.");

            Player.GetInst.PlayerDataSetting(playerName, (Jop)jobChoice, 1, 100, 100, 10, 5, 1000);
            Console.ReadKey();
        }

    }
}
