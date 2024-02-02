using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_W1_D5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;  // Soluzione trovata online per la visualizzazione dei caratteri tipo €

            // Menu per interagire con l'utente in input

            Console.WriteLine("============================================================================");
            Console.WriteLine("***************BENVENUTO!***************");
            Console.WriteLine("Inserisci i dati richiesti dalla nostra APP per il calcolo dell'imposta da versare");
            Console.WriteLine("============================================================================");

            string nome, cognome, cdf, comuneresidenza;
            DateTime datanascita;
            char sex;
            decimal redditoannuale;

            do
            {
                Console.WriteLine("\n\nInserisci il NOME del contribuente: ");
                nome = Console.ReadLine().ToUpper(); // ToUpper trasforma tutte le lettere in maiuscolo

                Console.WriteLine("\nInserisci il COGNOME del contribuente: ");
                cognome = Console.ReadLine().ToUpper();

                while (true) // questo ciclo ripete l'inserimento della data di nascita fichè non rispetta il formato corretto
                {
                    Console.WriteLine("\nInserisci la DATA DI NASCITA del contribuente: (gg/mm/aaaa)");

                    try
                    {
                        datanascita = DateTime.Parse(Console.ReadLine());
                        break; // esce dal ciclo se la data è nel formato corretto
                    }
                    catch (FormatException)  // soluzione suggerita direttamente da VS
                    {
                        Console.WriteLine("\n ATTENZIONE!!!!\nFormato DATA non valido. \nRiprova facendo attenzione a rispettare GG/MM/AAAA");
                    }

                }

                while (true)
                {
                    Console.WriteLine("\nInserisci il CODICE FISCALE del contribuente: ");
                    cdf = Console.ReadLine().ToUpper();

                    if (cdf.Length == 16)
                    {
                        // Esce dal ciclo se la lunghezza del CDF è uguale di 16
                        break;
                    }
                    else
                    { 
                        Console.WriteLine("\n ATTENZIONE!!!!\nFormato CDF non valido. \nRiprova, il CODICE FISCALE deve avere una lunghezza di 16 caratteri");
                    }
                }

                   

                Console.WriteLine("\nInserisci il SESSO del contribuente: (M/F)");
                sex = char.Parse(Console.ReadLine().ToUpper()); ;

                Console.WriteLine("\nInserisci il COMUNE DI RESIDENZA: ");
                comuneresidenza = Console.ReadLine().ToUpper();

                Console.WriteLine("\nInserisci il REDDITO ANNUALE del contribuente: \n€ ");
                redditoannuale = decimal.Parse(Console.ReadLine());
               

                Console.WriteLine("\nI tuoi dati sono corretti?");
                Console.WriteLine("\nPremi il tasto Y per confermare N per inserirli nuovamente.");

            } while (Console.ReadLine().ToUpper() != "Y");

            // Viene creata un'istanza della classe Contribuente con i dati inseriti
            Contribuente contribuente = new Contribuente(nome, cognome, datanascita, cdf, sex, comuneresidenza, redditoannuale);

            // Viene utilizzato il metodo CalcolaImposta appunto per calcolare l'imposta
            decimal impostaDaVersare = contribuente.CalcolaImposta();

            // Stampa un riempilogo dei dati e dell'imposta calcolata
            Console.WriteLine("\n\n============================================================================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE: ");
            Console.WriteLine("============================================================================");

            // Stampa i dettagli del contribuente
            Console.WriteLine(contribuente.OttieniInfoContribuente());

            // Stampa il reddito dichiarato e l'imposta da versare
            Console.WriteLine($"\nReddito dichiarato: {contribuente.RedditoAnnuale:C}");  // :C Metodo di valuta per visualizzare €
            Console.WriteLine($"\nIMPOSTA DA VERSARE: {impostaDaVersare:C}");


            Console.WriteLine("\n\n\n\n\n============================================================================");
            Console.WriteLine("**********PREMI INVIO PER CHIUDERE L'APPLICAZIONE**********");
            Console.WriteLine("============================================================================");
            Console.ReadLine();
        }

       
    }
}
