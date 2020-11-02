using PZ3_NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static PZ3_NetworkService.MyCommand;

namespace PZ3_NetworkService.ViewModel
{
    public class NetworkViewViewModel : BindableBase
    {
        private bool dragging = false;
        private Server draggedItem = null;
        private string err = null;
        public Server DraggedItem
        {
            get { return draggedItem; }
            set { draggedItem = value; }
        }
        public MyICommand<Canvas> DropCanvas { get; set; }
        public MyICommand MouseLeftButtonUp { get; set; }
        public MyICommand<ListView> SelectionChanged { get; set; }

        public MyICommand<Canvas> FreeCanvas1 { get; set; }
        public MyICommand<Canvas> FreeCanvas2 { get; set; }
        public MyICommand<Canvas> FreeCanvas3 { get; set; }
        public MyICommand<Canvas> FreeCanvas4 { get; set; }
        public MyICommand<Canvas> FreeCanvas5 { get; set; }
        public MyICommand<Canvas> FreeCanvas6 { get; set; }
        public MyICommand<Canvas> FreeCanvas7 { get; set; }
        public MyICommand<Canvas> FreeCanvas8 { get; set; }
        public MyICommand<Canvas> FreeCanvas9 { get; set; }
        public MyICommand<Canvas> FreeCanvas10 { get; set; }
        public MyICommand<Canvas> FreeCanvas11 { get; set; }
        public MyICommand<Canvas> FreeCanvas12 { get; set; }
        public MyICommand<Canvas> FreeCanvas13 { get; set; }
        public MyICommand<Canvas> FreeCanvas14 { get; set; }
        public MyICommand<Canvas> FreeCanvas15 { get; set; }

        public static ObservableCollection<Server> Objekti { get; set; }
        public static ObservableCollection<Server> Dropped { get; set; }
        public static ObservableCollection<Server> Provera { get; set; }
        

        private Server selectedObject;
        public Server SelectedObject
        {
            get { return selectedObject; }
            set
            {
                selectedObject = value;
            }
        }

        public string Err { get => err;
            set
            {
                err = value;
                OnPropertyChanged("Err");
            }
        }

        public NetworkViewViewModel()
        {
            //Objekti = new BindingList<Road>();
            Objekti = new ObservableCollection<Server>();
            Dropped = new ObservableCollection<Server>();
            Provera = new ObservableCollection<Server>();
            draggedItem = new Server();
            DropCanvas = new MyICommand<Canvas>(OnRunDropCanvas);
            MouseLeftButtonUp = new MyICommand(OnRunMouseLeftButtonUp);
            SelectionChanged = new MyICommand<ListView>(OnRunSelectionChanged);

            FreeCanvas1 = new MyICommand<Canvas>(OnRunFreeCanvas1);
            FreeCanvas2 = new MyICommand<Canvas>(OnRunFreeCanvas2);
            FreeCanvas3 = new MyICommand<Canvas>(OnRunFreeCanvas3);
            FreeCanvas4 = new MyICommand<Canvas>(OnRunFreeCanvas4);
            FreeCanvas5 = new MyICommand<Canvas>(OnRunFreeCanvas5);
            FreeCanvas6 = new MyICommand<Canvas>(OnRunFreeCanvas6);
            FreeCanvas7 = new MyICommand<Canvas>(OnRunFreeCanvas7);
            FreeCanvas8 = new MyICommand<Canvas>(OnRunFreeCanvas8);
            FreeCanvas9 = new MyICommand<Canvas>(OnRunFreeCanvas9);
            FreeCanvas10 = new MyICommand<Canvas>(OnRunFreeCanvas10);
            FreeCanvas11 = new MyICommand<Canvas>(OnRunFreeCanvas11);
            FreeCanvas12 = new MyICommand<Canvas>(OnRunFreeCanvas12);
            FreeCanvas13 = new MyICommand<Canvas>(OnRunFreeCanvas13);
            FreeCanvas14 = new MyICommand<Canvas>(OnRunFreeCanvas14);
            FreeCanvas15 = new MyICommand<Canvas>(OnRunFreeCanvas15);
            
            for (int i = 0; i < PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri.Count; i++)
            {
                Objekti.Add(PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri[i]);
            }
             Objekti = PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri;
            

            Task.Run(() =>
            {
                while (true)
                {
                    Err = null;
                    menjaju();

                  

                    System.Threading.Thread.Sleep(500);
                }
            
           });



        }

