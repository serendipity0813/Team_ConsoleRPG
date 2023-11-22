using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_ConsoleRPG
{
    internal class MonsterDropTable
    {
        
        public void Droptable()
        {
            
            Random R = new Random();
            int dropcount = R.Next(0, 101);
           
                if (dropcount > 0 && 70 > dropcount)
                {
                    Console.WriteLine("못생긴르탄이 띠부씰을 흭득 하였습니다.");
                    Player.GetInst.inventory.Add(DataManager.Items[38]);
                }
                else if (85 > dropcount)
                {
                    Console.WriteLine("덜못생긴 르탄이 띠부씰을 흭득 하였습니다.");
                      Player.GetInst.inventory.Add(DataManager.Items[39]);
                }
                else if (95 > dropcount)
                {
                    Console.WriteLine("평범한 르탄이 띠부씰을 흭득 하였습니다.");
                    Player.GetInst.inventory.Add(DataManager.Items[40]);
                }
                else if (99 > dropcount)
                {
                    Console.WriteLine("잘생긴척 하는 르탄이 띠부씰을 흭득 하였습니다.");
                    Player.GetInst.inventory.Add(DataManager.Items[41]);
                }
                else
                {
                Console.WriteLine("레오나르도 르탄이 띠부씰을 흭득 하였습니다.");
                Player.GetInst.inventory.Add(DataManager.Items[42]);
                }

        }
    }
}
