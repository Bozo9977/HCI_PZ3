using Microsoft.Win32;
using PZ3_NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using static PZ3_NetworkService.MyCommand;

namespace PZ3_NetworkService.ViewModel
{
    public class NetworkDataViewModel: BindableBase
    {
        public static ObservableCollection<Server> Serveri { get; set; }
        public static ObservableCollection<Server> FilterLista { get; set; }
        public static ObservableCollection<Server> pomServeri { get; set; }
        static BitmapImage bmp1 = new BitmapImage();
        static OpenFileDialog op1 = new OpenFileDialog();

        private Server trenutniServer = new Server();
        private Server selektovaniServer;
        //public static string slika = @"C:\Users\Bozo\Desktop\HCI\PZ3-NetworkService\PZ3-NetworkService\Slike\Server-Room.jpg";

        //public Uri uri = new Uri(slika, UriKind.Relative);

        public MyICommand AddServer { get; set; }
        public MyICommand DeleteServer { get; set; }

        public MyICommand Browse { get; set; }
        public MyICommand Refresh { get; set; }
        public MyICommand Filter { get; set; }
        private List<string> filters = new List<string>();

        string pomID;
        private string labelIDErr;
        private string labelNameErr;
        private string labelIPErr;
        private string idAdd;
        private string nameAdd;
        private string ipAdd;


        string tekstZaPretragu;
        public string TekstZaPretragu
        {
            get { return tekstZaPretragu; }
            set
            {
                tekstZaPretragu = value;
                OnPropertyChanged(value);
            }
        }


        public NetworkDataViewModel()
        {
            Serveri = new ObservableCollection<Server>();
            FilterLista = new ObservableCollection<Server>();
            pomServeri = new ObservableCollection<Server>();
            AddServer = new MyICommand(OnAdd);
            DeleteServer = new MyICommand(OnDel, CanDel);
            Browse = new MyICommand(OnBrowse);
            Filter = new MyICommand(OnFilter);
            Refresh = new MyICommand(OnRefresh);
            Filters.Add("Less than");
            Filters.Add("Grater than");
            Filters.Add("Equal to");

            Serveri.Add(new Server()
            {
                Id = 1,
                Name = "S1",
                IpAddress = "0.0.0.0",
                Img_src = @"C:\Users\Bozo\Desktop\HCI\PZ3-NetworkService\PZ3-NetworkService\Slike\Server-Room.jpg",
                Value = 100
            });
            Serveri.Add(new Server()
            {
                Id = 2,
                Name = "S2",
                IpAddress="0.0.0.1",
                Img_src= @"C:\Users\Bozo\Desktop\HCI\PZ3-NetworkService\PZ3-NetworkService\Slike\Server-Room1.jpg",
                Value = 40
            });
            Serveri.Add(new Server()
            {
                Id = 3,
                Name = "S3",
                IpAddress = "0.0.0.2",
                Img_src = @"C:\Users\Bozo\Desktop\HCI\PZ3-NetworkService\PZ3-NetworkService\Slike\ozb-serveri.jpg",
                Value = 67
            });
            Serveri.Add(new Server()
            {
                Id = 4,
                Name = "S4",
                IpAddress = "0.0.0.3",
                Img_src = @"C:\Users\Bozo\Desktop\HCI\PZ3-NetworkService\PZ3-NetworkService\Slike\Serveri.jpg",
                Value = 43
            });


            foreach (var item in Serveri)
            {
                FilterLista.Add(item);
            }
        }



        public Server TrenutniServer
        {
            get { return trenutniServer; }
            set
            {

                trenutniServer = value;
                OnPropertyChanged("TrenutniServer");
            }
        }
        
        public Server SelektovanServer
        {
            get { return selektovaniServer; }
            set { selektovaniServer = value;
                DeleteServer.RaiseCanExecuteChanged();
            }
        }
        public List<string> Filters { get => filters; set => filters = value; }
        public string PomID { get => pomID; set => pomID = value; }
        public string LabelIDErr { get => labelIDErr;
            set
            {
                labelIDErr = value;
                OnPropertyChanged("LabelIDErr");
            }
        }
        public string IdAdd { get => idAdd; set => idAdd = value; }
        public string LabelNameErr
        { get => labelNameErr;
            set
            {
                labelNameErr = value;
                OnPropertyChanged("LabelNameErr");
            }
        }

        public string NameAdd { get => nameAdd; set => nameAdd = value; }
        public string IpAdd { get => ipAdd;
            set
            {
                ipAdd = value;
               // OnPropertyChanged("IpAdd");
            }
        }

        public string LabelIPErr { get => labelIPErr;
            set
            {
                labelIPErr = value;
                OnPropertyChanged("LabelIPErr");
            }
        }

        public void OnAdd()
        {
            if (validate())
            {
              

                Serveri.Add(new Server()
                {
                    Id = TrenutniServer.Id,
                    Name = TrenutniServer.Name,
                    IpAddress = TrenutniServer.IpAddress,
                    Img_src = TrenutniServer.Img_src,
                    Value = TrenutniServer.Value
                });
                FilterLista.Clear();
                foreach (var item in Serveri)
                {
                    FilterLista.Add(item);
                }
            }
        }

