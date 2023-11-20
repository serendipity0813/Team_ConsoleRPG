using System;
using System.Numerics;
using System.Threading;

namespace ConsoleRPG
{
    public class PlayerSkill
    {
       public void BasicAttack(Player player, Monster monster) // 플레이어 기본 공격
        {
            Console.WriteLine($"{Player.Name}의 기본공격!");

            int damage = player.Attack;
            Random random = new Random();
            int dodgechance = random.Next(1, 101);


            if ( dodgechance <= 10 ) // 10% 확률로 회피
            {
                Console.WriteLine($"{Player.Name}의 공격이 빗나갔다!");
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
                monster.HP -= damage;
            }           


            if (monster.HP <= 0) // 몬스터 체력0, 사망
            {
                Console.WriteLine($"{monster.Name} 처치!");
            }
            else
            {
                Console.WriteLine($"{monster.Name}의 남은 체력: {monster.HP}");
            }

        }

       public void ThreeSnails(Player player, Monster monster) // 스킬1
        {
            if (player.MP >= 5) 
            {
                Console.WriteLine($"{Player.Name}의 달팽이 세마리! - 마나 소모 5");
                player.MP = -5;
                int damage = player.Attack * 1.2;


                if (CriticalAtk())
                {
                    Console.WriteLine($"크리티컬! [데미지 : {damage}]");
                    damage = (int)(damage * 1.6);
                }
                else
                {
                    Console.WriteLine($"[데미지 : {damage}]");
                }
                monster.HP -= damage;


                if (monster.HP <= 0 ) 
                {
                    Console.WriteLine($"{monster.Name} 처치!");
                }
                else
                {
                    Console.WriteLine($"{monster.Name}의 남은 체력: {monster.HP}");
                }
            }

            else
            {
                Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다.");
            }
        }
        public void PowerStrike(Player player, Monster monster) // 스킬2
        {
            if (player.MP >= 15)
            {
                Console.WriteLine($"{Player.Name}의 파워 스트라이크! - 마나 소모 15");
                player.MP = -15;
                int damage = player.Attack * 1.5;


                if (CriticalAtk())
                {
                    Console.WriteLine($"크리티컬! [데미지 : {damage}]");
                    damage = (int)(damage * 1.6);
                }
                else
                {
                    Console.WriteLine($"[데미지 : {damage}]");
                }
                monster.HP -= damage;


                if (monster.HP <= 0)
                {
                    Console.WriteLine($"{monster.Name} 처치 !");
                }
                else
                {
                    Console.WriteLine($"{monster.Name}의 남은 체력: {monster.HP}");
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