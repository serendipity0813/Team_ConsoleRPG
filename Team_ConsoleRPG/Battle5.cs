﻿using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Team_ConsoleRPG
{
    internal class Battle5
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

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("----------Battle Start!----------");
                Console.ResetColor();


                while (battle) // 플레이어가 죽거나 모든 몬스터가 죽을 때까지 반복
                {
                    Console.Clear();
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
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{DataManager.monsters[i].Name}의 턴!");
                            Console.ResetColor();
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

                    Console.ReadKey();

                }

            }

        public static void BattleInfo(int count)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"플레이어 정보: 체력({Player.GetInst.Health}), 마나({Player.GetInst.MP}), 공격력({Player.GetInst.Attack}), 방어력({Player.GetInst.Defend})");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < count; i++)
            {
                if (DataManager.monsters[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"회사정보 : {DataManager.monsters[i].Name}, 체력 : {DataManager.monsters[i].Health}, 공격력 : {DataManager.monsters[i].Attack}, 방어력 : {DataManager.monsters[i].Defend}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"회사정보 : {DataManager.monsters[i].Name}, 체력 : {DataManager.monsters[i].Health}, 공격력 : {DataManager.monsters[i].Attack}, 방어력 : {DataManager.monsters[i].Defend}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }

            Console.WriteLine("----------------------------------------------------");      //플레이어와 몬스터 정보 출력 후 전투 시작
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"{Player.GetInst.Name}의 턴!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. 기본 공격");
            Console.WriteLine();
            Console.WriteLine("2. 스킬1 사용");
            Console.WriteLine();
            Console.WriteLine("3. 스킬2 사용");
            Console.WriteLine();
            Console.WriteLine("4. 가방 열기");
            Console.WriteLine();
            Console.WriteLine("5. 전투 포기");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{Player.GetInst.Name}]의 행동을 선택하세요!");
            Console.ResetColor();

            int input = GameManager.CheckInput(1, 5);


            if (0 < input && input < 4)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Player.GetInst.Name}의 턴!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("공격할 대상을 지정해 주세요");
                Console.WriteLine();
                for (int i = 0; i < count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i + 1}번 : LV.{DataManager.monsters[i].Level} {DataManager.monsters[i].Name} 공격!");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                Console.WriteLine("0. 이전으로 돌아가기");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------");


                int userinput = GameManager.CheckInput(0, count);


                if (DataManager.monsters[userinput - 1].IsDead)
                {
                    Console.WriteLine("이미 죽은 몬스터입니다.");
                    BattleInfo(count);
                }
                else
                {
                    switch (input)
                    {
                        case 0:
                            BattleInfo(count);
                            break;
                        case 1:
                            PlayerSkill.BasicAttack(userinput - 1);
                            break;
                        case 2:
                            PlayerSkill.Skill1(userinput - 1);
                            break;

                        case 3:
                            PlayerSkill.Skill2(userinput - 1);
                            break;

                    }

                }


            }

            else if (input == 4)
            {
                GameManager.DisplayInventory();

            }
            else if (input == 5)
            {
                Console.WriteLine("진행중인 전투를 포기하고 돌아갑니다");
                Battle.winpoint = 0;

                for (int i = 0; i < DataManager.monsters.Count; i++)
                {
                    DataManager.monsters.RemoveAt(i);
                }

                Console.ReadKey();
                GameManager.DisplayHome();
            }

        }

        public static void MakeMonster(int stage)
            {

                Random random = new Random();
                Random random2 = new Random();

                int start = stage * 5 - 5;
                int end = stage * 5;
                int count = random.Next(1, stage + 1);

                if (stage == 7)
                {
                    DataManager.monsters.Add(DataManager.Company[30]);
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        DataManager.monsters.Add(new Monster(DataManager.Company[random2.Next(start, end)]));
                    }
                }


            }
        }
    
}