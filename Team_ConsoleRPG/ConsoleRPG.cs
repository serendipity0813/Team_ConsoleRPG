﻿using System;
using System.Collections.Generic;
using System.IO;
using Team_ConsoleRPG;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    internal class ConsoleRPG
    {

        public static void Main(string[] args)
        {
            //게임시작점 - 아이템, 플레이어, 몬스터 데이터 세팅
            DataManager.DataSetting();

            if(!Player.GetInst.Load())
                GameManager.StartMain();
            
            GameManager.DisplayHome();      //게임메니저 호출하여 메인로비 호출
        }

    }
}
