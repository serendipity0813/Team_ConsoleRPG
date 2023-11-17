using System;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    public class Stage
    {
        public void DisplayStage()     //난이도 선택 화면 출력
        {
            Console.Clear();
            Console.WriteLine("Stage를 선택하세요.");
            Console.WriteLine("1단계");       // 1~2 단계는 1마리 
            Console.WriteLine("2단계");      
            Console.WriteLine("3단계");       // 3~5 단계는 2~3마리 
            Console.WriteLine("4단계");
            Console.WriteLine("5단계");
            Console.WriteLine("6단계");       // 6~8 단계는 3~4마리 
            Console.WriteLine("7단계");
            Console.WriteLine("8단계");
            Console.WriteLine("9단계");       // 9~10 단계는 4~5마리 
            Console.WriteLine("10단계");
            Console.WriteLine();
            Console.WriteLine("0. 오늘은 집에서 쉬도록 하자!");

            int input = GameManager.CheckInput(0, 10);

            switch (input)
            {
                case 0:
                    GameManager.DisplayHome();
                    break;

                default:
                    if (Player.player.Level < input)        //입장 레벨(== stage) 보다 낮은 경우 경고문 출력 후 화면 다시 호출
                    {
                        Console.WriteLine($"LV{input} 이상부터 입장 가능합니다.");        
                        DisplayStage();
                        break;
                    }
                    else
                    {
                        MakeMonster(input);
                        break;
                    }


            }

        }

        public void MakeMonster(int input) 
        {
            Console.WriteLine("몬스터를 생성합니다.");
            Console.WriteLine($"출근합니다! 플레이어 정보: 체력({Player.player.Health}), 공격력({Player.player.Attack}), 방어력({Player.player.Defend})");

            Random random = new Random();
            int count = random.Next(1, input/2+1);
            int[] monsterList = new int[count];

            for (int i = 0; i < count; i++)
            {
                monsterList[i] = i;
            }

            for (int j = 0; j < count;j++)
            {
                Console.WriteLine($"회사정보 : 이름({Monster.companys[j].Name}), 체력({Monster.companys[j].Health}), 공격력({Monster.companys[j].Attack}), 방어력({Monster.companys[j].Defend})");
            }



        }



    }
}
