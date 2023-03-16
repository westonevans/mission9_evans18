﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mission9_evans18.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mission9_evans18.Models
{
    public class SessionBasket :Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;
            
            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }


        public override void AddItem(Books bk, int qty)
        {
            base.AddItem(bk, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Books bk)
        {
            base.RemoveItem(bk);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
