using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3_NetworkService.Model
{
    public class Server: BindableBase
    {
        private int id;
        private string name;
        private string ipAddress;
        private string img_src;
        private double value;

        public int Id { get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Name { get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string IpAddress { get => ipAddress;
            set
            {
                if (ipAddress != value)
                {
                    ipAddress = value;
                    OnPropertyChanged("IpAddress");
                }
            }
        }
        
        public string Img_src { get => img_src; set => img_src = value; }

        public double Value { get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged("Value");
                }
            }
        }


        public Server()
        {
            Id = 0;
            Name = null;
            IpAddress = null;
            Img_src = null;
            Value = 0;
        }
        public Server(int idd, string namee, string ip, string img, double v)
        {
            Id = idd;
            Name = namee;
            IpAddress = ip;
            Img_src = img;
            Value = v;
        }

        public Server (Server s)
        {
            this.Id = s.Id;
            this.Name = s.Name;
            this.IpAddress = s.IpAddress;
            this.Img_src = s.Img_src;
            this.Value = s.Value;
        }

    }
}
