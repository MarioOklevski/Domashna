using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.WebApp.Models.Domain
{
    public class MovieInShoppingCart
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
