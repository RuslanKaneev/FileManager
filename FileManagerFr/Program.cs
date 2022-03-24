using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerFr
{    
    internal class Program
    {       // в enum - будет 2 состояния - выбрана работа с файлами или с каталогом, переключение tab 
        enum Fokus
        {
            Folder = 1,
            File = 2
        }

        public class State
        {

            public int elementCount = 0;

            public static int lengthDirectory = 0;
            //сохраняем путь выбранного файла
            public static string fileSave = String.Empty;


            //сохраняем путь выбраной директории
            public static string directorySave = String.Empty;
            public static string copyDirectory = String.Empty;
            //текущая директория
            public static string currentDirectory = @"D:\1";
            //куда сохраняем путь к файлу состояния
            public static string saveExitFile = @"D:\save.txt";
            public static string logException = @"D:\log.txt";
            public static bool escapeExit = false;

        }
        private static State myState = new State();

        private const int MaxLvl = 2;




        static void Main(string[] args)
        {

            //по умолчанию выбрана работа с файлами
            Fokus tabFokus = Fokus.Folder;
            Properties.Settings.Default.UserName = Console.ReadLine();
            int numberLinesPage = Properties.Setting.Default.numberLinesPage;



            //метод вывода дерева каталогов

             void DirectoryOutput(string path, int level)
            {
                //ограничение по выводу - 2 уровня
                if (level > MaxLvl)
                {
                    return;
                }
                try
                {
                    string[] dirs = Directory.GetDirectories(path);



                    for (int i = 0; i < dirs.Length; i++)
                    {

                        var levelUp = level > MaxLvl ? MaxLvl : level;
                        //чтобы дерево каталогов было более наглядней
                        Console.Write(string.Concat(Enumerable.Repeat("--------", levelUp)));
                        //оставляем относительный путь
                        Console.WriteLine(dirs[i].Replace(path, ""));

                        DirectoryOutput(dirs[i], level + 1);

                    }

                }
                catch (Exception directoryOutExc)
                {

                    File.AppendAllText(State.logException, Convert.ToString(directoryOutExc));


                }

            }



            //метод вы подсветки строки при движении стрелок вверх-вниз для файлов

             void RowHighlighting(string path, int currentIndex, int numberPage)
            {

                Console.Clear();
                Console.WriteLine("Добро пожаловать в файловый менеджер\n");

                Console.WriteLine("кнопка TAB - переключение между папками и файлами \ncтрелки вверх-вниз навигация по  файлам \nкнопка ESC - выход из программы \ncтрелки влево-вправо пейджинг по страницам файлов \nкнопка DELETE - удаление файла \nкнопка F5 - копирование файла \nкнопка Backspace - подняться в каталоге выше \nкнопка Enter - открыть файл\nкнопка F1 - сменить директорию\n");
                try
                {


                    string[] files = Directory.GetFiles(path);
                    // считаю как ограничить пейджинг и организовать вывод и чтобы последняя страница коррект
                    var numberLinesPage = 5;
                    var startElementNumber = numberLinesPage * numberPage;
                    var elementsOnPage = files.Length - startElementNumber;

                    if (elementsOnPage > numberLinesPage)
                    {
                        elementsOnPage = numberLinesPage;
                    }
                    myState.elementCount = elementsOnPage;
                    Console.WriteLine(path);

                    for (int i = startElementNumber; i < startElementNumber + elementsOnPage; i++)
                    {
                        if (startElementNumber + currentIndex == i)
                        {  //подсветка строки
                            ConsoleColor current = Console.BackgroundColor;

                            Console.BackgroundColor = ConsoleColor.Green;

                            FileInformation(files[i]);

                            Console.BackgroundColor = current;
                            //сохраняем путь к выбранному файлу

                            State.fileSave = files[i];

                        }
                        else
                        {
                            FileInformation(files[i]);
                        }

                    }

                }
                catch (Exception rowHighlightingExc)
                {
                    File.AppendAllText(State.logException, Convert.ToString(rowHighlightingExc));
                }

            }

            //метод по подсветки строки при движении стрелок вверх-вниз для каталогов

            static void DirectoryArrows(string path, int currentIndexDirectory)
            {

                Console.Clear();
                Console.WriteLine("Добро пожаловать в файловый менеджер\n");
                Console.WriteLine("кнопка TAB - переключение между папками и файлами \ncтрелки вверх-вниз навигация по папкам и файлам \nкнопка ESC - выход из программы) \ncтрелки влево-вправо пейджинг по страницам файлов \nкнопка DELETE - удаление файла или папки \nкнопка F5 - копирование файла или папки \nкнопка Backspace - подняться в каталоге выше \nкнопка Enter -  опуститься в текущую папку\nкнопка F1 - сменить директорию\n");
                Console.WriteLine(path);
                try
                {
                    string[] dirs = Directory.GetDirectories(path);

                    for (int i = 0; i < dirs.Length; i++)

                    {
                        if (currentIndexDirectory == i)
                        {
                            ConsoleColor current = Console.BackgroundColor;

                            Console.BackgroundColor = ConsoleColor.Green;
                            DirectoryInformation(dirs[i]);

                            Console.BackgroundColor = current;
                            //сохраняем количество папок, потом будем использовать для ограничения перемещения стрелки
                            State.lengthDirectory = dirs.Length;
                            //сохраняем путь выбранной папки
                            State.directorySave = dirs[i];
                            continue;
                        }
                        DirectoryInformation(dirs[i]);
                    }
                }
                catch (Exception directoryArrowsExc)
                {
                    File.AppendAllText(State.logException, Convert.ToString(directoryArrowsExc));
                }

            }






            //метод вывода информации о файле

            static void FileInformation(string file)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"{fileInfo.FullName}  {fileInfo.Length} bytes");
                }
                catch (Exception fileInformationExc)
                {
                    File.AppendAllText(State.logException, Convert.ToString(fileInformationExc));
                }

            }

            //метод вывода информации о директории
            static void DirectoryInformation(string path)
            {
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    Console.WriteLine($"{directoryInfo.FullName}  {directoryInfo.Parent} {directoryInfo.LastWriteTime} ");
                }
                catch (Exception directoryInformationExc)
                {
                    File.AppendAllText(State.logException, Convert.ToString(directoryInformationExc));
                }
            }

            // метод для определения - максимального количества страниц файлов.
            // Далее использую его при пейджинге
            static int CountPageLimitFile(string path, int numberLinesPage)
            {
                return (int)Math.Ceiling((double)(Directory.GetFiles(path).Length / numberLinesPage));


            }



            //метод копирования каталогов
            void CopyDirectory(string oldDir, string newDir)
            {
                try
                {


                    Directory.CreateDirectory(newDir);

                    string[] filesCopy = Directory.GetFiles(oldDir);
                    for (int i = 0; i < filesCopy.Length; i++)
                    {     // создаем новый путь к файлам
                        string fileCopyPath = newDir + "\\" + Path.GetFileName(filesCopy[i]);
                        File.Copy(filesCopy[i], fileCopyPath, true);
                    }
                    string[] dirsCopy = Directory.GetDirectories(oldDir);
                    for (int i = 0; i < dirsCopy.Length; i++)
                    {   // создаем новый путь к папкам
                        string fileCopyPath = newDir + "\\" + Path.GetFileName(dirsCopy[i]);
                        CopyDirectory(dirsCopy[i], fileCopyPath);
                    }
                }
                catch (Exception copyDirectoryExc)
                {
                    File.AppendAllText(State.logException, Convert.ToString(copyDirectoryExc));
                }


            }




            int level = 1;
            int currentIndex = 0;
            int numberPage = 0;
            int currentIndexDirectory = 0;

            //если файл существует, значит мы уже сохранили при выходе путь- открытой на тот момент директории


            if (File.Exists(State.saveExitFile) == true)

            {   //считали путь из файла       
                State.currentDirectory = File.ReadAllText(State.saveExitFile, Encoding.UTF8);
            }

            //выводим текущий каталог
            DirectoryArrows(State.currentDirectory, currentIndexDirectory);


            while (true)

            {  //чтобы выйти из while

                if (State.escapeExit)
                {
                    break;
                }
                //вывод дерева каталогов 2 уровня
                DirectoryOutput(State.currentDirectory, level);




                ConsoleKeyInfo thePressedKey = Console.ReadKey();

                switch (thePressedKey.Key)
                {
                    //идем вверх окрашенной строкой по файлам
                    case ConsoleKey.UpArrow:
                        {
                            if (tabFokus == Fokus.File)
                            {

                                if (currentIndex > 0)
                                {
                                    currentIndex--;
                                }

                                RowHighlighting(State.currentDirectory, currentIndex, numberPage);
                            }
                            //идем вверх окрашенной строкой по папкам
                            else
                            {
                                if (currentIndexDirectory > 0)
                                {
                                    currentIndexDirectory--;
                                }

                                DirectoryArrows(State.currentDirectory, currentIndexDirectory);
                            }


                        }
                        break;
                    //идем вниз окрашенной строкой по файлам
                    case ConsoleKey.DownArrow:
                        {

                            if (tabFokus == Fokus.File)
                            {   // ограничение, что если кончились файлы строка не улетала вниз
                                if (currentIndex < myState.elementCount - 1)
                                {
                                    currentIndex++;
                                }

                                RowHighlighting(State.currentDirectory, currentIndex, numberPage);
                            }
                            //идем вниз окрашенной строкой по папкам
                            else
                            {    // ограничение, что если кончились папки строка не улетала вниз
                                if (currentIndexDirectory < State.lengthDirectory - 1)
                                {
                                    currentIndexDirectory++;
                                }
                                DirectoryArrows(State.currentDirectory, currentIndexDirectory);
                            }


                        }
                        break;
                    //спуск ниже по директории если в папке и открытие файла - если таргет на файле
                    case ConsoleKey.Enter:
                        {   // если в файле пробуем открыть
                            if (tabFokus == Fokus.File)
                            {
                                try
                                {
                                    string file = Directory.GetFiles(State.currentDirectory)[currentIndex];
                                    Process.Start(new ProcessStartInfo() { FileName = file, UseShellExecute = true });
                                }
                                catch (Exception fileProcExc)
                                {
                                    File.AppendAllText(State.logException, Convert.ToString(fileProcExc));
                                }
                            }
                            //если в папке
                            else
                            {

                                //устанавливаем текущим -выбранную папку, устанавливаем выделение строки в самый верх, выводим на экран открытую папку
                                State.currentDirectory = State.directorySave;
                                currentIndexDirectory = 0;
                                DirectoryArrows(State.currentDirectory, currentIndexDirectory);

                            }
                        }
                        break;
                    //удаление фалов и каталогов
                    case ConsoleKey.Delete:
                        {
                            if (tabFokus == Fokus.File)
                            {
                                try
                                {  //удаляем выделенный файл, перерисовываем заново файлы
                                    string file = Directory.GetFiles(State.directorySave)[currentIndex];
                                    File.Delete(file);
                                    RowHighlighting(State.directorySave, currentIndex, numberPage);

                                }

                                catch (Exception delFileExc)
                                {
                                    File.AppendAllText(State.logException, Convert.ToString(delFileExc));
                                }


                            }
                            else
                            {
                                try
                                {   //удаляем папку рекурсивно со всеми вложенными файлами и папками
                                    DirectoryInfo deliteDir = new DirectoryInfo(State.directorySave);
                                    deliteDir.Delete(true);
                                    DirectoryArrows(State.directorySave, currentIndexDirectory);
                                }
                                catch (Exception delDirExc)
                                {
                                    File.AppendAllText(State.logException, Convert.ToString(delDirExc));
                                }

                            }
                        }
                        break;


                    //копирование файлов и каталогов
                    case ConsoleKey.F5:
                        {    // когда фокус на файлах
                            if (tabFokus == Fokus.File)
                            {

                                Console.WriteLine("Введите путь куда хотите скопировать файл и его название");

                                try
                                {   // вводим полный путь файла и копируем его
                                    string? copyFileSave = Console.ReadLine();
                                    File.Copy(State.fileSave, copyFileSave, true);
                                }
                                catch (Exception copyFileExc)
                                {
                                    File.AppendAllText(State.logException, Convert.ToString(copyFileExc));
                                    Console.WriteLine("Повторите еще раз операцию копирования нажав F5 и введя корректный путь");
                                }
                            }
                            // когда фокус на папках
                            else
                            {
                                Console.WriteLine("Укажите полный путь, куда будет осуществленно копирование.\nЕсли указанной в пути папки нет, то файловый менеджер создаст ее. Пример: D:\\1 (без слеша в конце)");
                                try
                                {   //считываем выбранную директорию
                                    string copyDirectory = State.directorySave;
                                    // вводим путь сохранения файла и его название, вызываем метод копирование папки
                                    string? copyDirectorySave = Console.ReadLine();

                                    CopyDirectory(copyDirectory, copyDirectorySave);

                                }
                                catch (Exception copyDirExc)
                                {
                                    File.AppendAllText(State.logException, Convert.ToString(copyDirExc));
                                    Console.WriteLine("Повторите еще раз операцию копирования нажав F5 и введя корректный путь");
                                }


                            }


                        }
                        break;

                    case ConsoleKey.F12:
                        {

                        }
                        break;

                    case ConsoleKey.F1:
                        {
                            Console.WriteLine("Введите необходимую директорию(Пример E:\\c#) ");
                            try
                            {
                                State.currentDirectory = Console.ReadLine();
                                DirectoryArrows(State.currentDirectory, currentIndexDirectory);
                            }
                            catch (Exception changeDirExc)
                            {

                                Console.WriteLine("Нажмите F1 и Введите корректный путь");
                                File.AppendAllText(State.logException, Convert.ToString(changeDirExc));
                            }

                        }
                        break;

                    //переключение TAB между файлами и папками, отрисовка 
                    case ConsoleKey.Tab:
                        {

                            if (tabFokus == Fokus.File)
                            {
                                tabFokus = Fokus.Folder;
                                DirectoryArrows(State.currentDirectory, currentIndexDirectory);

                            }
                            else
                            {
                                tabFokus = Fokus.File;
                                RowHighlighting(State.currentDirectory, currentIndex, numberPage);
                            }

                        }
                        break;
                    // пейджинг файлов с ограничением
                    case ConsoleKey.LeftArrow:
                        {
                            if (tabFokus == Fokus.File)
                            {
                                currentIndex = 0;
                                if (numberPage > 0)
                                    numberPage--;
                                RowHighlighting(State.currentDirectory, currentIndex, numberPage);
                            }
                            else
                            { //чтобы при случайном нажатии, когда фокус на директории - экран не засорялся
                                DirectoryArrows(State.currentDirectory, currentIndexDirectory);
                            }

                        }
                        break;
                    // пейджинг файлов с ограничением
                    case ConsoleKey.RightArrow:
                        {
                            if (tabFokus == Fokus.File)
                            {
                                currentIndex = 0;

                                if (CountPageLimitFile(State.currentDirectory, State.numberLinesPage) > numberPage)
                                {
                                    numberPage++;
                                }
                                RowHighlighting(State.currentDirectory, currentIndex, numberPage);
                            }
                            else
                            { //чтобы при случайном нажатии, когда фокус на директории - экран не засорялся
                                DirectoryArrows(State.currentDirectory, currentIndexDirectory);
                            }


                        }
                        break;

                    //переход в директории на уровень вверх
                    case ConsoleKey.Backspace:
                        {

                            DirectoryInfo parentDirectory = new DirectoryInfo(State.currentDirectory);

                            string parentDirectoryString = Convert.ToString(parentDirectory);

                            int parentDirectoryLength = parentDirectoryString.Length;
                            try
                            {
                                if (parentDirectoryLength >= 4)
                                {
                                    State.copyDirectory = parentDirectory.Parent.FullName;

                                }
                            }
                            catch (Exception UpDirExc)
                            {
                                State.copyDirectory = State.currentDirectory;


                                File.AppendAllText(State.logException, Convert.ToString(UpDirExc));
                            }


                            DirectoryArrows(State.copyDirectory, currentIndexDirectory);
                            State.currentDirectory = State.copyDirectory;
                        }
                        break;
                    //выход из программы
                    case ConsoleKey.Escape:

                        {
                            try
                            {
                                //записываю в файл путь текущей директории
                                File.WriteAllText(State.saveExitFile, State.currentDirectory);
                                //чтобы выйти и из второго цикла значение меняю escapeExit
                                State.escapeExit = true;
                            }
                            catch (Exception saveFileExc)
                            {
                                File.AppendAllText(State.logException, Convert.ToString(saveFileExc));
                            }
                            break;


                        }


                    default:
                        {
                        }
                        break;

                }


            }


        }


















    }
}
}
