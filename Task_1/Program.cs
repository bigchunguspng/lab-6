using System;

namespace Lab_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //D:\Desktop\Новий текстовий документ.txt
            //D:\Desktop\Новий документ.docx
            
            string fileType = "";
            while (fileType != "й")
            {
                Print("З яким форматом будете працювати? .(d)ocx .(t)xt");
                fileType = Console.ReadLine()?.ToLower();
                
                switch (fileType)
                {
                    case "d":
                        ActionLoop(new Docx());
                        break;
                    case "t":
                        ActionLoop(new Txt());
                        break;
                    case "й":
                        break;
                    default:
                        Print(@"Натисніть літеру в дужках для вибору формату, або ""й"" для виходу");
                        break;
                }
            }
        }

        private static void ActionLoop(AbstractHandler handler)
        {
            string actionID = "";
            while (actionID != "й")
            {
                Print("Виберіть дію: (В)ідкрити (Р)едагувати Ви(й)ти");
                actionID = Console.ReadLine()?.ToLower();
                switch (actionID)
                {
                    case "в":
                        handler.Open();
                        break;
                    case "р":
                        handler.Edit();
                        break;
                    case "й":
                        break;
                    default:
                        Print("Натисніть літеру в дужках для вибору дії");
                        break;
                }
            }
        }

        public static void Print(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text.Replace('і', 'i'));
            Console.ResetColor();
        }
    }
}