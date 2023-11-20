using System;
using System.Threading;
using static ConsoleRPG.ConsoleRPG;



namespace ConsoleRPG {
    public class Battle1    //몬스터 클래스 - 캐릭터 인터페이스 종속
    {
        public static void Fight()        //던전 진행 메소드 - stage 선택시 선택한 숫자를 i로 받아서 배열의 몬스터 선택
        {
            Console.Clear();
            int count = DataManager.monsters.Count;
            int Pmaxhp = Player.GetInst.Health;          //던전 진행 후 체력을 원상태로 전환하기 위해 기존 체력값 저장
            bool battle = true;

            Console.WriteLine("싸움을 시작합니다.");

            while (battle) // 플레이어가 죽거나 모든 몬스터가 죽을 때까지 반복
            {
                BattleInfo(count);


                Console.WriteLine($"{Player.GetInst.Name}의 턴!");

                for (int i = 0; i < count; i++) {
                    DataManager.monsters[i].TakeDamage(Player.GetInst.Attack);     //플레이어의 턴이므로 몬스터 데미지 받음
                }

                //공격 관련 콘솔 출력

                Console.WriteLine();
                Thread.Sleep(1000);     //잠시 멈추는 시간


                // 몬스터의 턴
                for (int i = 0; i < count; i++) {
                    if (DataManager.monsters[i].IsDead == false) {
                        Console.WriteLine($"{DataManager.monsters[i].Name}의 턴!");
                        //MonsterSkill.Attack(DataManager.monsters[i].Attack);
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
            Console.WriteLine("----------------------------------------------------")
            Console.WriteLine($"플레이어 정보: 체력({Player.GetInst.Health}), 마나({Player.GetInst.Mana}), 공격력({Player.GetInst.Attack}), 방어력({Player.GetInst.Defend})");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"회사정보 : 이름({DataManager.monsters[i].Name}), 체력({DataManager.monsters[i].Health}), 공격력({DataManager.monsters[i].Attack}), 방어력({Player.GetInst.Defend})");
            }
            Console.WriteLine("----------------------------------------------------");      //플레이어와 몬스터 정보 출력 후 전투 시작
            Console.WriteLine("1. 기본 공격");
            Console.WriteLine();
            Console.WriteLine("2. 스킬 사용");
            Console.WriteLine();
            Console.WriteLine("3. 가방 열기");
            Console.WriteLine();
            Console.WriteLine("4. 전투 포기");
            Console.WriteLine("----------------------------------------------------");

            int input = Console.ReadLine();

            Console.WriteLine("1번 몬스터 공격");
            Console.WriteLine("2번 몬스터 공격");
            Console.WriteLine("3번 몬스터 공격");

            int userinput = Console.ReadLine();

            switch (input)
            {
                case 1:
                    Player.BasicAttack(userinput)

                    break;

                case 2:
                    if
                    break;

                case 3:

                    break;

                case 4:

                    break;
            }

        }

    }
}



