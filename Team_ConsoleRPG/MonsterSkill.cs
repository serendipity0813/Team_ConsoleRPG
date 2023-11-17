using System;
using System.Xml.Linq;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    internal class MonsterSkill
    {
        Random random = new Random();

        public void Attack(float damage)      //전투 진행시 몬스터가 데미지를 받는 메소드
        {
            int percent = random.Next(1, 100);      //1~100 중 랜덤숫자 생성
            if(percent <= 15)                       // 15이하 숫자인 경우(15% 확률)
            {
                float Critical = damage * (float)1.6;                              //공격력의 1.6배 적용
                Player.player.Health -= (int)Critical - Player.player.Defend;      //플레이어 방어력 수치 제외하고 공격
            }
            else if(percent > 90)                   // 90초과 숫자인 경우(10% 확률)
            {
                Console.WriteLine("몬스터가 공격을 회피하였습니다!");
            }
            else
            {
                Player.player.Health -= (int)(damage - Player.player.Defend);          //기본 공격 연산 적용
            }

            //플레이어 사망여부 체크
            if (Player.player.IsDead)
            {
                Console.WriteLine($"{Player.player.Name}이(가) 죽었습니다.");     
            }
            else
            {
                Console.WriteLine($"{Player.player.Name}이(가) {damage - Player.player.Defend}의 데미지를 받았습니다. 남은 체력: {Player.player.Health}");

            }

        }




    }
}
