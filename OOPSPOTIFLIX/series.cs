using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSPOTIFLIX
{
    internal class Series : SharedContent
    {
        
        public List<Episode> Episodes { get; set; }
    }

    internal class Episode : SharedContent
    {
        public int Season { get; set; }
        public int EpisodeNum { get; set; }
        

    }
}
