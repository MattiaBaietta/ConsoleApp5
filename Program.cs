
using System.Text.RegularExpressions;

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
    private static bool isint = false;
    private static bool isname = false;
    private static bool issur = false;
    private static bool iscfok = false;
    private static bool issok = false;
    private static bool isdateok = false;
    private static string input;
    


    public static void InserimentoDati()
    {
        do
            
        {
            Console.WriteLine("Inserisci il tuo nome");
            Nome = Console.ReadLine();
            if (Nome.Length >= 1 && Nome!=" ")
            {
                isname = true;
            }
            else
            {
                Console.WriteLine("Nome non valido");
            }
                
        }
        while (isname == false);
        do
        {
            Console.WriteLine("Inserisci il tuo cognome");
            Cognome = Console.ReadLine();
            if (Cognome.Length >= 1 && Cognome != " ")
            {
                issur = true;
            }
            else
            {
                Console.WriteLine("Cognome non valido");
            }

        }
        while (issur == false);

        do
        {
            Console.WriteLine("Inserisci la tua data di nascita (Formato DD/MM/YYYY obbligatorio)");
            DataNascita = Console.ReadLine();
            Regex regex = new Regex(@"^\d{2}/\d{2}/\d{4}$");
            if (regex.IsMatch(DataNascita))
            {
                isdateok = true;
            }
            else
            {
                Console.WriteLine("Data di nascita non valida");
            }
        }
        while (isdateok == false);



        do
        {
            Console.WriteLine("Inserisci il tuo codice fiscale (Formato codice fiscale obbligatorio es:RSSMRA82A01H501L)");
            CodiceFiscale = Console.ReadLine().ToUpper();
            Regex regex2 = new Regex(@"^([A-Za-z]{6}[0-9lmnpqrstuvLMNPQRSTUV]{2}[abcdehlmprstABCDEHLMPRST]{1}[0-9lmnpqrstuvLMNPQRSTUV]{2}[A-Za-z]{1}[0-9lmnpqrstuvLMNPQRSTUV]{3}[A-Za-z]{1})$|([0-9]{11})$");



            if (regex2.IsMatch(CodiceFiscale))
            {
                iscfok = true;
            }
            else
            {
                Console.WriteLine("Codice fiscale non valido");
            }
        }
        while (iscfok == false);
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
                
                Imposta = 25420 + (((RedditoAnnuale - 75000) / 100) * 43);
                break;
            case < 15000:
                
                Imposta = (RedditoAnnuale / 100)*23;
                break;
            default:
                if(RedditoAnnuale>=55001)
                {
                    
                    Imposta = 17220 + (((RedditoAnnuale - 55000) / 100) * 41);
                }
                else
                {
                    if(RedditoAnnuale>=28001&&RedditoAnnuale<=55000)
                    {
                        
                        Imposta = 6960 + (((RedditoAnnuale - 28000) / 100) * 38);
                    }
                    else
                    {
                        
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