        public void menjaju()
        {
            foreach (Server item in Dropped)
            {
                foreach (Server item1 in PZ3_NetworkService.ViewModel.NetworkDataViewModel.Serveri)
                {
                    if (item.Id == item1.Id)
                    {
                        if (item1.Value > 75 || item1.Value < 45)
                        {
                            if (string.IsNullOrEmpty(Err))
                            {
                                Err = "Value of: " + item.Name + " is critical!";
                            }
                            else
                            {
                                Err = Err + "\n" + "Value of: " + item.Name + " is critical!";
                            }
                        }
                            //MessageBox.Show("Value of: " + item.Name + " is critical!", "WARNING!", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }
                }
            }
        }

        private void OnRunSelectionChanged(ListView ListViewObjects)
        {
            if (!dragging)
            {
                DraggedItem = new Server(SelectedObject);
                dragging = true;
                DragDrop.DoDragDrop(ListViewObjects, DraggedItem, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
        private void OnRunDropCanvas(Canvas canvas)
        {
            if (DraggedItem != null)
            {
                if ((canvas).Resources["taken"] == null)
                {
                    if (DraggedItem.Img_src != null)
                    {
                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.UriSource = new Uri(DraggedItem.Img_src, UriKind.RelativeOrAbsolute);
                        img.EndInit();



                        (canvas).Background = new ImageBrush(img);
                    }
                    ((TextBlock)(canvas).Children[0]).Text = DraggedItem.Id.ToString() + ". " + DraggedItem.Name + " " + DraggedItem.IpAddress;
                    ((TextBlock)(canvas).Children[0]).Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
                    ((TextBlock)(canvas).Children[0]).Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF808080"));
                    (canvas).Resources.Add("taken", true);

                    for (int i = 0; i < Objekti.Count; i++)
                    {
                        if (Objekti[i].Id == DraggedItem.Id)
                        {
                            Dropped.Add(Objekti[i]);
                            //Objekti.RemoveAt(i);
                        }
                    }

                    if (DraggedItem.Value<45 || DraggedItem.Value > 75)
                    {
                        if (string.IsNullOrEmpty(Err))
                        {
                            Err = "Value of: " + DraggedItem.Name + " is critical!";
                        }
                        else
                        {
                            Err = Err + "\n" + "Value of: " + DraggedItem.Name + " is critical!";
                        }
                    }

                    OnPropertyChanged("Objekti");
                }
                DraggedItem = null;
                dragging = false;
            }
        }
        private void OnRunMouseLeftButtonUp()
        {
            DraggedItem = null;
            selectedObject = null;
            dragging = false;
            
        }
        private void OnRunFreeCanvas1(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }

                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas2(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas3(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas4(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas5(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas6(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas7(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas8(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas9(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas10(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas11(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas12(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas13(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas14(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }
        private void OnRunFreeCanvas15(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                char[] delimiters = new char[] { '.' };
                string[] words = ((TextBlock)(canvas).Children[0]).Text.Split(delimiters);
                int id = Int32.Parse(words[0]);

                foreach (Server r in Dropped.ToList())
                {
                    if (r.Id == id)
                    {
                        Dropped.Remove(r);
                    }
                }
                canvas.Background = Brushes.White;
                ((TextBlock)(canvas).Children[0]).Text = "Available";
                ((TextBlock)(canvas).Children[0]).Foreground = Brushes.Black;
                ((TextBlock)(canvas).Children[0]).Background = Brushes.MediumSpringGreen;
                (canvas).Resources.Remove("taken");
            }
        }


    }
}
