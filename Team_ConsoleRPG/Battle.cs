using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Battle    
    {
        public static int winpoint = 0;

        public static void Fight(int stage)        //던전 진행 메소드 - stage 선택시 선택한 숫자를 변수로 받아서 배열의 몬스터 선택
        {
            Console.Clear();
            MakeMonster(stage);
            int count = DataManager.monsters.Count;
            int Pmaxhp = Player.GetInst.Health;          //던전 진행 후 체력을 원상태로 전환하기 위해 기존 체력값 저장
            int Pmaxmp = Player.GetInst.MP;
            bool battle = true;
            bool win = true;

            Console.WriteLine("싸움을 시작합니다.");


            while (battle) // 플레이어가 죽거나 모든 몬스터가 죽을 때까지 반복
            {
                BattleInfo(count);

                Console.WriteLine();
                Thread.Sleep(1000);     //잠시 멈추는 시간


                if (winpoint == DataManager.monsters.Count)
                {
                    Player.GetInst.Health = Pmaxhp;
                    Player.GetInst.MP = Pmaxmp;
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
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"플레이어 정보: 체력({Player.GetInst.Health}), 마나({Player.GetInst.MP}), 공격력({Player.GetInst.Attack}), 방어력({Player.GetInst.Defend})");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"회사정보 : 이름({DataManager.monsters[i].Name}), 체력({DataManager.monsters[i].Health}), 공격력({DataManager.monsters[i].Attack}), 방어력({Player.GetInst.Defend})");
            }
            Console.WriteLine($"{Player.GetInst.Name}의 턴!");
            Console.WriteLine("----------------------------------------------------");      //플레이어와 몬스터 정보 출력 후 전투 시작
            Console.WriteLine("1. 기본 공격");
            Console.WriteLine();
            Console.WriteLine("2. 스킬1 사용");
            Console.WriteLine("3. 스킬2 사용");
            Console.WriteLine();
            Console.WriteLine("4. 가방 열기");
            Console.WriteLine();
            Console.WriteLine("5. 전투 포기");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"({Player.GetInst.Name})은 무엇을 할까?");

            int input = GameManager.CheckInput(1, 5);


            if (0 < input && input < 4)
            {
                Console.WriteLine("1번 몬스터 공격");
                Console.WriteLine("2번 몬스터 공격");
                Console.WriteLine("3번 몬스터 공격");
                Console.WriteLine("공격할 대상을 지정해 주세요");

                int userinput = GameManager.CheckInput(1, 3);

                switch (userinput)
                {
                    case 1:
                        PlayerSkill.BasicAttack(userinput);
                        break;

                    case 2:
                        PlayerSkill.Skill1(userinput);
                        break;

                    case 3:
                        PlayerSkill.Skill2(userinput);
                        break;

                }


            }

            else if (input == 4)
            {

                GameManager.DisplayBattleinventory();
            }
            else if (input == 5) 
            {
                Console.WriteLine("진행중인 전투를 포기하고 돌아갑니다");
                Stage.DisplayStage();
            }
                    
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
