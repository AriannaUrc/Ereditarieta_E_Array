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
            Diplomati[] studenti = new Diplomati[100];

            //variabile che conta il numero di studenti inseriti
            int NumStudenti = 0;

            int votoTemp;
            Console.WriteLine("Inserire il voto dello studente che si vuole aggiungere. Se non ne si vuole aggiungere altri inserire \"-1\"");
            votoTemp = int.Parse(Console.ReadLine());

            while(votoTemp != -1)
            {
                if(votoTemp > 60)
                {
                    studenti[NumStudenti] = new NuoviDiplomati(votoTemp);
                    Console.WriteLine("Abile: " + studenti[NumStudenti].Abile());
                    NumStudenti++;
                }
                else
                {
                    studenti[NumStudenti] = new VecchiDiplomati(votoTemp);
                    Console.WriteLine("Abile: " + studenti[NumStudenti].Abile());
                    NumStudenti++;
                }

                //Console.WriteLine("Inserire il voto dello studente che si vuole aggiungere. Se non ne si vuole aggiungere altri inserire \"-1\"");
                votoTemp = int.Parse(Console.ReadLine());
            }


            Console.WriteLine("\nLista Studenti abili: ");
            for(int i = 0; i < NumStudenti; i++)
            {
                if (studenti[i].Abile())
                    Console.WriteLine(studenti[i].Voto);
            }
        }
    }

    class Diplomati
    {
        private int _voto;

        //costruttore senza parametri
        public Diplomati()
        {
            Voto = 0;
        }

        //costruttore con parametri
        public Diplomati(int voto)
        {
            this.Voto = voto;
        }
        
        public int Voto { get { return _voto; } set { _voto = value; } }

        public virtual bool Abile()
        {
            if (Voto >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    

    class VecchiDiplomati : Diplomati
    {
        

        //costruttore senza parametri
        public VecchiDiplomati()
        {
            this.Voto = 0;

        }

        //costruttore con parametri
        public VecchiDiplomati(int voto)
        {
            Voto_Vecchio = voto;

        }

        public int Voto_Vecchio { 
            get {
                return Voto; 
            } 
            
            set {
                if (value >= 0 && value < 60)
                {
                    this.Voto = value;
                }
                else
                {
                    this.Voto = 0;
                }
            } 
        }

        public override bool Abile()
        {
            if (Voto >= 42)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class NuoviDiplomati : Diplomati
    {

        //costruttore senza parametri
        public NuoviDiplomati()
        {
            this.Voto = 60;
        }

        //costruttore con parametri
        public NuoviDiplomati(int voto)
        {
            Voto_Nuovo = voto;
        }

        public int Voto_Nuovo
        {
            get
            {
                return Voto;
            }

            set
            {
                if (value > 60 && value <= 100)
                {
                    this.Voto = value;
                }
                else
                {
                    this.Voto = 60;
                }
            }


        }

        public override bool Abile()
        {
            if (Voto >= 70)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
