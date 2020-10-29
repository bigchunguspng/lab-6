using System;
using System.Collections.Generic;
using System.IO;

namespace Task_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + @"\media";
            
            var directory = new DirectoryInfo(path);
            var playlist = new List<PlayerItem>();
            var files = directory.GetFiles();

            while (true)
            {
                Console.Clear();
                for (var i = 0; i < files.Length; i++)
                {
                    playlist.Add(new PlayerItem(files[i].FullName, files[i].Name));
                    Display($"{i}. {playlist[i].Name}");
                }
                
                IMedia media;
                int number;
                do Display("Виберіть файл за номером (-1 для виходу): ", ConsoleColor.DarkGray);
                while (!Int32.TryParse(Console.ReadLine(), out number));
                if (number < 0 || number >= playlist.Count)
                    break;

                var selectedItem = playlist[number];
                Display("Вибрано: " + selectedItem.Name);
                switch (selectedItem.Extension)
                {
                    case "mp3":
                        media = new Mp3(selectedItem.Name);
                        break;
                    case "mkv":
                        media = new Mkv(selectedItem.Name);
                        break;
                    case "wav":
                        media = new Wav(selectedItem.Name);
                        break;
                    default:
                        media = null;
                        Display("Невідповідний тип файлу", ConsoleColor.Red);
                        break;
                }

                if (media == null)
                    break;

                media.AskWhenSelected();

                while (true)
                {
                    Display((media.Paused ? "(В)ідновити" : "(П)ауза") + " (С)топ", ConsoleColor.DarkGray);
                    string action = Console.ReadLine()?.ToLower().Replace('в', 'п');
                    switch (action)
                    {
                        case "п":
                            media.Pause();
                            break;
                        case "с":
                            media.Stop();
                            break;
                        default:
                            Display("Незрозуміла команда", ConsoleColor.DarkGray);
                            break;
                    }

                    if (action != null && action.Equals("с"))
                        break;
                }
            }
        }
        
        public static void Display(string text, ConsoleColor color = ConsoleColor.Magenta)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text.Replace('і', 'i').Replace('І','I'));
            Console.ResetColor();
        }
    }
}