# Console File manager

### Консольный файловый менеджер начального уровня, который охватывает минимальный набор функций управления файлами и каталогами.
__Программа написана на платформе NET.CORE 6.0, версия C# 10

## Description
* В конфигурационном файле настраиваем вывод количества файлов на страницу.
* При выходе из программы сохраняется текущий прогресс.
* С помощью кнопок клавиатуры мы перемещаемся по файлам/папкам и выполняем действия над каталогами и файлами
## File manager options
#### Переключение между каталогами и файлами  - кнопка TAB
Переключаемся между отображением каталогов или файлов

#### Перемещение по каталогам и файлам - стрелки вверх-вниз (UpArrow,DownArrow) 
Перемещаемся по папкам в текущей директории или по файлам на странице 

#### Пейджинг страниц - стрелки влево-вправо (LeftArrow, RightArrow)
Листаем страницы с фалами в текущем каталоге с помощью стрелок влево-вправо.
Старт с самой первой по сортировке.

#### Перемещение вверх по директории - кнопка Backspace
Если выбрана работа с каталогами - перемещение по директории вверх.

#### Перемещение вниз по директории - кнопка Enter
Если выбрана работа с каталогами - перемещение по директории вниз.

#### Сменить диск или текущую директорию вручную - кнопка F1
Если мы работаем с каталогами, то если нажмем кнопку F1,  то у нас запросит ввести путь до нужного диска или директории.
После того как мы ввели полный путь (пример E:\\c#  - без слеша в конце) и нажали Еnter, то сменится текущая директория и отрисуется уже новая.

#### Удаление каталога или файлов - кнопка Delete
Если работаем с файлами, то удаляем выбранный файл, если с каталогами - то удаляем выбранный каталог.

#### Открываем файл  - кнопка Enter
Если выбрана работа с файлами, то нажатие кнопки Enter откроет файл - тем, чем он открывается по умолчанию.

#### Копируем файл или папку - кнопка F5
Если работаем с файлами, то когда мы выбрали нужный файл, нажав F5, то программа запросит ввод пути куда нужно скопировать файл. 
Нужно указать путь с новым названием файла в конце пути и его расширением.
(пример D:\с#\text.txt)
Если работаем с каталогами, то когда выбрали копироваемый файл и нажали F5, то программа запросит ввод пути куда нужно скопировать папку с вложениями. 
Если указанном пути папки нет, то файловый менеджер создаст ее. 
Пример: D:\\1 (без слеша в конце)

#### Информация о файле или каталоге  - кнопка F12
В зависимости от того с кем мы работаем, покажет информацию о файле или папке.

#### Выход из программы  - кнопка ESC
Нажав ESC выйдем из программы, но запомним последнее состояние, чтобы при следующем запуске будет та директория  - из которой мы вышли.



