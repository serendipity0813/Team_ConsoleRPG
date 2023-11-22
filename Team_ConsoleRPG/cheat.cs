using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_ConsoleRPG
{
    internal class Cheat
    {
        public static void Level()
        {
            Player.GetInst.Level = 99;
        }

        public static void Attack()
        {
            Player.GetInst.Attack = 9999;
        }

        public static void Defend()
        {
            Player.GetInst.Defend = 9999;
        }

        public static void Health()
        {
            Player.GetInst.Health = 1;
        }

        public static void Money()
        {
            Player.GetInst.Money = 999999;
        }

    }
}
