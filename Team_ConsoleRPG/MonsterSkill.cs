﻿using System;
using System.Xml.Linq;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    internal class MonsterSkill
    {

        public static int Attack(int damage)      //전투 진행시 몬스터가 데미지를 받는 메소드
        {
            Random random = new Random();

            int percent = random.Next(1, 100);      //1~100 중 랜덤숫자 생성
            if(percent <= 15)                       // 15이하 숫자인 경우(15% 확률)
            {
                Console.WriteLine("몬스터의 공격이 치명타가 적용됩니다.");
                float Critical = damage * (float)1.6;                              //공격력의 1.6배 적용
                Player.GetInst.Health -= (int)Critical - Player.GetInst.Defend;      //플레이어 방어력 수치 제외하고 공격
            }
            else if(percent > 90)                   // 90초과 숫자인 경우(10% 확률)
            {
                Console.WriteLine("몬스터의 공격이 빗나갑니다.");
            }
            else
            {
                Player.GetInst.Health -= (int)(damage - Player.GetInst.Defend);          //기본 공격 연산 적용
            }

            return damage;

        }

    }
}
