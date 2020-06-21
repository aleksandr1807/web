using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebLabs.DAL.Entities;
using WebLabs.Extensions;
using WebLabs.Models;
using Newtonsoft.Json;

namespace WebLabs.Services
{
    public class CartService:Cart
    {
        [Newtonsoft.Json.JsonIgnore]
        public ISession Session;

        public override void AddToCart(Tehnika tehnika)
        {
            base.AddToCart(tehnika);
            Session?.Set<CartService>("Cart", this);
        }
        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>("Cart", this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>("Cart", this);

        }
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            var session = serviceProvider
                .GetRequiredService <IHttpContextAccessor>()?
                .HttpContext
                .Session;
            var cartService = session?.Get<CartService>("Cart")
                ?? new CartService();
            cartService.Session = session;
            return cartService;
        }
    }
}
