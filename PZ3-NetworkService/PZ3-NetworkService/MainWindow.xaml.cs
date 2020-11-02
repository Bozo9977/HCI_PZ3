using PZ3_NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PZ3_NetworkService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private int count = 15; // Inicijalna vrednost broja objekata u sistemu
        // ######### ZAMENITI stvarnim brojem elemenata


            /**
        private int redniBrojObjekta;
        private double vrednost; //Promenljiva u kojoj ce se nalaziti vrednost merenja tokom parsiranja
        private bool file = false;




        public static Dictionary<int, Server> serveri = new Dictionary<int, Server>();
       
        Server r = new Server();*/
        public MainWindow()
        {
            InitializeComponent();
            //createListener(); //Povezivanje sa serverskom aplikacijom
        }
        /*
        private void createListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25565);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        //Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        //Primljena poruka je sacuvana u incomming stringu
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        //Ukoliko je primljena poruka pitanje koliko objekata ima u sistemu -> odgovor
                        if (incomming.Equals("Need object count"))
                        {
                            //Response
                             Umesto sto se ovde salje count.ToString(), potrebno je poslati 
                             * duzinu liste koja sadrzi sve objekte pod monitoringom, odnosno
                             * njihov ukupan broj (NE BROJATI OD NULE, VEC POSLATI UKUPAN BROJ)
                             * 
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri.Count.ToString());
                            stream.Write(data, 0, data.Length);
                        }
                        else
                        {
                            //U suprotnom, server je poslao promenu stanja nekog objekta u sistemu
                            Console.WriteLine(incomming); //Na primer: "Objekat_1:272"

                            //################ IMPLEMENTACIJA ####################
                            // Obraditi poruku kako bi se dobile informacije o izmeni
                            // Azuriranje potrebnih stvari u aplikaciji
                            
                            string[] pom_string1 = incomming.Split('_');
                            string[] pom_string2 = pom_string1[1].Split(':');
                            redniBrojObjekta = Int32.Parse(pom_string2[0]);
                            
                            vrednost = double.Parse(pom_string2[1]);

                            Sacuvaj_u_log_file();

                           
                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }






        private void Sacuvaj_u_log_file()
        {
            string putanja = @"C:\Users\Bozo\Desktop\HCI\PZ3-NetworkService\PZ3-NetworkService\bin\Debug\LogFile.txt";
            Console.WriteLine("Rbr objekta:" + redniBrojObjekta);
            Console.WriteLine("Vrednost :" + vrednost);
            ViewModel.NetworkDataViewModel.Serveri[redniBrojObjekta].Value = vrednost; 

            if (!file)
            {
                StreamWriter writer;
                using (writer = new StreamWriter(putanja))
                {
                    //writer.WriteLine("Object_" + redniBrojObjekta + " -> Value: " + vrednost + "\tTime: " + DateTime.Now.ToString());
                    writer.WriteLine(DateTime.Now.ToString() + " Object_" + PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri[redniBrojObjekta].Id + " -> Value: " + vrednost);
                }


            }
            else
            {
                StreamWriter writer;
                using (writer = new StreamWriter(putanja, true))
                {
                    //writer.WriteLine("Object_" + redniBrojObjekta + " -> Value: " + vrednost + "\tTime: " + DateTime.Now.ToString());
                    writer.WriteLine(DateTime.Now.ToString() + " Object_" + PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri[redniBrojObjekta].Id + " -> Value: " + vrednost);
                }

            }

            file = true;
        }











    */















    }
}
