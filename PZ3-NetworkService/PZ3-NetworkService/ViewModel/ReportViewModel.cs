using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PZ3_NetworkService.MyCommand;

namespace PZ3_NetworkService.ViewModel
{
    public class ReportViewModel : BindableBase
    {
        public DateTime selektovanDatum1;
        public DateTime selektovanDatum2;
        public string tekst;

        public ReportViewModel()
        {
            Prikazi = new MyICommand(OnPrikazi);
            SelektovanDatum1 = DateTime.Now;
            SelektovanDatum2 = DateTime.Now.AddHours(24);
            Tekst = "\n\t\t\tPritiskom tastera SHOW dobijate ispis!";
        }
        public string Tekst
        {
            get { return tekst; }
            set
            {
                tekst = value;
                OnPropertyChanged("Tekst");
            }
        }

        public MyICommand Prikazi { get; set; }

        public DateTime SelektovanDatum1
        {
            get { return selektovanDatum1; }
            set { selektovanDatum1 = value; }
        }
        public DateTime SelektovanDatum2
        {
            get { return selektovanDatum2; }
            set { selektovanDatum2 = value; }
        }

        public void OnPrikazi()
        {
            Tekst = " REPORT:\n";
            int brojServera = PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri.Count;
            string vrednost = null;
            List<string> lista = new List<string>();

            using (StreamReader file = new StreamReader(@"C:\Users\Bozo\Desktop\HCI\PZ3-NetworkService\PZ3-NetworkService\bin\Debug\LogFile.txt"))
            {
                while ((vrednost = file.ReadLine()) != null)
                {
                    lista.Add(vrednost);
                }
            }
            string red = null;
            string[] redSplit = null;
            string[] redSplit1 = null;
            int pomBrojServera = -1;

            for (int i = 0; i < brojServera; i++)
            {
                Tekst = Tekst + "\t- OBJECT " + PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri[i].Id + "\n";
                for (int j = 0; j < lista.Count; j++)
                {
                    red = lista[j];
                    redSplit = red.Split(' ');
                    DateTime datum = DateTime.Parse(redSplit[0] + " " + redSplit[1] + " " + redSplit[2]);
                    redSplit1 = redSplit[3].Split('_');
                    pomBrojServera = Int32.Parse(redSplit1[1]);

                    if (PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri[i].Id == pomBrojServera)
                    {
                        if (DateTime.Compare(SelektovanDatum1, datum) <= 0 && DateTime.Compare(SelektovanDatum2, datum) >= 0)
                        {
                            Tekst = Tekst + "\t\t" + datum.ToString() + ", CHANGED STATE: " + redSplit[6] + "\n";
                        }
                    }
                }
            }

        }

    }
}
