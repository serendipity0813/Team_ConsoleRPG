using System.Xml.Serialization;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }

    public Player(string name)
    { 
    Name = name;
    Level = 1;
    Experience = 0;
    Attack = 10;
    Defense = 10;
    Health = 100;
    Gold = 1000;
    }
    public void GainExperience(int experience)
    {
        Experience += experience;

        if (Name.ToLower() == "비둘기")
        {
            Level = 99999;
            Attack = 99999;
            Defense = 99999;
            Health = 99999;
            Gold = 99999999;
            Console.WriteLine("치트 아이디가 적용되었습니다!");
        }

        if (Experience >= Level * 15)
        {
            Levelup();
        }

    }

    private void Levelup()
    {
        Level++;
        Experience = 0;

        Console.WriteLine($"{Name}이(가) {Level} 레벨로 올라갔습니다");
    }
}






public class TextRPG
{
    public static void Main()
    {
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("원하시는 이름을 설정해주세요");

        string playerName = Console.ReadLine();
        Console.WriteLine($"플레이어의 이름이 {playerName}으로 설정되었습니다");

        List<string> jobOptions = new List<string> { "프로그래머", "게임 디렉터", "QA 테스터", "게임 프로듀서", "스토리 라이터" };
        
        Console.WriteLine("원하는 직업을 선택해주세요.");
        for (int i = 0; i < jobOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {jobOptions[i]}");
        }
        int jobChoice = int.Parse(Console.ReadLine()) - 1;
        string selectedJob = jobOptions[jobChoice];
        Console.WriteLine($"플레이어의 직업이 {selectedJob}으로 설정되었습니다.");
    }
}