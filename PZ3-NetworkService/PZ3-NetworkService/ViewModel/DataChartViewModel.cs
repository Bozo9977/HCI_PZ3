using PZ3_NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static PZ3_NetworkService.MyCommand;

namespace PZ3_NetworkService.ViewModel
{
    public class DataChartViewModel : BindableBase 
    {
        public MyICommand Prikazi { get; set; }
        private PointCollection points = new PointCollection();
        private string error;

        public string label1 = "\nV\n\nA\n\nL\n\nU\n\nE";
        public ObservableCollection<RectItem> RectItems { get; set; }
        

        private ObservableCollection<Server> objectsChart = new ObservableCollection<Server>();
        public ObservableCollection<Server> ObjectsChart //za combobox
        {
            get
            {
                return objectsChart;
            }

            set
            {
                if (objectsChart != value)
                {
                    objectsChart = value;
                    OnPropertyChanged("ObjectsChart");
                }
            }
        }
        private Server selectedObject;
        public Server SelectedObject
        {
            get => selectedObject;
            set
            {
                selectedObject = value;
                OnPropertyChanged("SelectedObject");
            }
        }




        public DataChartViewModel()
        {
            Prikazi = new MyICommand(OnPrikazi);
            RectItems = new ObservableCollection<RectItem>();
            ObjectsChart = PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri;
        }
        public PointCollection Points
        {
            get { return points; }
            set
            {
                points = value;
                OnPropertyChanged("Points");
            }
        }

        public string Label1
        {
            get { return label1; }
            set
            {
                label1 = value;
                OnPropertyChanged("Label1");
            }
        }

        public string Error { get => error;
            set
            {
                error = value;
                OnPropertyChanged("Error");
            }
        }

        public void OnPrikazi()
        {

            

            
            RectItems.Clear();
            ObservableCollection<RectItem> pomr = new ObservableCollection<RectItem>();
           
            if (SelectedObject != null)
            {

                PointCollection polygonPoints = new PointCollection
            {
                  new Point(20, 20),
                  new Point(20, 250),
                  new Point(20, 320),
                  new Point(680, 320)
            };

                this.Points = polygonPoints;

                Error = "";
                Label1 = "100\n90\n80\n70\n60\n50\n40\n30\n20\n10\n0";

                Server obj = new Server(SelectedObject);
                double[] vrednosti = new double[22];

                for(int i =0; i < 22; i++)
                {
                    vrednosti[i] = 0;
                }
                double[] pomv = new double[22];



                int width = 20;
                int x1 = 30;
                int deset = 10;
                RectItems.Clear();
                string[] s = null;
                s = File.ReadAllLines("LogFile.txt");

                int brojac = 0;
                int kolikovrednosti = 0;

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    string[] line = s[i].Split(' ');
                    DateTime datum = DateTime.Parse(line[1]);
                    if (Int32.Parse(line[3].Split('_')[1]) == obj.Id)
                    {
                        string date = line[0];
                        int id = Int32.Parse(line[3].Split('_')[1]);
                        if (DateTime.Compare(Convert.ToDateTime(line[0]), DateTime.Today) < 0)
                        {
                            continue;
                        }
                        double value = -1;

                        if (Double.TryParse(line[6], out double q))
                        {
                            value = Double.Parse(line[6]);
                        }

                        if (brojac == 22)
                        {
                            break;
                        }
                        else
                        {
                            
                            vrednosti[brojac] = value;
                            kolikovrednosti++;
                            Console.WriteLine(vrednosti[brojac]);
                            brojac++;
                        }
                       
                    }
                }


                for(int i = 0; i<kolikovrednosti; i++)
                {
                    pomv[i] = vrednosti[kolikovrednosti - i -1];
                }

                for(int i = 0; i<22; i++)
                {
                    if(i==0)
                        RectItems.Add(new RectItem { X = x1 + width * i, Y = -315, Height = pomv[i] * 2.9, Width = width });
                    else
                        RectItems.Add(new RectItem { X = x1 + width * i + deset * i, Y = -315, Height = pomv[i] * 2.9, Width = width });
                }
                

            }
            else
            {
                Error = "<- Use this first to select something!";
            }

            
        }
   

    }
}
