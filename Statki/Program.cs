int wyborcheck;
//Menu
Console.WriteLine(" ██████╗ ██████╗  █████╗     ██╗    ██╗    ███████╗████████╗ █████╗ ████████╗██╗  ██╗██╗\r\n██╔════╝ ██╔══██╗██╔══██╗    ██║    ██║    ██╔════╝╚══██╔══╝██╔══██╗╚══██╔══╝██║ ██╔╝██║\r\n██║  ███╗██████╔╝███████║    ██║ █╗ ██║    ███████╗   ██║   ███████║   ██║   █████╔╝ ██║\r\n██║   ██║██╔══██╗██╔══██║    ██║███╗██║    ╚════██║   ██║   ██╔══██║   ██║   ██╔═██╗ ██║\r\n╚██████╔╝██║  ██║██║  ██║    ╚███╔███╔╝    ███████║   ██║   ██║  ██║   ██║   ██║  ██╗██║\r\n ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝     ╚══╝╚══╝     ╚══════╝   ╚═╝   ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝\r\n");
Console.WriteLine("1.Rozpocznij grę w statki z botem");
Console.WriteLine("2.Rozpocznij grę w statki z drugim graczem");
Console.WriteLine("3.Zakończ program");
wyborcheck = Convert.ToInt32(Console.ReadLine());
    


if (wyborcheck == 1)
{
    //Rozpoczęcie gry z botem
    Console.WriteLine("<-----ROZPOCZĘCIE GRY Z BOTEM----->");
    WyjasnienieZasad();
    StworzPlansze();
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
    Console.WriteLine("<Szybkie Wyjasnienie Zasad>");
    Console.WriteLine("Plansza 10x10 \n Statki: \n 1x4 \n 2x3 \n 3x2 \n 4x1 \n Znaki na Planszy: \n Woda - ~ \n Statek - S \n Pudło - O \n Trafienie - X");


}
static char[,] StworzPlansze()
{
    char[,] plansza = new char[10,10];
    for (int i = 0; i<10; i++)
    for (int j = 0; j <10; j++)
            plansza[i,j] = '~';
    return plansza;
}
