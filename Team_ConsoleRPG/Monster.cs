using System;
using System.Threading;
using Team_ConsoleRPG;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG {
    public class Monster : Character     //몬스터 클래스 - 캐릭터 인터페이스 종속
    {
        public int Level { get; set; }      //지속적으로 변경되어 프로퍼티 - get, set

        public Monster() { }
        //몬스터 클래스 속성
        public Monster(int level, string name, int health, int attack, int defend, int money) {
            Level = level;
            Name = name;
            Health = health;
            Attack = attack;
            Defend = defend;
            Money = money;
        }

        public Monster(Monster monster) {
            Level = monster.Level;
            Name = monster.Name;
            Health = monster.Health;
            Attack = monster.Attack;
            Defend = monster.Defend;
            Money = monster.Money;
        }


        public override void TakeDamage(int damage)      //전투 진행시 몬스터가 데미지를 받는 메소드
        {
            Health -= (damage - Defend);          //플레이어 데이지 계산과 동일하게 적용
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage - Defend}의 데미지를 받았습니다. 남은 체력: {Health}");
        }



        //public static void Work(int idx)        //던전 진행 메소드 - stage 선택시 선택한 숫자를 idx로 받아서 배열의 몬스터 선택
        //{
        //    Console.Clear();
        //    int Pmaxhp = Player.GetInst.Health;          //던전 진행 후 체력을 원상태로 전환하기 위해 기존 체력값 저장
        //    int Mmaxhp = DataManager.Company[idx].Health;
        //    Player.GetInst.ticket++;                     //특수 재화인 티켓 습득 
        //    Console.WriteLine("회사로 출근합니다!");
        //    Console.WriteLine($"출근합니다! 플레이어 정보: 체력({Player.GetInst.Health}), 공격력({Player.GetInst.Attack}), 방어력({Player.GetInst.Defend})");
        //    Console.WriteLine($"회사정보 : 이름({DataManager.Company[idx].Name}), 체력({DataManager.Company[idx].Health}), 공격력({DataManager.Company[idx].Attack}), 방어력({Player.GetInst.Defend})");
        //    Console.WriteLine("----------------------------------------------------");      //플레이어와 몬스터 정보 출력 후 전투 시작

        //    while (!Player.GetInst.IsDead && !DataManager.Company[idx].IsDead) // 플레이어나 몬스터가 죽을 때까지 반복
        //    {
        //        // 플레이어의 턴
        //        Console.WriteLine($"{Player.GetInst.Name}의 턴!");
        //        DataManager.Company[idx].TakeDamage(Player.GetInst.Attack);     //플레이어의 턴이므로 몬스터 데미지 받음
        //        Console.WriteLine();
        //        Thread.Sleep(1000);     //잠시 멈추는 시간

        //        if (DataManager.Company[idx].IsDead)       //몬스터 체력이 0이하가 된 경우
        //        {
        //            Player.GetInst.Health = Pmaxhp;      //플레이어 체력 복구
        //            DataManager.Company[idx].Health = Mmaxhp;      //몬스터 체력 복구

        //            Player.GetInst.Money += DataManager.Company[idx].Money;     //몬스터의 money값 만큼 플레이어 머니 추가
        //            Player.GetInst.exp += idx;       //경험치 획득
        //            Console.WriteLine($"{idx} 만큼 경험치를 획득합니다");
        //            Console.WriteLine($"무사히 퇴근합니다. {DataManager.Company[idx].Money}만큼 보수를 획득하고 ticket을 1개 획득합니다.");

        //            if (Player.GetInst.exp >= Player.GetInst.Level * 10)      //플레이어가 레벨*10 만큼 경험치 획득시 레벨업 
        //            {
        //                Console.WriteLine("일정량 이상의 경험치를 획득, LEVEL UP! - 공격력, 방어력, 체력이 일정수치 상승합니다.");
        //                Player.GetInst.exp -= Player.GetInst.Level * 10;      //경험치를 줄이고 레벨이 상승하며 모든 스텟 상승
        //                Player.GetInst.Level++;
        //                Player.GetInst.Attack += 5;
        //                Player.GetInst.Defend += 5;
        //                Player.GetInst.Health += 50;

        //            }
        //            break;
        //        }

        //        // 몬스터의 턴
        //        Console.WriteLine($"{DataManager.Company[idx].Name}의 턴!");
        //        Player.GetInst.TakeDamage(DataManager.Company[idx].Attack);
        //        Console.WriteLine();
        //        Thread.Sleep(1000);

        //        if (Player.GetInst.IsDead)       //플레이어 사망시 몬스터, 플레이어 체력 회복 후 로비 화면으로 이동
        //        {
        //            Player.GetInst.Health = Pmaxhp;
        //            DataManager.Company[idx].Health = Mmaxhp;
        //            Console.WriteLine($"퇴사하고 집으로 돌아갑니다.");
        //            break;
        //        }



        //    }
        //    Console.ReadKey();      //결과값 확인 및 씬 전환을 위해 리드키 호출 -> 키 입력시 로비 화면으로 이동
        //    GameManager.DisplayHome();
        //}
  
    
    }
}

