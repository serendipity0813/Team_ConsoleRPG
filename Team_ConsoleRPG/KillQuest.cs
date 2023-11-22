//using ConsoleRPG;
//using System;
//using System.Collections.Generic;

//namespace Team_ConsoleRPG {
//    internal class KillQuest : Quest {
//        public List<Monster> targetMonsters;
//        public List<int> CurCout;
//        public List<int> MaxtargetCout;

//        public KillQuest(string name, List<String> des, List<Item> rewardItems, int rewardGold, List<Monster> mons, List<int> max) :
//            base(name, des, rewardItems, rewardGold) {
//            targetMonsters = mons;
//            MaxtargetCout = max;

//            CurCout = new List<int>();
//            for (int i = 0; i < targetMonsters.Count; i++) {
//                CurCout.Add(0);
//            }
//        }

//        public override void DisplayQuestBoard() {
//            base.DisplayQuestBoard();
//            for (int i = 0; i < targetMonsters.Count; i++) {
//                Console.WriteLine($"- {targetMonsters[i].Name} {MaxtargetCout}마리 처리 ({CurCout}/{MaxtargetCout})");
//            }

//            Console.WriteLine("- 보상 -");
//            for (int i = 0; i < RewardItems.Count; i++) {
//                Console.WriteLine($"{RewardItems[i].Name}");
//            }
//            Console.WriteLine($"{RewardGold}G");
//        }

//        public override void CheckClear() {

//        }

//        public override void Reward() {

//        }
//    }
//}
