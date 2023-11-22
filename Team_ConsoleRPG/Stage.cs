using System;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    public class Stage
    {
        public static void DisplayStage()     //난이도 선택 화면 출력
        {
            Console.Clear();
            if (Player.GetInst.Level >= 7)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ----    ---    ---    ---    ---    ---- ");
            Console.WriteLine("|    |  |   |  |   |  |   |  |   |  |    |");
            Console.WriteLine("|    |  |   |  |   |  |   |  |   |  |    |");
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                 Stage 7                |");
            Console.WriteLine("|                                        |");
            if (Player.GetInst.Level >= 6)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                 Stage 6                |");
            Console.WriteLine("|                                        |");
            if (Player.GetInst.Level >= 5)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                 Stage 5                |");
            Console.WriteLine("|                                        |");
            if (Player.GetInst.Level >= 4)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                 Stage 4                |");
            Console.WriteLine("|                                        |");
            if (Player.GetInst.Level >= 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                 Stage 3                |");
            Console.WriteLine("|                                        |");
            if (Player.GetInst.Level >= 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                 Stage 2                |");
            Console.WriteLine("|                                        |");
            if (Player.GetInst.Level >= 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                 Stage 1                |");
            Console.WriteLine("|                                        |");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                 Home  0                |");
            Console.WriteLine("|                                        |");
            Console.WriteLine(" ----------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("           [ Stage를 선택하세요 ]          ");
            Console.WriteLine();


            int input = GameManager.CheckInput(0, 7);

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
                        Battle.Fight(input);
                        break;
                    }


            }

        }



    }
}
