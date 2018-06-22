using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace Application
{
    public class ShoppingCart
    {
        private readonly IList<ShoppingCartItem> shoppingCartItems = new List<ShoppingCartItem>();

        public void Add(ShoppingCartItem item)
        {
            if (item != null)
            {
                shoppingCartItems.Add(item);
            }
        }

        public string Render()
        {
            var output = new StringBuilder();
            var totalPrice = 0.0m;
            var totalBasePrice = shoppingCartItems.Sum(x => x.BasePrice);

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var price = shoppingCartItem.GetItemPrice();
                totalPrice += price;
                output.AppendLine(String.Format("{0}: {1}", shoppingCartItem.Product.Name, price));
            }

            output.AppendLine(String.Format("Salex Taxes: {0}", totalPrice - totalBasePrice));
            output.AppendLine(String.Format("Total: {0}", totalPrice));

            return output.ToString();
        }
    }
}