        public bool validate()
        {
            bool result = true;
            if (string.IsNullOrEmpty(IdAdd))
            {
                LabelIDErr = "<- Can't be empty";
                result = false;
            }
            else if(!Int32.TryParse(IdAdd, out int q) || Int32.Parse(IdAdd)<0)
            {
                LabelIDErr = "<- Can't use this for ID";
                result = false;
            }
            else if (Exists(Int32.Parse(IdAdd)))
            {
                LabelIDErr = "<- Already exists";
                result = false;
            }
            else
            {
                TrenutniServer.Id = Int32.Parse(IdAdd);

                LabelIDErr = "";
            }
            
            if (string.IsNullOrEmpty(NameAdd))
            {
                LabelNameErr = "<- Can't be empty.";
                result = false;
            }
            else
            {
                TrenutniServer.Name = NameAdd;
                LabelNameErr = "";
            }

            if (!string.IsNullOrEmpty(IpAdd))
            {
                string[] pomIp = IpAdd.Split('.');


                if (string.IsNullOrEmpty(IpAdd))
                {
                    LabelIPErr = "<- Can't be empty";
                    result = false;
                }
                else if (pomIp.Length != 4 && pomIp.Length != 6)
                {
                    LabelIPErr = "<- Invalid IP form";
                    MessageBox.Show("IP consists of 4 or 6 positive numbers less than 1000 separated by .", "CLARIFICATION", MessageBoxButton.OK, MessageBoxImage.Information);
                    result = false;
                }
                else if (!ValidateIP(pomIp))
                {
                    LabelIPErr = "<- Invlid IP form";
                    MessageBox.Show("IP consists of 4 or 6 positive numbers less than 1000 separated by .", "CLARIFICATION", MessageBoxButton.OK, MessageBoxImage.Information);
                    result = false;
                }
                else if (ExistsIP(IpAdd))
                {
                    LabelIPErr = "<- IP already exists";
                    result = false;
                }
                else
                {
                    TrenutniServer.IpAddress = IpAdd;
                    LabelIPErr = "";
                }

            }
            else
            {
                LabelIPErr = "<- Can't be empty.";
                result = false;
            }
            return result;
        }

        public bool ValidateIP(string[] ip)
        {
            bool ret = true;

            for(int i =0; i < ip.Length; i++)
            {
                if(!Int32.TryParse(ip[i], out int r) || Int32.Parse(ip[i])< 0)
                {
                    ret = false;
                }
            }

            return ret;
        }

        public bool Exists(int id)
        {
            bool result = false;
            foreach (var item in PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri)
            {
                if (item.Id == id)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        public bool ExistsIP(string ip)
        {
            bool result = false;
            foreach(var item in PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri)
            {
                if (item.IpAddress == ip)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void OnBrowse()
        {
            op1.FileName = "X";
            op1.InitialDirectory = @"C:\Users\Bozo\Desktop\HCI\PZ3-NetworkService\PZ3-NetworkService\Slike";
            op1.Title = "Select a picture";
            op1.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op1.ShowDialog() == true)
            {
                TrenutniServer.Img_src = new Uri(op1.FileName).ToString();
                bmp1 = new BitmapImage(new Uri(op1.FileName));
            }
        }


        public void OnDel()
        {
            //foreach(Server item in PZ3_NetworkService.ViewModel.NetworkViewViewModel.Dropped)
            //{
            bool canD = true;
            foreach(Server s in PZ3_NetworkService.ViewModel.NetworkViewViewModel.Dropped)
            {
                if (s.Id == SelektovanServer.Id)
                {
                    MessageBox.Show("Can't delete because it's used in NetworkViewView.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    canD = false;
                    break;
                }
            }

            if (canD)
            {
                Serveri.Remove(SelektovanServer);
                FilterLista.Clear();
                foreach (var item1 in Serveri)
                {
                    FilterLista.Add(item1);
                }
            }
            /*
            Serveri.Remove(SelektovanServer);
            FilterLista.Clear();
            foreach(var item1 in Serveri)
            {
                FilterLista.Add(item1);
            }
            */

        }

        public bool CanDel()
        {
            return SelektovanServer != null;
        }

        public void OnFilter()
        {
            if (string.IsNullOrEmpty(TekstZaPretragu))
            {
                MessageBox.Show("You must enter ID to filter by!", "Error :(", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                if (!Int32.TryParse(TekstZaPretragu, out int q))
                {
                    MessageBox.Show("ID must be a number!", "Error :'(", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {



                    FilterLista.Clear();
                    foreach (var item in Serveri)
                    {
                        FilterLista.Add(item);
                    }
                    foreach (var item in Serveri)
                    {
                        pomServeri.Add(item);
                    }

                    if ("Less than" == PomID)     //LESS
                    {
                        foreach (var s in pomServeri)
                        {
                            if (s.Id >= int.Parse(TekstZaPretragu))
                            {
                                FilterLista.Remove(s);
                            }
                        }
                    }
                    else if ("Grater than" == PomID) //GRATER
                    {
                        foreach (var s in pomServeri)
                        {
                            if (s.Id <= int.Parse(TekstZaPretragu))
                            {
                                FilterLista.Remove(s);
                            }
                        }
                    }
                    else                                                    //EQUAL
                    {
                        foreach (var s in pomServeri)
                        {
                            if (s.Id != int.Parse(TekstZaPretragu))
                            {
                                FilterLista.Remove(s);
                            }
                        }
                    }
                }
            }

        }
        public void OnRefresh()
        {
            FilterLista.Clear();
            foreach(var item in Serveri)
            {
                FilterLista.Add(item);
            }
            
        }




    }
}
