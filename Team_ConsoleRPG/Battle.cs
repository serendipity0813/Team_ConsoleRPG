using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Battle2    //몬스터 클래스 - 캐릭터 인터페이스 종속
    {
        public static void Fight(int stage)        //던전 진행 메소드 - stage 선택시 선택한 숫자를 변수로 받아서 배열의 몬스터 선택
        {
            Console.Clear();
            MakeMonster(stage);
            int count = DataManager.monsters.Count;
            int Pmaxhp = Player.GetInst.Health;          //던전 진행 후 체력을 원상태로 전환하기 위해 기존 체력값 저장
            bool battle = true;
            bool win = true;
            int winpoint = 0;

            Console.WriteLine("싸움을 시작합니다.");


            while (battle) // 플레이어가 죽거나 모든 몬스터가 죽을 때까지 반복
            {
                BattleInfo(count);

                Console.WriteLine($"{Player.GetInst.Name}의 턴!");

                winpoint++;
                //플레이어 공격 관련 콘솔 출력

                Console.WriteLine();
                Thread.Sleep(1000);     //잠시 멈추는 시간


                if (winpoint > DataManager.monsters.Count)
                {
                    Player.GetInst.Health = Pmaxhp;
                    battle = true;
                    win = true;

                    Reward.ShowReward(win);
                }


                //몬스터의 턴
                for (int i = 0; i < count; i++)
                {
                    if (DataManager.monsters[i].IsDead == false)
                    {
                        Console.WriteLine($"{DataManager.monsters[i].Name}의 턴!");
                        MonsterSkill.Attack(DataManager.monsters[i].Attack, DataManager.monsters[i].Level, DataManager.monsters[i].Name);
                        Console.WriteLine();
                        Thread.Sleep(1000);
                    }
                }


                if (Player.GetInst.IsDead)       //플레이어 사망시 몬스터, 플레이어 체력 회복 후 로비 화면으로 이동
                {
                    Player.GetInst.Health = Pmaxhp;
                    battle = false;
                    win = false;

                    Reward.ShowReward(win);
                }



                Console.WriteLine("엔터키를 눌러 다음 턴 진행");
                Console.ReadKey();

            }

        }

        public static void BattleInfo(int count)
        {
            Console.WriteLine($"플레이어 정보: 체력({Player.GetInst.Health}), 공격력({Player.GetInst.Attack}), 방어력({Player.GetInst.Defend})");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"회사정보 : 이름({DataManager.monsters[i].Name}), 체력({DataManager.monsters[i].Health}), 공격력({DataManager.monsters[i].Attack}), 방어력({Player.GetInst.Defend})");
            }
            Console.WriteLine("----------------------------------------------------");      //플레이어와 몬스터 정보 출력 후 전투 시작


        }

        public static void MakeMonster(int stage)
        {
            Console.WriteLine("몬스터를 생성합니다.");

            Random random = new Random();
            Random random2 = new Random();

            int start = stage * 5 - 5;
            int end = stage * 5;
            int count = random.Next(1, stage + 1);

            if(stage == 7)
            {
                DataManager.monsters.Add(DataManager.Company[31]);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    DataManager.monsters.Add(DataManager.Company[random2.Next(start, end)]);
                }
            }
          

        }
    }
}
