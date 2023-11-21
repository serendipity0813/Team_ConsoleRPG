
using ConsoleRPG;
using System;

namespace Team_ConsoleRPG {
    //인터페이스, 클래스 등
    public interface ICharter       //플레이어 인터페이스 생성 
    {
        string Name { get; }
        int Health { get; }
        int Attack { get; }
        int Defend { get; }
        bool IsDead { get; }
        int Money { get; set; }
        void TakeDamage(int damage);
    }

    public abstract class Character : ICharter 
    {
        public string Name { get; set; }     //하위 클래스에서 수정이 가능하도록 protected set으로 설정
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defend { get; set; }
        public int Money { get; set; }
        public bool IsDead => Health <= 0;    //플레이어 체력이 0이하로 떨어지면 true값으로 전환 
        public abstract void TakeDamage(int damage);      //던전 진행시 몬스터에게 데미지를 받는 메소드
    }
}
