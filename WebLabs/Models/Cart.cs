using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabs.DAL.Entities;

namespace WebLabs.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        public int Count
        {
            get
            {
                return Items.Sum(Items => Items.Value.Quantity);
            }
        }
        public int Val
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Tehnika.Cost);
            }
        }
        public virtual void AddToCart(Tehnika tehnika)
        {
            if (Items.ContainsKey(tehnika.TehnikaId))
                Items[tehnika.TehnikaId].Quantity++;
            else
                Items.Add(tehnika.TehnikaId, new CartItem
                {
                    Tehnika = tehnika,
                    Quantity = 1
                });
        }
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
}
