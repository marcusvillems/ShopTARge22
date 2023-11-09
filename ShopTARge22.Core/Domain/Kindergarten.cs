using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Domain
{
    public class Kindergarten
    {
        private int v;

        public Kindergarten()
        {
        }

        public Kindergarten(int v)
        {
            this.v = v;
        }

        public Guid? Id { get; set; }
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public string KindergartenName { get; set; }
        public string Teacher { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? KidnergartenName { get; set; }
    }
}
