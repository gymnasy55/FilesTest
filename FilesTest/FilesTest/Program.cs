using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FilesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доступные диски: ");
            string[] drives = Environment.GetLogicalDrives();
            if(drives != null)
            {
                int counter = 1;
                foreach (string s in drives)
                {
                    Console.WriteLine(counter.ToString() + '-' + s);
                    counter++;
                }
                Console.Write("Введите номер диска: ");
                int disk;
                Int32.TryParse(Console.ReadLine(), out disk);
                Console.Write("Введите название каталога: ");
                string name = Console.ReadLine();
                DirectoryInfo dir = new DirectoryInfo(drives[disk - 1] + "\\" + name + "\\");
                Console.Write("Введите режим работы программы (0 - удаление, 1 - создание пяти файлов): ");
                int mode;
                Int32.TryParse(Console.ReadLine(), out mode);
                if (mode == 0)
                {
                    try
                    {
                        foreach (FileInfo file in dir.GetFiles())
                        {
                            file.Delete();
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.Write("Произошла ошибка: ");
                        Console.WriteLine(ex.Message+"\nНажмите любую клавишу...");
                    }
                    Console.WriteLine("Удаление прошло успешно!\nНажмите любую клавишу...");
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            using (StreamWriter writer = new StreamWriter(dir.FullName + i.ToString() + ".txt"))
                            {
                                writer.Write(i);
                                writer.Flush();
                                writer.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write("Произошла ошибка: ");
                        Console.WriteLine(ex.Message + "\nНажмите любую клавишу...");
                    }
                    Console.WriteLine("Создание прошло успешно!\nНажмите любую клавишу...");
                }
            }
            else { Console.WriteLine("Диски не доступны"); }
            Console.ReadKey();
        }
    }
}
