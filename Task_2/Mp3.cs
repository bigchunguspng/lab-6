using System;
using static Task_2.Program;

namespace Task_2
{
    public class Mp3 : IRecordable
    {
        private readonly string _filename;
        public bool Paused { get; set; }

        public Mp3(string filename)
        {
            _filename = filename;
        }

        public void Pause()
        {
            Paused = !Paused;
            Display(Paused ? "Пауза" : "Запис відновлено");
        }

        public void Stop() => Display("Запис зупинено");

        public void Record() => Display("Іде запис " + _filename);
        
        public void AskWhenSelected()
        {
            Display("Натисніть щоб записати", ConsoleColor.DarkGray);
            Console.ReadKey();
            Record();
        }
    }
}