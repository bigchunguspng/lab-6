using System;
using System.IO;
using static Lab_6.Program;

namespace Lab_6
{
    public class Docx : AbstractHandler
    {
        private readonly string _path;

        public Docx()
        {
            Print("Введіть повний шлях файлу:");
            _path = Console.ReadLine();
            Create();
        }

        public override void Open()
        {
            Print("Вміст файлу:");
            Console.WriteLine(File.ReadAllText(_path));
        }

        public sealed override void Create()
        {
            if (_path.EndsWith(".docx"))
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
                writer.Write(" " + Console.ReadLine());
        }
    }
}