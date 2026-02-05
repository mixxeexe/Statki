int wyborcheck;
int x;
int y;
//Menu
Console.WriteLine(" ██████╗ ██████╗  █████╗     ██╗    ██╗    ███████╗████████╗ █████╗ ████████╗██╗  ██╗██╗\r\n██╔════╝ ██╔══██╗██╔══██╗    ██║    ██║    ██╔════╝╚══██╔══╝██╔══██╗╚══██╔══╝██║ ██╔╝██║\r\n██║  ███╗██████╔╝███████║    ██║ █╗ ██║    ███████╗   ██║   ███████║   ██║   █████╔╝ ██║\r\n██║   ██║██╔══██╗██╔══██║    ██║███╗██║    ╚════██║   ██║   ██╔══██║   ██║   ██╔═██╗ ██║\r\n╚██████╔╝██║  ██║██║  ██║    ╚███╔███╔╝    ███████║   ██║   ██║  ██║   ██║   ██║  ██╗██║\r\n ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝     ╚══╝╚══╝     ╚══════╝   ╚═╝   ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝\r\n");
Console.WriteLine("1.Rozpocznij grę w statki z botem");
Console.WriteLine("2.Rozpocznij grę w statki z drugim graczem");
Console.WriteLine("3.Zakończ program");
WyjasnienieZasad();
wyborcheck = Convert.ToInt32(Console.ReadLine());
    


if (wyborcheck == 1)
{
    //Rozpoczęcie gry z botem
    Console.WriteLine("<-----ROZPOCZĘCIE GRY Z BOTEM----->");
    char[,] planszaGracza =StworzPlansze();
    char[,] planszaBota = StworzPlansze();
    Console.WriteLine("---Twoja Plansza---");
    PokażPlansze(planszaGracza, false);
    RozstawStatkiGracz(planszaGracza);


}
if (wyborcheck == 2)
{
    //Rozpoczęcie gry z 2 graczem
    Console.WriteLine("<-----ROZPOCZĘCIE GRY Z DRUGIM GRACZEM----->");
    WyjasnienieZasad();
    StworzPlansze();
}
if (wyborcheck == 3)
{
    //koniec programu
    Environment.Exit(0);
    
}

void WyjasnienieZasad()
{
    Console.WriteLine("\n<Szybkie Wyjasnienie Zasad>");
    Console.WriteLine("Plansza 10x10 \n  Znaki na Planszy: \n Woda - ~ \n Statek - S \n Pudło - O \n Trafienie - X");


}

static char[,] StworzPlansze()
{
    char[,] plansza = new char[10,10];
    for (int i = 0; i<10; i++)
    for (int j = 0; j <10; j++)
            plansza[i,j] = '~';
    return plansza;
}
static void PokażPlansze(char[,] plansza, bool ukryjstatek)
{
    Console.Write("  ");
    for (int i = 0; i < 10; i++)
    {
        Console.Write(i + " ");
       
    }
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
        Console.Write(i + " ");
            for (int j = 0; j < 10; j++)
        {
            char pole = plansza[i,j];
            if (ukryjstatek && pole == 'S')
            {
                Console.Write("~ ");
            }
            else
            {
                Console.Write(pole + " ");
            }
           
        }
        Console.WriteLine();
    }
 
}
static void PostawStatek(char[,] plansza, int x, int y, int dlugosc, bool poziomo)
{
    for (int i =0; i < dlugosc; i++)
    {
        if (poziomo)
        {
            plansza[x, y + i] = 'S';
        
        }
        else
        {
            plansza[x + i, y] += 'S';
        }
}
}
static int WybierzStatek()
{
    Console.WriteLine("Wybierz statek do postawienia:");
    Console.WriteLine("1. 1x4");
    Console.WriteLine("2. 2x3");
    Console.WriteLine("3. 3x2");
    Console.WriteLine("4. 4x1");

    int wybor = Convert.ToInt32(Console.ReadLine());

    if (wybor == 1)
    {

    }
    if (wybor == 2)
    {

    }
    if (wybor == 3)
    {

    }
    if (wybor == 4)
    {

    }
    else
    {
        Console.WriteLine("Zły wybor");
    }
    return 0;
}
static void RozstawStatkiGracz(char[,] plansza)
{
    int s4 = 1;
    int s3 = 2;
    int s2 = 3;
    int s1 = 4;

    while (s4 + s3 + s2 + s1 > 0)
    {
        Console.Clear();
        PokażPlansze(plansza, false);

        Console.WriteLine("Pozostałe Statki:");
        Console.WriteLine($"1. 1x4 ({s4})");
        Console.WriteLine($"1. 2x3 ({s3})");
        Console.WriteLine($"1. 3x2 ({s2})");
        Console.WriteLine($"1. 4x1 ({s1})");

        WybierzStatek();
    }

}
