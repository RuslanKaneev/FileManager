using System.IO;
using System.Diagnostics;

namespace FileManager
{
    class Program
    {
        /*
         *
         * File.Delete(@"c:\autoexec.bat");
            File.Copy(@"c:\autoexec.bat", @"d:\autoexec_222.bat");

            Directory.CreateDirectory(@"c:\fooo");
            Directory.Delete(@"c:\fooo");

            string[] files = Directory.GetFiles(@"c:\foo");
            string[] dirs = Directory.GetDirectories(@"c:\foo");
         *
         */

        static void Main(string[] args)
        {

            /*

            return;

            string path = @"D:\NWN\NWN2 Complete";

            int currentIndex = 0;

            PrintFiles(0);

            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();

                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentIndex > 0)
                            {
                                currentIndex--;
                            }

                            PrintFiles(currentIndex);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            currentIndex++;

                            PrintFiles(currentIndex);
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            string file = Directory.GetFiles(path)[currentIndex];


                            Process.Start(new ProcessStartInfo() { FileName = file, UseShellExecute = true });
                        }
                        break;
                }
            }


            string currentCmd = string.Empty;
            /*
            while (true)
            {
                currentCmd = Console.ReadLine();

                if (currentCmd == "quit")
                {
                    return;
                }

                int page = int.Parse(currentCmd);

                int pageSize = 5;

                int skipFiles = pageSize * page;

                int maxFilesToShow = skipFiles + pageSize;

                for (int i = skipFiles; i < maxFilesToShow; i++)
                {
                    string[] files = Directory.GetFiles(path);

                    if (files.Length <= i)
                    {
                        break;
                    }

                    Console.WriteLine(files[i]);
                }

            }
        */
            /*
            public static void PrintFiles(int currentIndex)
            {
                string path = @"D:\NWN\NWN2 Complete";

                Console.Clear();

                string[] files = Directory.GetFiles(path);

                for (int i = 0; i < files.Length; i++)
                {
                    if (currentIndex == i)
                    {
                        ConsoleColor current = Console.BackgroundColor;

                        Console.BackgroundColor = ConsoleColor.Yellow;

                        PrintFile(files[i]);

                        Console.BackgroundColor = current;

                        continue;
                    }

                    PrintFile(files[i]);
                }
            }

            public static void PrintFile(string file)
            {
                FileInfo info = new FileInfo(file);

                Console.WriteLine($"{info.FullName} {info.Length} bytes");
            }

            /*
             * c:\
             *    c:\windows\
             *        c:\windows\fonts
             *        c:\windows\temp
             *    c:\games
             *
             */
            /*
                    public static void PrintDir(string directory, int level)
                    {
                        string[] dirs = Directory.GetDirectories(directory);

                        for (int i = 0; i < dirs.Length; i++)
                        {
                            string childDir = dirs[i];

                            for (int z = 0; z < level; z++)
                            {
                                Console.Write("\t");
                            }

                            Console.WriteLine(childDir);

                            PrintDir(childDir, level + 1);
                        }
                    }

                    */


            string path = @"D:\NWN\NWN2 Complete\Effects";
            
            while (true)
            {
                string teamCmd = Console.ReadLine();
                var numberPage = Convert.ToInt32(teamCmd);
                var numberLinesPage = 10;
                var propagesViewed = numberLinesPage * numberPage;
                var maxPage = propagesViewed + numberLinesPage;
                for (int i = propagesViewed; i < maxPage; i++)
                {
                    string[] files = Directory.GetFiles(path);
                    if (files.Length <= i)
                    {
                        break;
                    }
                    Console.WriteLine(files[i]);
                }

                /*
                switch (teamCmd)
                {
                    default:
                        break;
                }
                */
            }
            Console.ReadLine();

        }
    }
}

