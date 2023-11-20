using System;
using System.Numerics;
using System.Threading;

namespace ConsoleRPG
{
    public class PlayerSkill
    {
        public void BasicAttack(int input) // 플레이어 기본 공격
        {
            Console.WriteLine($"{Player.GetInst.Name}의 기본공격!");

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
                    Console.WriteLine($"크리티컬! [데미지 : {damage}]");
                    damage = (int)(damage * 1.6);
                }
                else
                {
                    Console.WriteLine($"[데미지 : {damage}]");
                }
                DataManager.monsters[input].Health -= damage;
            }


            if (DataManager.monsters.Health <= 0) // 몬스터 체력0, 사망
            {
                Console.WriteLine($"{DataManager.monsters} 처치!");
            }
            else
            {
                Console.WriteLine($"{DataManager.monsters}의 남은 체력: {DataManager.monsters.Health}");
            }

        }

        public void ThreeSnails(int input) // 스킬1
        {
            if (Player.GetInst.MP >= 5)
            {
                Console.WriteLine($"{Player.GetInst.Name}의 달팽이 세마리! - 마나 소모 5");
                Player.GetInst.MP = -5;
                int damage = Player.GetInst.Attack * 1.2;


                if (CriticalAtk())
                {
                    Console.WriteLine($"크리티컬! [데미지 : {damage}]");
                    damage = (int)(damage * 1.6);
                }
                else
                {
                    Console.WriteLine($"[데미지 : {damage}]");
                }
                DataManager.monsters.Health -= damage;


                if (DataManager.monsters.Health <= 0)
                {
                    Console.WriteLine($"{DataManager.monsters} 처치!");
                }
                else
                {
                    Console.WriteLine($"{DataManager.monsters}의 남은 체력: {DataManager.monsters.Health}");
                }
            }
            else
            {
                Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다.");
            }           
           
        }
        public void PowerStrike(int input) // 스킬2
        {
            if (player.MP >= 15)
            {
                Console.WriteLine($"{Player.GetInst.Name}의 파워 스트라이크! - 마나 소모 15");
                player.MP = -15;
                int damage = Player.GetInst.Attack * 1.5;


                if (CriticalAtk()) 
                {
                    Console.WriteLine($"크리티컬! [데미지 : {damage}]");
                    damage = (int)(damage * 1.6);
                }
                else
                {
                    Console.WriteLine($"[데미지 : {damage}]");
                }
                DataManager.monsters.Health -= damage;


                if (DataManager.monsters.Health <= 0)
                {
                    Console.WriteLine($"{DataManager.monsters} 처치 !");
                }
                else
                {
                    Console.WriteLine($"{DataManager.monsters.name}의 남은 체력: {DataManager.monsters.Health}");
                }
            }

            else
            {
                Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다.");
            }

        }
        public bool CriticalAtk() // 크리티컬 확률 15%
        {
            Random random = new Random();
            int Critchance = random.Next(1, 101);
            return Critchance <= 15;
        }
    }


}