namespace ConsoleApp24;

internal class Program
{
    public static int cursorpos = 1;
    public static int MoveDay = 0;
    public static DateTime mydate = new DateTime(2023, 02, 07);
    public static Class1 FirstOne = new Class1()
    {
        name = "Прогулка с собакой",
        data = new DateTime(2023, 02, 11),
        day = 11,
        description = "Не забыть позвать девушку."
    };
    public static Class1 FirstTwo = new Class1()
    {
        name = "Работа",
        data = new DateTime(2023, 02, 14),
        day = 14,
        description = "Не забыть сделать отзывы на Авито."
    };
    public static Class1 FirstThree = new Class1()
    {
        name = "Помощь матери",
        data = new DateTime(2023, 02, 18),
        day = 18,
        description = "Не забыть про уборку в комнате."
    };
    public static Class1 SecondOne = new Class1()
    {
        name = "Лук",
        data = new DateTime(2023, 02, 15),
        day = 15,
        description = "Съесть 150 грамм лука для понижения эстрадиола и повышения тестостерона."
    };
    public static Class1 SecondTwo = new Class1()
    {
        name = "Парк",
        data = new DateTime(2023, 02, 13),
        day = 13,
        description = "Прогуляться в парке с друзьями."
    };
    public static Class1 ThirdOne = new Class1()
    {
        name = "Сходить в кальянную",
        data = new DateTime(2023, 02, 07),
        day = 07,
        description = "Необходимо отписать в группу друзьям."
    };
    public static List<Class1> daylist = new List<Class1>();


    static void Main()
    {
        daylist.Add(FirstOne);
        daylist.Add(FirstTwo);
        daylist.Add(FirstThree);
        daylist.Add(SecondOne);
        daylist.Add(SecondTwo);
        daylist.Add(ThirdOne);
        Console.WriteLine("Это ежедневник , для выхода нажмите ESCape");
        while (true)
        {
            SelectedDate();
            ConsoleKeyInfo key = Console.ReadKey();
            buttons(key);
        }
    }

    private static void SelectedDate()
    {
        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"   Выбрана дата: {mydate.AddDays(MoveDay)}");
        Console.SetCursorPosition(3, 2);
        int n = 0;
        foreach (var item in daylist)
        {
            if (item.data == mydate.AddDays(MoveDay))
            {
                Console.WriteLine($"{n + 1}. {item.name}");
            }
        }
        Console.SetCursorPosition(0, cursorpos);
    }

    static void buttons(ConsoleKeyInfo Choice)
    {
        switch (Choice.Key)
        {
            case ConsoleKey.RightArrow:
                MoveDay = MoveDay + 1;
                break;

            case ConsoleKey.LeftArrow:
                MoveDay = MoveDay - 1;
                break;

            case ConsoleKey.DownArrow:
                if (cursorpos > daylist.Where(i => i.day == MoveDay).ToList().Count + 1)
                {
                }
                else
                {
                    cursorpos += 1;
                }
                break;

            case ConsoleKey.UpArrow:
                if (cursorpos < 2)
                {
                    cursorpos = 2;
                }
                else
                {
                    cursorpos -= 1;
                }
                break;

            case ConsoleKey.Enter:
                Console.Clear();
                Console.SetCursorPosition(2, 2);
                Fully();
                break;

            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
        }
        Cursor();
    }

    private static void Fully()
    {
        int n = 0;
        foreach (var item in daylist)
        {
            if (item.day == mydate.AddDays(MoveDay).Day)
            {
                Console.WriteLine($"{item.name}\n    Подробности: {item.description}");
            }
        }
        Console.ReadKey();
    }

    private static void Cursor()
    {
        Console.Clear();
        Console.SetCursorPosition(0, cursorpos);
        Console.Write("->");
    }
}