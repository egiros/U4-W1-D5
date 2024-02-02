using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_W1_D5
{
    class Contribuente
    {
        // Proprietà della classe
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }  // DateTime fornisce metodi e proprietà per manipolare e ottenere informazioni sulla data e l'ora correnti.
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public decimal RedditoAnnuale { get; set; }



        // Costruttore della classe
        public Contribuente(string nome, string cognome, DateTime datanascita, string cdf, char sex, string comuneresidenza, decimal redditoannuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = datanascita;
            CodiceFiscale = cdf;
            Sesso = sex;
            ComuneResidenza = comuneresidenza;
            RedditoAnnuale = redditoannuale;
        }



        // Metodo per calcolare l'imposta in base agli scaglioni di reddito

        /*
         
               SCAGLIONI DI REDDITO                 ALIQUOTA E IMPOSTA DOVUTA
            Reddito da 0 a 15.000                   aliquota 23%
            Reddito da 15.001 a 28.000              3.450 + aliquota 27% sulla parte eccedente i 15.000
            Reddito da 28.001 a 55.000              6.960 + 38% sulla parte eccedente i 28.000
            Reddito da 55.001 a 75.000              17.220 + 41% sulla parte eccedente i 55.000
            Redduti oltre i 75.001                  25.420 + 43% sulla parte eccedente i 75.000

            nella condizione parto dal massimo e sottraggo il minimo degli scaglioni.
            imposta = Imposta dovuta + RedditoAnnuale(input) x % aliquota (usare m per i decimal)
         */
        public decimal CalcolaImposta()
        {
            decimal imposta = 0;

            if (RedditoAnnuale <= 15000)
            {
                imposta = RedditoAnnuale * 0.23m;
            }
            else if (RedditoAnnuale <= 28000)
            {
                imposta = 3450 + (RedditoAnnuale - 15000) * 0.27m;
            }
            else if (RedditoAnnuale <= 55000)
            {
                imposta = 6960 + (RedditoAnnuale - 28000) * 0.28m;
            }
            else if (RedditoAnnuale <= 75000)
            {
                imposta = 17220 + (RedditoAnnuale - 55000) * 0.41m;
            }
            else
            {
                imposta = 25420 + (RedditoAnnuale - 75000) * 0.43m;
            }
            return imposta;
        }

        // Metodo per ottenere una stringa le informazioni necessarie del contribuente

        public string OttieniInfoContribuente()
        {
            return $"\nContribuente: {Nome} {Cognome}" +
                  $"\nNato il {DataNascita.ToString("dd/MM/yyyy")}, ({Sesso})" +
                  $"\nResidente in {ComuneResidenza}" +
                  $"\nCodice Fiscale: {CodiceFiscale}";
        }
    }
}
