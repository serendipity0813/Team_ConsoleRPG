﻿using System;
using System.Linq;
using System.Threading;
using Team_ConsoleRPG;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG {
    public class Dungeon    //몬스터 클래스 - 캐릭터 인터페이스 종속
    {      
        public static void Fight()        //던전 진행 메소드 - stage 선택시 선택한 숫자를 i로 받아서 배열의 몬스터 선택
        {
            Console.Clear();
            int count = MonsterMaker.monsters.Count;
            int Pmaxhp = Player.GetInst.Health;          //던전 진행 후 체력을 원상태로 전환하기 위해 기존 체력값 저장
            bool battle = true;

            Console.WriteLine("싸움을 시작합니다.");

            while (battle) // 플레이어가 죽거나 모든 몬스터가 죽을 때까지 반복
            {
                BattleInfo(count);
                // 플레이어의 턴
                Console.WriteLine($"{Player.GetInst.Name}의 턴!");
              
                //공격 관련 콘솔 출력

                Console.WriteLine();
                Thread.Sleep(1000);     //잠시 멈추는 시간

              

                // 몬스터의 턴
                for(int i = 0; i < count; i++)
                {
                    if (MonsterMaker.monsters[i].IsDead == false)
                    {
                        Console.WriteLine($"{MonsterMaker.monsters[i].Name}의 턴!");
                        Player.GetInst.TakeDamage(MonsterMaker.monsters[i].Attack);
                        Console.WriteLine();
                        Thread.Sleep(1000);
                    }
                }


                if (Player.GetInst.IsDead)       //플레이어 사망시 몬스터, 플레이어 체력 회복 후 로비 화면으로 이동
                {
                    Player.GetInst.Health = Pmaxhp;
                    Console.WriteLine("몬스터 사냥에 실패하였습니다.");
                    battle = false;
                }

                Console.WriteLine("엔터키를 눌러 다음 턴 진행");
                Console.ReadKey();

            }
            Console.ReadKey();      //결과값 확인 및 씬 전환을 위해 리드키 호출 -> 키 입력시 로비 화면으로 이동
            GameManager.DisplayHome();
        }

        public static void BattleInfo(int count)
        {
            Console.WriteLine($"플레이어 정보: 체력({Player.GetInst.Health}), 공격력({Player.GetInst.Attack}), 방어력({Player.GetInst.Defend})");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"회사정보 : 이름({MonsterMaker.monsters[i].Name}), 체력({MonsterMaker.monsters[i].Health}), 공격력({MonsterMaker.monsters[i].Attack}), 방어력({Player.GetInst.Defend})");
            }
            Console.WriteLine("----------------------------------------------------");      //플레이어와 몬스터 정보 출력 후 전투 시작

        }

    }
}

