using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Team_ConsoleRPG
{
    public class Quest
    {
        public string questName;
        public List<String> description;

        public bool clear = false;

        public List<int> RewardItemID;
        public int RewardGold;

        public List<string> targetMonsters;
        public List<int> MaxtargetCout;
        public List<int> CurCout;

        public Quest(string name, List<String> des, List<int> rewardItems, int rewardGold, List<string> mons, List<int> max)
        {
            questName = name;
            description = des;
            if(rewardItems != null)
                RewardItemID = rewardItems;
            else
                RewardItemID = new List<int>();
            RewardGold = rewardGold;
            if(mons != null)
                targetMonsters = mons;
            else
                targetMonsters = new List<string>();

            if(max != null)
                MaxtargetCout = max;
            else
                MaxtargetCout = new List<int>();

            CurCout = new List<int>();
            for (int i = 0; i < targetMonsters.Count; i++) {
                CurCout.Add(0);
            }

        }

        public void DisplayQuestBoard() 
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ----------------------------------------------------------------");
            Console.WriteLine(" ----------------------------------------------------------------");
            Console.WriteLine($"    {questName}");
            for (int i = 0; i < description.Count; ++i) 
            {
                Console.WriteLine("                                                                ");
                Console.WriteLine($"   {description[i]}");
                Console.WriteLine("                                                                ");
            }
            Console.WriteLine(" ----------------------------------------------------------------");
            Console.WriteLine(" ----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            for (int i = 0; i < targetMonsters.Count; i++) {
                Console.WriteLine($"- {targetMonsters[i]} {MaxtargetCout[i]}마리 처리 ({CurCout[i]}/{MaxtargetCout[i]})");
            }

            Console.WriteLine();
            Console.WriteLine(" ||----------------------------------------------------------------||");
            Console.WriteLine();
            Console.WriteLine("       - 보상 -");
            for (int i = 0; i < RewardItemID.Count; i++) {
                Console.WriteLine($"       {DataManager.Items[RewardItemID[i]].Name}");
            }
            Console.WriteLine();
            Console.WriteLine($"       {RewardGold}G");
            Console.WriteLine();
            Console.WriteLine(" ||----------------------------------------------------------------||");
            Console.WriteLine();
            Console.ResetColor();

            if (clear) {
                Completed();
            } else if(CheckPlaying()) {
                PlayingQuest();
            } else {
                StartQuest();
            }
        }

        public bool CheckClear() 
        {
            for (int i = 0; i < MaxtargetCout.Count; i++) {
                if (MaxtargetCout[i] > CurCout[i])
                    return false;
            }
            return true;
        }

        public void Reward() 
        {
            for(int i = 0; i < RewardItemID.Count; i++) {
                Player.GetInst.DropGetItem(DataManager.Items[RewardItemID[i]]);
            }
            Player.GetInst.Money += RewardGold;
            clear = true;

            Console.Clear();
            Console.WriteLine("- 보상 획득!!-");
            for (int i = 0; i < RewardItemID.Count; i++) {
                Console.WriteLine($"{DataManager.Items[RewardItemID[i]].Name}");
            }
            Console.WriteLine($"{RewardGold}G");
            Console.ReadKey();
        }

        public bool CheckPlaying() 
        {
            List<Quest> questList = Player.GetInst.questList;
            for(int i = 0; i <  questList.Count; i++) {
                if (questList[i] == this)
                    return true;
            }
            return false;
        }

        public void PlayingQuest() {
            if (CheckClear()) {
                Console.WriteLine("1. 보상 받기");
                Console.WriteLine("2. 돌아 가기");

                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int input = GameManager.CheckInput(1, 2);       //입력하는 숫자에 따라 화면 출력

                switch (input) {
                    case 1:
                        Reward();
                        GameManager.DisplayQuest();
                        break;
                    case 2:
                        GameManager.DisplayQuest();
                        break;
                    default:
                        break;
                }

            } else {
                Console.WriteLine("1. 포기 하기");
                Console.WriteLine("2. 돌아 가기");

                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int input = GameManager.CheckInput(1, 2);       //입력하는 숫자에 따라 화면 출력

                switch (input) {
                    case 1:
                        GiveUP();
                        GameManager.DisplayQuest();
                        break;
                    case 2:
                        GameManager.DisplayQuest();
                        break;
                    default:
                        break;
                }
            }     
        }

        public void Completed() {
            Console.WriteLine("완료한 퀘스트에요 !!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("1. 돌아 가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = GameManager.CheckInput(1, 1);       //입력하는 숫자에 따라 화면 출력

            switch (input) {
                case 1:
                    GameManager.DisplayQuest();
                    break;
                default:
                    break;
            }
        }

        public void StartQuest() {
            Console.WriteLine("1. 수락");
            Console.WriteLine("2. 거절");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = GameManager.CheckInput(1, 2);       //입력하는 숫자에 따라 화면 출력

            switch (input) {
                case 1:
                    Player.GetInst.questList.Add(this);
                    GameManager.DisplayQuest();
                    break;
                case 2:
                    GameManager.DisplayQuest();
                    break;
                default:
                    break;
            }
        }

        public void GiveUP() {
            for (int i = 0; i < CurCout.Count; i++) {
                CurCout[i] = 0;
            }

            List<Quest> questList = Player.GetInst.questList;
            for (int i = 0; i < questList.Count; i++) {
                if (questList[i] == this)
                    questList.Remove(this);
            }
        }

        public void UpdateQuest(List<Monster> monsters) {
            for(int i = 0; i < targetMonsters.Count; i++) {
                for(int j = 0; j <  monsters.Count; j++) {
                    if (targetMonsters[i] == monsters[j].Name)
                        CurCout[i]++;
                }
            }
        }
    }
}
