using System;
using static Task_2.Program;

namespace Task_2
{
    public class Mkv : IPlayable
    {
        private readonly string _filename;
        public bool Paused { get; set; }

        public Mkv(string filename)
        {
            _filename = filename;
        }

        public void Pause()
        {
            Paused = !Paused;
            Display(Paused ? "Пауза" : "Відтворення відновлено");
        }

        public void Stop() => Display("Відтворення зупинено");

        public void Play() => Display("Ви дивитесь " + _filename);
        
        public void AskWhenSelected()
        {
            Display("Натисніть щоб відтворити", ConsoleColor.DarkGray);
            Console.ReadKey();
            Play();
        }
    }
}