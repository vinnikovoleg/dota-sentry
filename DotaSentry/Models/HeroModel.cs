using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaSentry.Models
{
    public class HeroModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string Icon { get; set; }
    }
}
