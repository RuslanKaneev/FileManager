// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
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
//ввод команд
/*              Console.WriteLine("Введите номер страницы cписка файлов или команды: \n Копирование каталога: cp k" +
"\n Копирование файла: cp f + указать путь сохранения" + "\n Удаление каталога: rm k" + "\n Удаление файла: rm f" +
"\n Вывод информации: file" + "\n Вывод дерева файловой системы: ls");*/
/*
switch (teamCmd)
{
    case "lc":

        {
            int i = 0;
            while (i >= 2)
            {
                Console.WriteLine("Введите количество отображаемых страниц файла");
                bool checkingTheCommandLs = int.TryParse(Console.ReadLine(), out int commandConsoles);
                if (checkingTheCommandLs == true)
                {
                    PageOutput(path, commandConsoles);
                }
                else
                {
                    Console.WriteLine("Введите количество отображаемых страниц файла или выйдите quit");

                    i++;
                    break;
                }


            }



        }
        break;

    case "cp k":
        {



        }
        break;

    case "cp f":
        {



        }
        break;

    case "rm k":
        {



        }
        break;

    case "rm f":
        {



        }
        break;
    case "file":
        {



        }
        break;


    case "quit":
        {

            return;

        }

    default:
        {

        }
        break;


}


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
