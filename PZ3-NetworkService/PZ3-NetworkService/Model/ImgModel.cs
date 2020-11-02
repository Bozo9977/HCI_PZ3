using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3_NetworkService.Model
{
    public class ImgModel
    {
        public string ImgUrl { get; set; }

        public ImgModel()
        {
            ImgUrl = "";
        }

        public ImgModel(string url)
        {
            ImgUrl = url;
        }
    }
}
