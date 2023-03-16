using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_evans18.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        
        public virtual void AddItem(Books bk, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Book.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Books bk)
        {
            Items.RemoveAll(x => x.Book.BookId == bk.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price); //change 25 to PRICE and in CART.cshtml form

            return sum;
        }
    }

   

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }


    }
}
