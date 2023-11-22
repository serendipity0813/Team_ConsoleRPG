using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Team_ConsoleRPG;
using static ConsoleRPG.ConsoleRPG;


namespace ConsoleRPG
{
    internal class GameManager      //게임 기능적인 부분을 관리하는 클래스
    {
        //Display 함수 모음    
        public static void StartMain()
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요");

            string playerName = Console.ReadLine();
            Console.WriteLine($"플레이어의 이름이 {playerName}으로 설정되었습니다");

            List<string> jobOptions = new List<string> { "프로그래머", "게임 디렉터", "QA 테스터", "게임 프로듀서", "스토리 라이터" };
            if (playerName.ToLower() == "비둘기")
            {
                AdminMode();
                return;
            }
            Console.WriteLine("원하는 직업을 선택해주세요.");
            for (int i = 0; i < jobOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {jobOptions[i]}");
            }
            int jobChoice = int.Parse(Console.ReadLine()) - 1;
            string selectedJob = jobOptions[jobChoice];
            Console.WriteLine($"플레이어의 직업이 {selectedJob}으로 설정되었습니다.");

            Player.GetInst.PlayerDataSetting(playerName, (Jop)jobChoice, 1, 100, 100, 10, 5, 1000);
        }
        public static void AdminMode()
        {
            Console.WriteLine("관리자 모드에 진입하셨습니다.");

            //모든 능력치 99999로, 보유골드 99999999로 설정
            Player.GetInst.PlayerDataSetting("비둘기", Jop.프로그래머, 99999, 99999, 100, 99999, 99999, 99999999);

            Console.WriteLine("비둘기님의 능력치와 보유 골드가 최대치로 설정되었습니다.");
            Console.WriteLine();
        }   


        public static void DisplayHome()        //메인 로비화면 출력
        {
            Console.ResetColor();
            Console.Clear();    //콘솔창 정리 후 집에 도착했다는 문구와 함께 선택지 출력

            Console.WriteLine("삑 삑 삐삐삑...  띠로리~");
            Console.WriteLine("집에 들어오니 마음이 안정되는 것 같다.");
            Console.WriteLine("다음 행동을 선택하세요.");
            Console.WriteLine();
            Console.WriteLine("1. 현재상태 확인");
            Console.WriteLine("2. 인벤토리 확인");
            Console.WriteLine("3. 인터넷 쇼핑");
            Console.WriteLine("4. 지인 만나기");
            Console.WriteLine("5. 회사로 출근");
            Console.WriteLine("6. 업무 확인");
            Console.WriteLine("7. 저장하고 종료");
            Console.WriteLine();

            int input = CheckInput(1, 7);       //입력하는 숫자에 따라 화면 출력

            switch (input)
            {
                case 1:
                    DisplayInfo();
                    break;
                case 2:
                    DisplayInventory();
                    break;
                case 3:
                    DisplayShop();
                    break;
                case 4:
                    DisplayCommunity();
                    break;
                case 5:
                    Stage.DisplayStage();
                    break;
                case 6:
                    DisplayQuest();
                    break;
                case 7:
                    Player.GetInst.Save();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    CheckInput(1, 6);
                    break;

            }

        }

        public static void DisplayInfo()        //캐릭터 정보 화면 출력
        {
            Console.Clear();

            Console.WriteLine("나의 정보를 표시합니다.");         //플레이어의 이름, 직업 등등 수치 출력 및 추가수치도 따로 표시
            Console.WriteLine();
            Console.WriteLine($"이름 : {Player.GetInst.Name}");
            Console.WriteLine($"직업 : {Player.GetInst.Job}");
            Console.WriteLine($"레벨 : {Player.GetInst.Level}");
            int bonusHealth = Player.GetInst.GetBonusHealth();
            Console.WriteLine($"체력 : {Player.GetInst.Health} ( + {bonusHealth})");
            int bonusAttack = Player.GetInst.GetBonusAttack();
            Console.WriteLine($"공격력 : {Player.GetInst.Attack} ( + {bonusAttack})");
            int bonusDefend = Player.GetInst.GetBonusDefend();
            Console.WriteLine($"방어력 : {Player.GetInst.Defend} ( + {bonusDefend})");
            Console.WriteLine($"가진돈 : {Player.GetInst.Money}");
            Console.WriteLine();
            Console.WriteLine("나가기 : 0");

            int input = CheckInput(0, 0);

            switch (input)
            {
                case 0:
                    DisplayHome();
                    break;
            }
        }
        
