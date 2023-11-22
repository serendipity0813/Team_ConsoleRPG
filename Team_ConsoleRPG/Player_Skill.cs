using System;
using System.Numerics;
using System.Threading;

namespace ConsoleRPG
{
    public class PlayerSkill
    {
        public static void BasicAttack(int input) // 플레이어 기본 공격
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Player.GetInst.Name}의 기본공격!");
            Console.ResetColor();

            int damage = Player.GetInst.Attack;

            Random random = new Random();
            int dodgechance = random.Next(1, 101);


            if (dodgechance <= 10) // 10% 확률로 회피
            {
                Console.WriteLine($"{Player.GetInst.Name}의 공격이 빗나갔다!");
            }
            else
            {
                if (CriticalAtk()) // 기본공격 크리티컬
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"크리티컬! [데미지 : {damage}]");
                    Console.ResetColor();
                    damage = (int)(damage * 1.6);
                }
                else
                {
                    DataManager.monsters[input].Health -= damage;
                    Console.WriteLine($"[데미지 : {damage}]");
                }
            }


            if (DataManager.monsters[input].Health <= 0) // 몬스터 체력0, 사망
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{DataManager.monsters} 처치!");
                Console.ResetColor();
                Battle.winpoint++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{DataManager.monsters[input].Name}의 남은 체력: {DataManager.monsters[input].Health}");
                Console.ResetColor();
            }

        }

        public static void Skill1(int input) // 스킬1
        {
            if (Player.GetInst.MP >= 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Player.GetInst.Name}의 달팽이 세마리! - 마나 소모 5");
                Console.ResetColor();
                Player.GetInst.MP -= 5;
                int damage = (int)(Player.GetInst.Attack * 1.2);


                if (CriticalAtk())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"크리티컬! [데미지 : {damage}]");
                    Console.ResetColor();
                    damage = (int)(damage * 1.6);
                }
                else
                {
                    Console.WriteLine($"[데미지 : {damage}]");
                    DataManager.monsters[input].Health -= damage;
                }


                if (DataManager.monsters[input].Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{DataManager.monsters} 처치!");
                    Console.ResetColor();
                    Battle.winpoint++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{DataManager.monsters}의 남은 체력: {DataManager.monsters[input].Health}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다.");
                Console.ResetColor();
            }           
           
        }
        public static void Skill2(int input) // 스킬2
        {
            if (Player.GetInst.MP >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Player.GetInst.Name}의 파워 스트라이크! - 마나 소모 15");
                Console.ResetColor();
                Player.GetInst.MP -= 15;
                int damage = (int)(Player.GetInst.Attack * 1.5);


                if (CriticalAtk()) 
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"크리티컬! [데미지 : {damage}]");
                    Console.ResetColor();
                    damage = (int)(damage * 1.6);
                }
                else
                {
                    Console.WriteLine($"[데미지 : {damage}]");
                }
                DataManager.monsters[input].Health -= damage;


                if (DataManager.monsters[input].Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{DataManager.monsters} 처치 !");
                    Console.ResetColor();
                    Battle.winpoint++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{DataManager.monsters}의 남은 체력: {DataManager.monsters[input].Health}");
                    Console.ResetColor();
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다.");
                Console.ResetColor();
            }

        }
        public static bool CriticalAtk() // 크리티컬 확률 15%
        {
            Random random = new Random();
            int Critchance = random.Next(1, 101);
            return Critchance <= 15;
        }

        internal static void BasicAttack(string userinput)
        {
            throw new NotImplementedException();
        }

        internal static void Skill1(string userinput)
        {
            throw new NotImplementedException();
        }

        internal static void Skill2(string userinput)
        {
            throw new NotImplementedException();
        }
    }


}