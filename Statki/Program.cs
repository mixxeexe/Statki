int wyborcheck;
const int ROZMIAR = 10;
//Menu
Console.WriteLine(" ██████╗ ██████╗  █████╗     ██╗    ██╗    ███████╗████████╗ █████╗ ████████╗██╗  ██╗██╗\r\n██╔════╝ ██╔══██╗██╔══██╗    ██║    ██║    ██╔════╝╚══██╔══╝██╔══██╗╚══██╔══╝██║ ██╔╝██║\r\n██║  ███╗██████╔╝███████║    ██║ █╗ ██║    ███████╗   ██║   ███████║   ██║   █████╔╝ ██║\r\n██║   ██║██╔══██╗██╔══██║    ██║███╗██║    ╚════██║   ██║   ██╔══██║   ██║   ██╔═██╗ ██║\r\n╚██████╔╝██║  ██║██║  ██║    ╚███╔███╔╝    ███████║   ██║   ██║  ██║   ██║   ██║  ██╗██║\r\n ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝     ╚══╝╚══╝     ╚══════╝   ╚═╝   ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝\r\n");
Console.WriteLine("1.Rozpocznij grę w statki z botem");
Console.WriteLine("2.Zakończ program");
WyjasnienieZasad();
wyborcheck = Convert.ToInt32(Console.ReadLine());



if (wyborcheck == 1)
{
    //Rozpoczęcie gry z botem
    Console.WriteLine("<-----ROZPOCZĘCIE GRY Z BOTEM----->");
    char[,] planszaGracza = StworzPlansze();
    char[,] planszaBota = StworzPlansze();
    Console.WriteLine("---Twoja Plansza---");
    PokażPlansze(planszaGracza, false);
    RozstawStatkiGracz(planszaGracza);
    Console.WriteLine("\n Bot ustawia statki");
    StatkiBota(planszaBota);
    Console.ReadLine();

    //ROZGRYWKA
    while (true)
    {
        Console.Clear();
        Console.WriteLine("TWOJA PLANSZA:");
        PokażPlansze(planszaGracza, false);
        Console.WriteLine("\nPLANSZA BOTA:");
        PokażPlansze(planszaBota, true);
    }

}
if (wyborcheck == 2)
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
    char[,] plansza = new char[10, 10];
    for (int i = 0; i < 10; i++)
        for (int j = 0; j < 10; j++)
            plansza[i, j] = '~';
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
            char pole = plansza[i, j];
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
    for (int i = 0; i < dlugosc; i++)
    {
        if (poziomo)
        {
            plansza[x, y + i] = 'S';
        }
        else
        {
            plansza[x + i, y] = 'S';
        }
    }
}

static bool CzyMoznaPostawic(char[,] plansza, int x, int y, int dlugosc, bool poziomo)
{
    if (poziomo && y + dlugosc > 10) return false;
    if (poziomo && x + dlugosc > 10) return false;

    for (int i = 0; i < dlugosc; i++)
    {
        if (poziomo && plansza[x, y + i] != '~') return false;
        if (!poziomo && plansza[x + i, y] != '~') return false;
    }


    return true;
}
static bool Strzał(char[,] plansza, int x, int y)
{
    if (plansza[x, y] == 'S')
    {
        plansza[x, y] = 'X';
        return true;
    }
    if (plansza[x, y] == '~')
    {
        plansza[x, y] = 'O';
        return false;
    }
    return false;
}

static void StrzałBota(char[,] plansza)
{
    Random rand = new Random();
    int x, y;
    do
    {
        x = rand.Next(ROZMIAR);
        y = rand.Next(ROZMIAR);
    }
    while (plansza[x, y] == 'X' || plansza[x, y] == 'O');
    Console.WriteLine($"\nBot strzela: {x}, {y}");

    if (plansza[x, y] == 'S')
    {
        plansza[x, y] = 'X';
        Console.WriteLine("Bot trafil!");
    }
    else
    {
        plansza[x, y] = 'O';
        Console.WriteLine("Bot nie trafił!");
    }
}

static void StatkiBota(char[,] plansza)
{
    Random rand = new Random();
    int[] statki = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

    foreach (int d in statki)
    {
        while (true)
        {
            int x = rand.Next(ROZMIAR);
            int y = rand.Next(ROZMIAR);
            bool poziomo = rand.Next(2) == 0;

            if (CzyMoznaPostawic(plansza, x, y, d, poziomo))
            {
                PostawStatek(plansza, x, y, d, poziomo);
                break;
            }
        }
    }
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
        Console.WriteLine($"2. 2x3 ({s3})");
        Console.WriteLine($"3. 3x2 ({s2})");
        Console.WriteLine($"4. 4x1 ({s1})");


        Console.WriteLine("Wybierz statek do postawienia:");
        Console.WriteLine("1. 1x4");
        Console.WriteLine("2. 2x3");
        Console.WriteLine("3. 3x2");
        Console.WriteLine("4. 4x1");

        int wybor = Convert.ToInt32(Console.ReadLine());
        int dlugość = 0;
        if (wybor == 1)
        {
            if (s4 > 0)
            {
                dlugość = 4;
                s4--;
            }
        }
        if (wybor == 2)
        {
            if (s3 > 0)
            {
                dlugość = 3;
                s3--;
            }
        }
        if (wybor == 3)
        {
            if (s2 > 0)
            {
                dlugość = 2;
                s2--;
            }
        }
        if (wybor == 4)
        {
            if (s1 > 0)
            {
                dlugość = 1;
                s1--;
            }
        }
        
        if (dlugość == 0)
        {
            Console.WriteLine("Nie możesz postawić tego statku! Wybierz Poprawny!");
            Console.ReadLine();
            continue;
        }
        Console.Write("Kierunek (P-Poziomo V-Pionowo):");
        char k = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();
        bool poziomo = (k == 'P');

        Console.Write("Podaj X (0-9): ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Podaj Y (0-9): ");
        int y = Convert.ToInt32(Console.ReadLine());

        if (CzyMoznaPostawic(plansza, x, y, dlugość, poziomo))
        {
            PostawStatek(plansza, x, y, dlugość, poziomo);
        }
        else
        {
            Console.WriteLine("Nie można postawic statku w tym miejscu!!!");
            if (dlugość == 4) s4++;
            if (dlugość == 3) s3++;
            if (dlugość == 2) s2++;
            if (dlugość == 1) s1++;
            Console.ReadLine();

        }
       



    }
    
} 

