using System;
using static Task_2.Program;

namespace Task_2
{
    public class Wav : IPlayable, IRecordable
    {
        private readonly string _filename;
        public bool Paused { get; set; }

        public Wav(string filename)
        {
            _filename = filename;
        }

        public void Pause()
        {
            Paused = !Paused;
            Display(Paused ? "Пауза" : "Відновлено");
        }

        public void Stop() => Display("Зупинено");

        public void Record() => Display("Іде запис " + _filename);

        public void Play() => Display("Ви зараз слухаєте " + _filename);

        public void AskWhenSelected()
        {
            Display("(В)ідтворити (З)аписати", ConsoleColor.DarkGray);
            string action = Console.ReadLine()?.ToLower();
            switch (action)
            {
                case "в":
                    Play();
                    break;
                case "з":
                    Record();
                    break;
                default:
                    Display("Незрозуміла команда", ConsoleColor.DarkGray);
                    break;
            }
        }
    }
}