using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabs.DAL.Entities;

namespace WebLabs.Models
{
    public class CartItem
    {

        public Tehnika Tehnika { get; set; }
        public int Quantity { get; set; }
    }
}
