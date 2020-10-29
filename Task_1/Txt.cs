using System;
using System.IO;
using static Lab_6.Program;

namespace Lab_6
{
    public class Txt : AbstractHandler
    {
        private readonly string _path;

        public Txt()
        {
            Print("Введіть повний шлях файлу:");
            _path = Console.ReadLine();
            Create();
        }

        public override void Open()
        {
            Print("Текст файлу:");
            Console.WriteLine(File.ReadAllText(_path));
        }

        public sealed override void Create()
        {
            if (_path.EndsWith(".txt"))
            {
                File.Create(_path).Dispose();
                Print("Створено файл " + _path);
            }
            else
                Print("Вказано незрозуміле ім'я файлу");
        }

        public override void Edit()
        {
            Print("Введіть текст (буде додано в кінець):");
            using (StreamWriter writer = File.AppendText(_path)) 
                writer.WriteLine(Console.ReadLine());
        }
    }
}