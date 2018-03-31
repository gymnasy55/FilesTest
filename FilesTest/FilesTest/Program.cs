using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;

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
                Console.WriteLine("Доступные каталоги: ");
                DirectoryInfo info = new DirectoryInfo(drives[disk - 1] + "\\");
                DirectoryInfo[] dirs = info.GetDirectories();
                counter = 1;
                foreach (var dr in dirs)
                {
                    Console.WriteLine(counter.ToString() + '-' + dr.Name);
                    counter++;
                }
                Console.Write("Введите номер каталога: ");
                int name;
                Int32.TryParse(Console.ReadLine(), out name);
                DirectoryInfo dir = new DirectoryInfo(drives[disk - 1] + "\\" + dirs[name-1] + "\\");
                Console.Write("Введите режим работы программы (0 - удаление всех файлов каталога, 1 - создание пяти файлов в каталоге): ");
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
                        Console.Write("Удаление файлов прошло успешно!\nНажмите любую клавишу...");
                    }
                    catch(Exception ex)
                    {
                        Console.Write("Произошла ошибка: ");
                        Console.Write(ex.Message+"\nНажмите любую клавишу...");
                    }
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            using (StreamWriter writer = new StreamWriter(dir.FullName + i.ToString() + ".ssp"))
                            {
                                writer.Write(i);
                                writer.Flush();
                                writer.Close();
                            }
                        }
                        Console.Write("Создание прошло успешно!\nНажмите любую клавишу...");
                    }
                    catch (Exception ex)
                    {
                        Console.Write("Произошла ошибка: ");
                        Console.Write(ex.Message + "\nНажмите любую клавишу...");
                    }
                }
            }
            else { Console.Write("Диски не доступны\nНажмите любую клавишу..."); }
            Console.ReadKey();
        }
    }
}
