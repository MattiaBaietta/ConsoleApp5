
internal class Program
{
    static void Main(string[] args)
    {

        do
        {
            Contribuente.InserimentoDati();
            Contribuente.CalcoloImposta();
        }
        while (true);
        

    }    
}







public class Contribuente
{
    private static string Nome;
    private static string Cognome;
    private static string DataNascita;
    private static string CodiceFiscale;
    private static string Sesso;
    private static string ComuneResidenza;
    private static int RedditoAnnuale;
    private static int Imposta;
    private static int Aliquota;
    private static bool isint = false;
    private static bool iscfok = false;
    private static bool issok = false;    
    private static string input;


    public static void InserimentoDati()
    {
        Console.WriteLine("Inserisci il tuo nome");
        Nome = Console.ReadLine();
        Console.WriteLine("Inserisci il tuo cognome");
        Cognome = Console.ReadLine();
        Console.WriteLine("Inserisci la tua data di nascita (Formato DD/MM/YYYY)");
        DataNascita = Console.ReadLine();
        do
        {
            Console.WriteLine("Inserisci il tuo codice fiscale (16 caratteri obbligatori)");
            CodiceFiscale = Console.ReadLine().ToUpper();
            if (CodiceFiscale.Length != 16)
            {
                Console.WriteLine("Codice fiscale non corretto");
            }
            else
            {
                iscfok = true;
            }
        }
        while (iscfok==false);
        do
        {
            Console.WriteLine("Inserisci il tuo sesso (M/F)");
            Sesso = Console.ReadLine().ToUpper();
            if(Sesso!="M"&&Sesso!="F")
            {
                Console.WriteLine("Sesso non valido");
            }
            else
            {
                issok = true;
            }
        }
        while(issok==false);    
        
        Console.WriteLine("Inserisci il tuo comune di residenza");
        ComuneResidenza = Console.ReadLine();

        while(isint==false)
        {
            Console.WriteLine("Inserisci il tuo reddito annuale (accetta solo numeri interi):");
            input = Console.ReadLine();
            if (int.TryParse(input, out RedditoAnnuale))
            {
                isint = true;
            }
            else
            {
                Console.WriteLine("Il reddito inserito non è valido");
            }
        }
        isint = false;
        
           

            
    }
    public static void CalcoloImposta()
    {
        switch (RedditoAnnuale)
        {
            case > 75000:
                Aliquota = 43;
                Imposta = 25420 + (((RedditoAnnuale - 75000) / 100) * 43);
                break;
            case < 15000:
                Aliquota = 23;
                Imposta = (RedditoAnnuale / 100)*23;
                break;
            default:
                if(RedditoAnnuale>=55001)
                {
                    Aliquota = 41;
                    Imposta = 17220 + (((RedditoAnnuale - 55000) / 100) * 41);
                }
                else
                {
                    if(RedditoAnnuale>=28001&&RedditoAnnuale<=55000)
                    {
                        Aliquota = 38;
                        Imposta = 6960 + (((RedditoAnnuale - 28000) / 100) * 38);
                    }
                    else
                    {
                        Aliquota = 27;
                        Imposta = 3450 + (((RedditoAnnuale - 15000) / 100) * 27);
                    }
                }
                break;
        }

        Console.WriteLine($"Contribuente:{Nome} {Cognome}");
        Console.WriteLine($"Nato il {DataNascita}");
        Console.WriteLine($"Residente in: {ComuneResidenza}");
        Console.WriteLine($"Codice fiscale: {CodiceFiscale}");
        Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale}");
        Console.WriteLine($"L'imposta da pagare è:{Imposta}");

    }
}


