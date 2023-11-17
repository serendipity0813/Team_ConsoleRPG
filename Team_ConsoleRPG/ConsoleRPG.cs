using System;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    internal class ConsoleRPG
    {

        public static void Main(string[] args)
        {
            //게임시작점 - 아이템, 플레이어, 몬스터 데이터 세팅
            Item.ItemDataSetting();
            Player.GetInst.PlayerDataSetting("unity", Jop.student, 1, 100, 10, 5, 1000);
            GameManager.DataSetting();
            GameManager.DisplayHome();      //게임메니저 호출하여 메인로비 호출
        }

    }
}
