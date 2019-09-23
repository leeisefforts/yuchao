using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class Site
    {
        public int Id { get; set; }

        public int VenueId { get; set; }

        public string SiteName { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
