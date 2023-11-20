using System;
using System.Collections.Generic;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    public class MonsterMaker
    {
        public static List<Monster> company;
        public static Monster[] monsters = new Monster[5];

        public static void MonsterSetting()
        {
            company = new List<Monster>();

            company.Add(new Monster("0", 1, 1, 1, 1));
            company.Add(new Monster("1", 1, 1, 1, 1));
            company.Add(new Monster("2", 1, 1, 1, 1));
            company.Add(new Monster("3", 1, 1, 1, 1));
            company.Add(new Monster("4", 1, 1, 1, 1));
            company.Add(new Monster("5", 1, 1, 1, 1));
            company.Add(new Monster("6", 1, 1, 1, 1));
            company.Add(new Monster("7", 1, 1, 1, 1));
            company.Add(new Monster("8", 1, 1, 1, 1));
            company.Add(new Monster("9", 1, 1, 1, 1));
            company.Add(new Monster("10", 1, 1, 1, 1));
            company.Add(new Monster("11", 1, 1, 1, 1));
            company.Add(new Monster("12", 1, 1, 1, 1));
            company.Add(new Monster("13", 1, 1, 1, 1));
            company.Add(new Monster("14", 1, 1, 1, 1));
            company.Add(new Monster("15", 1, 1, 1, 1));
            company.Add(new Monster("16", 1, 1, 1, 1));
            company.Add(new Monster("17", 1, 1, 1, 1));
            company.Add(new Monster("18", 1, 1, 1, 1));
            company.Add(new Monster("19", 1, 1, 1, 1));
            company.Add(new Monster("20", 1, 1, 1, 1));
            company.Add(new Monster("21", 1, 1, 1, 1));
            company.Add(new Monster("22", 1, 1, 1, 1));
            company.Add(new Monster("23", 1, 1, 1, 1));
            company.Add(new Monster("24", 1, 1, 1, 1));
            company.Add(new Monster("25", 1, 1, 1, 1));
            company.Add(new Monster("26", 1, 1, 1, 1));
            company.Add(new Monster("27", 1, 1, 1, 1));
            company.Add(new Monster("28", 1, 1, 1, 1));
            company.Add(new Monster("29", 1, 1, 1, 1));
            company.Add(new Monster("30", 1, 1, 1, 1));
            company.Add(new Monster("32", 1, 1, 1, 1));
            company.Add(new Monster("33", 1, 1, 1, 1));
            company.Add(new Monster("34", 1, 1, 1, 1));
            company.Add(new Monster("35", 1, 1, 1, 1));
            company.Add(new Monster("36", 1, 1, 1, 1));
            company.Add(new Monster("37", 1, 1, 1, 1));
            company.Add(new Monster("38", 1, 1, 1, 1));
            company.Add(new Monster("39", 1, 1, 1, 1));
            company.Add(new Monster("40", 1, 1, 1, 1));
            company.Add(new Monster("41", 1, 1, 1, 1));
            company.Add(new Monster("42", 1, 1, 1, 1));
            company.Add(new Monster("43", 1, 1, 1, 1));
            company.Add(new Monster("44", 1, 1, 1, 1));
            company.Add(new Monster("45", 1, 1, 1, 1));
            company.Add(new Monster("46", 1, 1, 1, 1));
            company.Add(new Monster("47", 1, 1, 1, 1));
            company.Add(new Monster("48", 1, 1, 1, 1));
            company.Add(new Monster("49", 1, 1, 1, 1));
            company.Add(new Monster("50", 1, 1, 1, 1));

        }

        public static int MakeMonster(int stage) 
        {
            Console.WriteLine("몬스터를 생성합니다.");

            Random random = new Random();
            Random monsterNumber = new Random();

            int start = stage * 10 - 10;
            int end = stage*10-1;
            int count = random.Next(1, 3);


            for (int i = 0; i < count; i++)
            {
                MonsterMaker.monsters[i] = MonsterMaker.company[monsterNumber.Next(start, end)];
            }

            return count;
            
        }



    }
}
