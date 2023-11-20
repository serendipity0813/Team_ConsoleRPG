using System;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    public class Stage
    {
        public static void DisplayStage()     //난이도 선택 화면 출력
        {
            Console.Clear();
            Console.WriteLine("Stage를 선택하세요.");
            Console.WriteLine("1단계");      
            Console.WriteLine("2단계");      
            Console.WriteLine("3단계");      
            Console.WriteLine("4단계");
            Console.WriteLine("5단계");

            Console.WriteLine();
            Console.WriteLine("0. 오늘은 집에서 쉬도록 하자!");

            int input = GameManager.CheckInput(0, 5);

            switch (input)
            {
                case 0:
                    GameManager.DisplayHome();
                    break;

                default:
                    if (Player.GetInst.Level < input)        //입장 레벨(== stage) 보다 낮은 경우 경고문 출력 후 화면 다시 호출
                    {
                        Console.WriteLine($"LV{input} 이상부터 입장 가능합니다.");
                        Console.ReadKey();
                        DisplayStage();
                        break;
                    }
                    else
                    {
                        Battle2.Fight(input);
                        break;
                    }


            }

        }

       

    }
}
