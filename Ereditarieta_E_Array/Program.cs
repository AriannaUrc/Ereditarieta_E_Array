using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta_E_Array
{
    /*Realizzare un programma in c# in grado di gestire un elenco di diplomati.
I diplomati si dividono in vecchi diplomati e nuovi diplomati, rispettivamente con voto da 36 a 60 per i vecchi e da 60 a 100 per i nuovi.
I vecchi diplomati sono abili ai concorsi con voto maggiore o uguale a 42, mentre i nuovi con voto maggiore o uguale a 70.
Le funzionalità richieste sono:
- inserimento dei diplomati
- stampa di tutti i diplomati
- stampa dei diplomati abili ai concorsi.*/

    internal class Program
    {
        static void Main(string[] args)
        {
            //arrai di diplomati
            NuoviDiplomati[] studentiNuovi = new NuoviDiplomati[100];
            VecchiDiplomati[] studentiVecchi = new VecchiDiplomati[100];

            //variabile che conta il numero di studenti inseriti
            int NumStudentiVecchi = 0;
            int NumStudentiNuovi = 0;

            int votoTemp;
            Console.WriteLine("Inserire il voto dello studente che si vuole aggiungere. Se non ne si vuole aggiungere altri inserire \"-1\"");
            votoTemp = int.Parse(Console.ReadLine());

            while(votoTemp != -1)
            {
                if(votoTemp > 60)
                {
                    studentiNuovi[NumStudentiNuovi] = new NuoviDiplomati(votoTemp);
                    Console.WriteLine("Abile: " + studentiNuovi[NumStudentiNuovi].Abile);
                    NumStudentiNuovi++;
                }
                else
                {
                    studentiVecchi[NumStudentiVecchi] = new VecchiDiplomati(votoTemp);
                    Console.WriteLine("Abile: " + studentiVecchi[NumStudentiVecchi].Abile);
                    NumStudentiVecchi++;
                }

                //Console.WriteLine("Inserire il voto dello studente che si vuole aggiungere. Se non ne si vuole aggiungere altri inserire \"-1\"");
                votoTemp = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nNumStudentiVecchi: " + NumStudentiVecchi);
            Console.WriteLine("NumStudentiNuovi: "+ NumStudentiNuovi + "\n\n");

            Console.WriteLine("Lista Studenti abili: ");
            for(int i = 0; i < NumStudentiVecchi; i++)
            {
                if (studentiVecchi[i].Abile)
                    Console.WriteLine(studentiVecchi[i].Voto);
            }

            for (int i = 0; i < NumStudentiNuovi; i++)
            {
                if (studentiNuovi[i].Abile)
                    Console.WriteLine(studentiNuovi[i].Voto);
            }
        }
    }

    class Diplomati
    {
        private int voto;

        //costruttore senza parametri
        public Diplomati()
        {
            voto = 0;
        }

        //costruttore con parametri
        public Diplomati(int voto)
        {
            this.voto = voto;
        }

        public int Voto { get { return voto; } set { voto = value; } }
    }
    

    class VecchiDiplomati : Diplomati
    {
        bool abile;

        //costruttore senza parametri
        public VecchiDiplomati()
        {
            this.Voto = 0;
            Abile = false;

        }

        //costruttore con parametri
        public VecchiDiplomati(int voto)
        {
            if(voto >= 0 && voto < 60)
            {
                this.Voto = voto;
                if (voto >= 42)
                {
                    Abile = true;
                }
                else
                {
                    Abile = false;
                }
            }
            else
            {
                this.Voto = 60;
                Abile = false;
            }

        }

        public bool Abile { get { return abile;} set { abile = value; } }
    }

    class NuoviDiplomati : Diplomati
    {
        bool abile;

        //costruttore senza parametri
        public NuoviDiplomati()
        {
            this.Voto = 60;
            abile = false;
        }

        //costruttore con parametri
        public NuoviDiplomati(int voto)
        {
            if (voto > 60 && voto <= 100)
            {
                this.Voto = voto;

                if (voto >= 70)
                {
                    this.Abile = true;
                }
                else
                {
                    this.Abile = false;
                }
            }
            else
            {
                this.Voto = 60;
                Abile = false;
            }
        }
        public bool Abile { get { return abile; } set { abile = value; } }
    }

}