        public static void DisplayInventory()       //아이템 인벤토리 출력
        {
            Console.Clear();

            Console.WriteLine("어느 인벤토리를 들어갈지 선택하시오");
            Console.WriteLine("1. 장비");
            Console.WriteLine("2.소모품");
            Console.WriteLine("3.재료");
            Console.WriteLine();
            Console.WriteLine("0. 돌아가기");
            int input = CheckInput(0, 3);
            List<Item> inven = Player.GetInst.inventory;
            switch (input)
            {
                case 0:
                    DisplayHome();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine();
                    //for (int i = 1; i < DataManager.Items.Count; i++)      //모든 아이템을 확인하며 HAVE 값이 TRUE라면 아이템 데이터 출력
                    //{
                    //    if (DataManager.Items[i].Have == true) {
                    //        if (DataManager.Items[i].ID >= 10)
                    //            Console.Write($"{DataManager.Items[i].ID}. ");
                    //        else
                    //            Console.Write($" {DataManager.Items[i].ID}. ");
                    //        DataManager.Items[i].PrintItemData();
                    //    }
                    //}

                    inven.Sort((x, y) => x.Type.CompareTo(y.Type)); //정렬식
                    Console.WriteLine("|| 장 비 ||");
                    Console.WriteLine("===|| 이 름 ||==========|| 상 품 명||=========|| 가 격||=========|| 옵 션 ||========");
                    for (int i = 0; i < inven.Count; i++)
                    {
                        if (inven[i].Type != ItemType.activeitem && inven[i].Type != ItemType.ingredient)
                        {
                            if (i >= 10)
                                Console.Write($" {i + 1}||");
                            else
                                Console.Write($" {i + 1} ||");
                            inven[i].PrintItemData();
                        }
                    }
                    /* //월래 작성된 구간
                   for (int i = 0; i < inven.Count; i++)
                   {
                       if (inven[i].Type == ItemType.activeitem)
                       {
                           if (i >= 10)
                               Console.Write($"{i + 1}. ");
                           else
                               Console.Write($" {i + 1}. ");
                           inven[i].PrintItemData();
                       }
                   }
                   */
                    Console.WriteLine();
                    Console.WriteLine(" ");             //추가로 진행할 수 있는 기능 출력

                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("1. 장착관리");
                    Console.WriteLine("2. 당근마켓에 아이템 팔기");
                    Console.WriteLine(" ");
                    Console.WriteLine("원하시는 행동을 입력하시오");
                    Console.WriteLine();

                    input = CheckInput(0, 2);

                    switch (input)
                    {
                        case 0:
                            DisplayHome();
                            break;
                        case 1:
                            DisplayItemEquip();
                            break;
                        case 2:
                            DisplayItemSell();
                            break;

                    }

                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine();
                    Console.WriteLine("|| 소모품 ||");
                    Console.WriteLine("===|| 이 름 ||==========|| 상 품 명||=========|| 가 격||=========|| 옵 션 ||========");

                    inven.Sort((x, y) => x.Type.CompareTo(y.Type));
                    for (int i = 0; i < inven.Count; i++)
                    {
                        if (inven[i].Type == ItemType.activeitem)
                        {
                            
                            if (i >= 10)
                                Console.Write($"{i + 1}. ");
                            else
                                Console.Write($" {i + 1}. ");
                            inven[i].PrintItemData();
                        }
                    }

                    /* //월래 작성된 구간
                    for (int i = 0; i < inven.Count; i++)
                    {
                        if (inven[i].Type == ItemType.activeitem)
                        {
                            if (i >= 10)
                                Console.Write($"{i + 1}. ");
                            else
                                Console.Write($" {i + 1}. ");
                            inven[i].PrintItemData();
                        }
                    }
                    */
                    Console.WriteLine(" ");             //추가로 진행할 수 있는 기능 출력

                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("1. 당근마켓에 아이템 팔기");
                    Console.WriteLine(" ");
                    Console.WriteLine("원하시는 행동을 입력하시오");
                    Console.WriteLine();

                    input = CheckInput(0, 1);

                    switch (input)
                    {
                        case 0:
                            DisplayHome();
                            break;
                        case 1:
                            DisplayItemSell();
                            break;

                    }

                    Console.Clear();
                    break;
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("[아이템 목록]");
                        Console.WriteLine();
                        Console.WriteLine("|| 재료 ||");
                        Console.WriteLine("===|| 이 름 ||==========|| 상 품 명||=========|| 가 격||=========|| 옵 션 ||========");

                        inven.Sort((x, y) => x.Type.CompareTo(y.Type));
                        for (int i = 0; i < inven.Count; i++)
                        {
                            if (inven[i].Type == ItemType.ingredient)
                            {

                                if (i >= 10)
                                    Console.Write($"{i + 1}. ");
                                else
                                    Console.Write($" {i + 1}. ");
                                inven[i].PrintItemData();
                            }
                        }

                        /* //월래 작성된 구간
                        for (int i = 0; i < inven.Count; i++)
                        {
                            if (inven[i].Type == ItemType.activeitem)
                            {
                                if (i >= 10)
                                    Console.Write($"{i + 1}. ");
                                else
                                    Console.Write($" {i + 1}. ");
                                inven[i].PrintItemData();
                            }
                        }
                        */
                        Console.WriteLine(" ");             //추가로 진행할 수 있는 기능 출력

                        Console.WriteLine("0. 나가기");
                        Console.WriteLine("1. 당근마켓에 아이템 팔기");
                        Console.WriteLine(" ");
                        Console.WriteLine("원하시는 행동을 입력하시오");
                        Console.WriteLine();

                        input = CheckInput(0, 1);

                        switch (input)
                        {
                            case 0:
                                DisplayHome();
                                break;
                            case 1:
                                DisplayItemSell();
                                break;

                        }

                        Console.Clear();
                        break;
                    }

            }

        }

        public static void DisplayShop()        //아이템 상점화면 출력 
        {
            Console.Clear();

            Console.WriteLine($"현재 보유금액 : {Player.GetInst.Money}");
            Console.WriteLine("필요한 물품을 사기 위해 핸드폰을 킨다. 어떤 사이트에 들어갈까?");
            Console.WriteLine();
            Console.WriteLine("1. 다나와에 들어가서 키보드(무기) 를 구입한다.");
            Console.WriteLine("2. 네이버 스토어에 들어가서 마우스(보조무기) 를 구입한다.");
            Console.WriteLine("3. 무신사에 들어가서 옷(방어구) 를 구입한다.");
            Console.WriteLine("4. 11번가에 들어가서 이어폰(방패) 를 구입한다.");
            Console.WriteLine("5. 쿠팡에 들어가서 여러가지 물건(엑세서리) 를 보고 구입한다.");
            Console.WriteLine("6. GS25에 들어가서 소모품을 구입한다.");
            Console.WriteLine();
            Console.WriteLine("0. 다음을 기약하며 핸드폰을 끈다.");

            int input = CheckInput(0, 6);

            switch (input)
            {
                case 0:
                    DisplayHome();
                    break;
                case 1:
                    DisplayWeaponShop();
                    break;
                case 2:
                    DisplaySubweaponShop();
                    break;
                case 3:
                    DisplayArmorShop();
                    break;
                case 4:
                    DisplayShieldShop();
                    break;
                case 5:
                    DisplayAccessoryShop();
                    break;
                case 6:
                    DisplayDrinkShop();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;

            }

        }

        public static void DisplayWeaponShop()      //무기상점 출력
        {
            Console.Clear();

            Console.WriteLine($"현재 보유금액 : {Player.GetInst.Money}");
            Console.WriteLine("구입하려는 키보드를 선택하세요.");
            Console.WriteLine();
            Console.WriteLine("===========|| 상 품 명||=====================|| 가 격||=========|| 옵 션 ||========");
            List<Item> items = DataManager.GetItemsByType(ItemType.Weapon);
            for (int i = 0; i < items.Count; i++)     //아이템 고유번호 1~5번까지 아이템 데이터 출력
            {
                Console.Write("{0}.  ", i + 1);
                items[i].PrintItemData();
            }

            Console.WriteLine("0. 다음을 기약하며 핸드폰을 끈다.");
            Console.WriteLine();
            Console.WriteLine("구매를 원하는 키보드의 번호를 입력하세요.");


            BuyItem(items);
        }

        public static void DisplaySubweaponShop()       //보조무기 상점화면 출력
        {
            Console.Clear();

            Console.WriteLine($"현재 보유금액 : {Player.GetInst.Money}");
            Console.WriteLine("구입하려는 마우스를 선택하세요.");
            Console.WriteLine();
            Console.WriteLine("===========|| 상 품 명||=====================|| 가 격||=========|| 옵 션 ||========");
            List<Item> items = DataManager.GetItemsByType(ItemType.SubWeapon);
            for (int i = 0; i < items.Count; i++)                //보조무기 아이템 데이터 출력
            {
                Console.Write("{0}.  ", i + 1);
                items[i].PrintItemData();
            }
            Console.WriteLine("0. 다음을 기약하며 핸드폰을 끈다.");
            Console.WriteLine();
            Console.WriteLine("구매를 원하는 마우스의 번호를 입력하세요.");


            BuyItem(items);
        }

        public static void DisplayArmorShop()       //갑옷 상점 출력, 기능은 다른 상점과 동일함
        {
            Console.Clear();

            Console.WriteLine($"현재 보유금액 : {Player.GetInst.Money}");
            Console.WriteLine("구입하려는 옷을 선택하세요.");
            Console.WriteLine();
            Console.WriteLine("===========|| 상 품 명||=====================|| 가 격||=========|| 옵 션 ||========");
            List<Item> items = DataManager.GetItemsByType(ItemType.Armor);
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write("{0}.  ", i + 1);
                items[i].PrintItemData();
            }

            Console.WriteLine("0. 다음을 기약하며 핸드폰을 끈다.");
            Console.WriteLine();
            Console.WriteLine("구매를 원하는 옷의 번호를 입력하세요.");


            BuyItem(items);
        }

        public static void DisplayShieldShop()      //방어구 상점 출력, 기능 동일
        {
            Console.Clear();

            Console.WriteLine($"현재 보유금액 : {Player.GetInst.Money}");
            Console.WriteLine("구입하려는 이어폰을 선택하세요.");
            Console.WriteLine();
            Console.WriteLine("===========|| 상 품 명||=====================|| 가 격||=========|| 옵 션 ||========");
            List<Item> items = DataManager.GetItemsByType(ItemType.Shield);
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write("{0}.  ", i + 1);
                items[i].PrintItemData();
            }
            Console.WriteLine("0. 다음을 기약하며 핸드폰을 끈다.");
            Console.WriteLine();
            Console.WriteLine("구매를 원하는 이어폰의 번호를 입력하세요.");


            BuyItem(items);
        }

        public static void DisplayAccessoryShop()       //장신구 상점 출력, 기능은 동일
        {
            Console.Clear();

            Console.WriteLine($"현재 보유금액 : {Player.GetInst.Money}");
            Console.WriteLine("구입하려는 꿀템을 선택하세요.");
            Console.WriteLine();
            Console.WriteLine("===========|| 상 품 명||=====================|| 가 격||=========|| 옵 션 ||========");
            List<Item> items = DataManager.GetItemsByType(ItemType.Accessory);
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write("{0}.  ", i + 1);
                items[i].PrintItemData();
            }

            Console.WriteLine("0. 다음을 기약하며 핸드폰을 끈다.");
            Console.WriteLine();
            Console.WriteLine("구매를 원하는 꿀템의 번호를 입력하세요.");


            BuyItem(items);
        }

        public static void DisplayDrinkShop()       //물약 상점 출력, 기능은 동일
        {
            Console.Clear();

            Console.WriteLine($"현재 보유금액 : {Player.GetInst.Money}");
            Console.WriteLine("구입하려는 꿀템을 선택하세요.");
            Console.WriteLine();
            Console.WriteLine("===========|| 상 품 명||=====================|| 가 격||=========|| 옵 션 ||========");
            List<Item> items = DataManager.GetItemsByType(ItemType.activeitem);
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write("{0}.  ", i + 1);
                items[i].PrintItemData();
            }
            Console.WriteLine("0. 다음을 기약하며 핸드폰을 끈다.");
            Console.WriteLine();
            Console.WriteLine("구매를 원하는 꿀템의 번호를 입력하세요.");


            BuyItem(items);
        }

        public static void DisplayBattleinventory() //전투도중 물약 사용
        {
            Console.Clear();

            Console.WriteLine("소유하고 있는 아이템을 확인합니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            Console.WriteLine("===|| 이 름 ||==========|| 상 품 명||=========|| 가 격||=========|| 옵 션 ||========");
            List<Item> inven = Player.GetInst.inventory;

            inven.Sort((x, y) => x.Type.CompareTo(y.Type));
            for (int i = 0; i < inven.Count; i++)
            {
                if (inven[i].Type == ItemType.activeitem)
                {
                    if (i >= 10)
                        Console.Write($"{i + 1}. ");
                    else
                        Console.Write($" {i + 1}. ");
                    inven[i].PrintItemData();
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("0. 사용하지 않기");
            Console.WriteLine("원하시는 행동을 입력하시오");
            Console.WriteLine();

            int input = CheckInput(0, inven.Count);
            input += 31;

            for (int i = 0; i < inven.Count; i++)
            {
                if (inven[i].Type == ItemType.activeitem)
                {
                    if (inven[i].ID == input)
                    {
                        inven[i].UseactiveItem();
                    }
                }
            }
            
            /*inven[i].UseactiveItem(inven); // 포션 사용*/

            Console.Clear();
        }

        /*
        public static void DisplayDrinkShop()       //소모품 상점 출력, 기능은 동일 임시구현
        {
            Console.Clear();

            int input = 0;

            Console.WriteLine($"현재 보유금액 : {Player.GetInst.Money}");
            Console.WriteLine("구입하려는 꿀템을 선택하세요.");
            Console.WriteLine();
            for (int i = 0; i < UseItem.useitems.Length; i++)
            {
                Console.Write("{0}. ", i + 1);
                UseItem.useitems[i].PrintItemDate();
            }
            Console.WriteLine("0. 살게 없내.. 집으로 돌아간다.");
            Console.WriteLine();
            Console.WriteLine("구매를 원하는 꿀템의 번호를 입력하세요.");

            input = int.Parse(Console.ReadLine());

            UseItem.BuyuseItem(input);
        }*/


        public static void BuyItem(List<Item> items) 
        {
            int input = CheckInput(0, items.Count);

            switch (input) {
                case 0:
                    DisplayHome();
                    break;
                default:
                    Player.GetInst.BuyItem(items[input - 1]);
                    break;
            }
        }

        public static void DisplayItemEquip()       //아이템 장착관리 선택시 출력되는 화면
        {
            Console.WriteLine("장착하려는 아이템의 번호를 입력해주세요.");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            int input = CheckInput(0, Player.GetInst.inventory.Count);        //장착을 원하는 아이템 선택시 선택 숫자를 idx로 받아 아이템 장착 메소드 출력

            switch (input)
            {
                case 0://장착을 원하는 아이템 선택시 선택 숫자를 idx로 받아 아이템 장착 메소드 출력
                    DisplayHome();
                    break;
                default:
                    //Item.EquipItem(input);
                    Player.GetInst.EquipItem(Player.GetInst.inventory[input - 1]);
                    DisplayInventory();
                    break;
            }
        }

        public static void DisplayItemSell()        //아이템 판매 선택시 출력되는 화면
        {
            Console.WriteLine("판매하려는 아이템의 번호를 입력해주세요.");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            int input = CheckInput(0, Player.GetInst.inventory.Count);        //판매를 원하는 아이템 선택시 번호를 idx로 받아 아이템 판매 메소드 출력

            switch (input)
            {
                case 0:
                    DisplayHome();
                    break;
                default:
                    Player.SellItem(Player.GetInst.inventory[input - 1]);
                    DisplayInventory();
                    break;
            }
        }



        public static void DisplayCommunity()       //커뮤니티 화면 출력
        {
            Console.Clear();
            Console.WriteLine("ticket을 5개 소비하고 만나고자 하는 지인을 선택하세요");
            Console.WriteLine($"보유티켓 : {Player.GetInst.ticket}");

            if (Player.GetInst.ticket < 5)          //커뮤니티 진행은 티켓이 5개 소비되므로 5개 이하 소지시 로비로 돌아가도록 설정
            {
                Console.WriteLine("티켓이 부족합니다. 엔터를 누르면 집으로 돌아갑니다.");
                Console.ReadKey();
                DisplayHome();

            }
            else
            {
                //티켓이 5개 이상이라면 선택지 출력
            }
            {
                Console.WriteLine("1. 부모님");
                Console.WriteLine("2. 학창시절 친구");
                Console.WriteLine("3. 직장 동료");
                Console.WriteLine("4. 대학교 동기");
                Console.WriteLine("5. 랜덤채팅");
                Console.WriteLine("0. 오늘은 집에서 쉬도록 하자!");


                int input = CheckInput(0, 5);
                int num = input + 25;       //커뮤니티 진행시 획득하는 아이템 고유번호가 26~30이므로 
                Random random = new Random();
                int Randomcout = random.Next(1,3);


                switch (input)
                {
                    case 0:
                        DisplayHome();
                        break;
                    case 1:      //티켓을 소비하고 아이템 획득 및 자동장착
                        Player.GetInst.ticket -= 5;
                        Console.WriteLine("사랑하는 부모님과 식사를 하며 응원과 지지를 받습니다.");
                        Console.WriteLine("황금 르탄이 포인트키캡 획득 - 모든 스텟 +10");
                        Console.ReadKey();
                        DisplayHome();
                        break;
                    case 2:
                        Player.GetInst.ticket -= 5;
                        Console.WriteLine("학창시절 친구와 술 한잔 하며 좋은 기운을 받습니다.");
                        Console.WriteLine("힘자랑하는 르탄이 포인트키캡 획득 - 공격력 +10");
                        Console.ReadKey();
                        DisplayHome();
                        break;
                    case 3:
                        Player.GetInst.ticket -= 5;
                        Console.WriteLine("직장 동료와 만나 친해지며 사이가 돈독해집니다.");
                        Console.WriteLine("잠자는 르탄이 포인트키캡 획득 - 방어 +10");
                        Console.ReadKey();
                        DisplayHome();
                        break;
                    case 4:
                        Player.GetInst.ticket -= 5;
                        Console.WriteLine("대학시절 동기를 만나 최신동향 정보와 꿀팁을 공유합니다.");
                        Console.WriteLine("달리는 르탄이 포인트키캡 획득 - 체력 +10");
                        Console.ReadKey();
                        DisplayHome();
                        break;
                    case 5:
                        Player.GetInst.ticket -= 5;
                        if (Randomcout == 1)
                        {
                            Console.WriteLine("랜덤채팅에서 이상한 사람을 만나 큰일날 뻔 했지만 겨우 도망쳤습니다.");
                            Console.WriteLine("꼴받는 르탄이 포인트키캡 획득 - 모든 스텟 -10");
                            Console.ReadKey();
                        }
                        else if (Randomcout == 2)
                        {
                            Console.WriteLine("랜덤채팅에서 과거의 전설적인 디렉터를 만났습니다.");
                            Console.WriteLine("외계인안경쓴 르탄이 포인트키캡 획득 - 모든 스텟 +20");
                            num = 31;
                            Console.ReadKey();
                        }
                        DisplayHome();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;

                }

                Player.GetInst.inventory.Add(DataManager.Items[num]); //아이템 추가
                DataManager.Items[num].Have = true;
                Player.GetInst.EquipItem(DataManager.Items[num]);
            }
        }

        public static void DisplayQuest() {
            Console.Clear();
            Console.WriteLine("업무!!");
            Console.WriteLine();
            List<Quest> questlist = DataManager.QuestList;
            for(int i = 0; i < questlist.Count; ++i) {
                Console.WriteLine($"{i + 1}. " + questlist[i].questName);
            }
            Console.WriteLine();
            Console.WriteLine("0. 돌아가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 퀘스트를 선택해주세요");
            Console.Write(">> ");
            int input = CheckInput(0, questlist.Count);       //입력하는 숫자에 따라 화면 출력

            switch (input) {
                case 0:
                    DisplayHome();
                    break;
                default:
                    questlist[input - 1].DisplayQuestBoard();
                    break;
            }
        }


        public static int CheckInput(int min, int max)      //입력 숫자를 판단하는 함수
        {
            while (true)
            {

                string input = Console.ReadLine();      //입력받은 값을 input에 문자로 저장

                if (input == "attack")
                    Cheat.Attack();
                else if (input == "defend")
                    Cheat.Defend();
                else if (input == "health")
                    Cheat.Health();
                else if (input == "level")
                    Cheat.Level();
                else if (input == "money")
                    Cheat.Level();
                else
                {
                    bool parseSuccess = int.TryParse(input, out var select);        //예외처리 진행하며 입력받은 값 int 변환

                    if (parseSuccess)   //변수 입력이 제대로 되었을 때
                    {
                        if (select >= min && select <= max)     //입력값이 선택창의 최소, 최대 범위안에 속할 때
                            return select;
                        else
                            Console.WriteLine("입력값이 잘못되었습니다. 올바른 범위의 숫자를 입력해주세요!");
                    }
                    else
                        Console.WriteLine("입력값이 잘못되었습니다. 다시 입력해주세요!");  //아니라면 오류문구 출력

                }


              
            }


        }
    }


}