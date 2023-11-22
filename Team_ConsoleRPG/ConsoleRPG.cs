using System;
using NAudio.Wave;
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
            string filePath = "C:\\Users\\gunho\\Desktop\\music\\bgm.mp3"; // MP3 파일 경로를 지정하세요.

            using (var mp3Reader = new Mp3FileReader(filePath))
            {
                // WaveChannel32를 사용하여 소리 크기 조절
                var waveChannel = new WaveChannel32(mp3Reader);

                using (var waveOut = new WaveOutEvent())
                {
                    waveOut.Init(waveChannel);

                    // 소리 크기 조절
                    waveChannel.Volume = 0.03f; // 0.5는 반으로 줄이는 예시입니다.

                    waveOut.Play();
                    //게임시작점 - 아이템, 플레이어, 몬스터 데이터 세팅
                    DataManager.DataSetting();

                    if (!Player.GetInst.Load())
                        StartScene.StartMain();

                    GameManager.DisplayHome();      //게임메니저 호출하여 메인로비 호출

                    Console.WriteLine("음악 재생 중... (Press Enter to stop)");
                    Console.ReadLine();

                    waveOut.Stop();
                }
            }
        }

    }
}
