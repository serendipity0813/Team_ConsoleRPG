using System;
using System.Runtime.Remoting.Activation;
using System.Xml.Linq;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    internal class MonsterSkill
    {

        public static void Attack(int damage, int level, string name)      //전투 진행시 몬스터가 데미지를 받는 메소드
        {
            Random random = new Random();

            int percent = random.Next(1, 101);      //1~100 중 랜덤숫자 생성
            Console.WriteLine($"LV.{level} {name}의 공격");

            if(level >=1 && percent <11)
                Skill_1(damage);
            else if(level >= 2 && percent < 21)
                Skill_2();
            else if (level >= 3 && percent < 31)
                Skill_3(damage);
            else if (level >= 4 && percent < 41)
                Skill_4();
            else if (level >= 4 && percent < 51)
                Skill_5();
            else
                NormalAttack(damage);


        }

        public static void NormalAttack(int damage)
        {
            Random random = new Random();


            int percent = random.Next(1, 101);      //1~100 중 랜덤숫자 생성
            if (percent <= 20)                       // 15이하 숫자인 경우(15% 확률)
            {
                float Critical = damage * (float)1.6;                              //공격력의 1.6배 적용
                Player.GetInst.Health -= (int)Critical - Player.GetInst.Defend;      //플레이어 방어력 수치 제외하고 공격
                Console.WriteLine($"몬스터의 크리티컬 공격! - 데미지 : {(int)Critical - Player.GetInst.Defend}");

            }
            else if (percent > 80)                   // 90초과 숫자인 경우(10% 확률)
            {
                Console.WriteLine("몬스터의 공격이 빗나갑니다.");
            }
            else
            {
                Player.GetInst.Health -= damage - Player.GetInst.Defend;          //기본 공격 연산 적용
                Console.WriteLine($"몬스터가 공격합니다! - 데미지 : {damage - Player.GetInst.Defend}");
            }

        }
        public static void Skill_1(int damage)
        {
            Player.GetInst.Health -= damage;
            Console.WriteLine($"몬스터가 스킬1 사용(방어무시) - 데미지 : {damage}");

        }

        public static void Skill_2()
        {
            Player.GetInst.Health -= Player.GetInst.Health / 10 - Player.GetInst.Defend;
            Console.WriteLine($"몬스터가 스킬2 사용(체력비례 데미지) - 데미지 : {Player.GetInst.Health / 10}");

        }

        public static void Skill_3(int damage)
        {
            Player.GetInst.Health -= damage - Player.GetInst.Defend;
            Player.GetInst.Health -= damage - Player.GetInst.Defend;
            Console.WriteLine($"몬스터가 스킬3 사용(더블어택) - 데미지 : {(damage - Player.GetInst.Defend)} * 2");

        }

        public static void Skill_4()
        {
            Player.GetInst.Health -= Player.GetInst.Attack - Player.GetInst.Defend;
            Console.WriteLine($"몬스터가 스킬4 사용(반사공격) - 데미지 : {Player.GetInst.Health / 10}");

        }

        public static void Skill_5()
        {
            Player.GetInst.Health -= Player.GetInst.Attack;
            Player.GetInst.Health -= Player.GetInst.Health / 10;
            Console.WriteLine($"몬스터가 스킬5 사용(종합선물세트) - 데미지 : {Player.GetInst.Health / 10} + {Player.GetInst.Attack}");

        }


    }
}
