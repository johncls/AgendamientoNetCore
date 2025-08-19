using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.GetProducts
{
    public class ProductResponse
    {
        /// <summary>
        /// Guid del producto 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Nomabre del producto
        /// </summary>
        public string Name {get; set;} = string.Empty;
        /// <summary>
        /// Precio del producto
        /// </summary>
        public  decimal Price {get;  set; } = 0.0m;
        /// <summary>
        /// Fecha creación del producto 
        /// </summary>
        public DateTime DateCreated {get; private set;}
    }
}