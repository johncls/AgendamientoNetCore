
using Domain.Abstractions;
using Domain.Product.Event;

namespace Domain.Product
{
    public class Product : Entity
    {
        public Product()
        {
        }
        public Product(
            Guid id,
            string name,
            decimal price,
            int amount,
            string unitOfMeasurement,
            DateTime dateCreated) : base(id)
        {
            Name = name;
            Price = price;
            Amount = amount;
            UnitOfMeasurement = unitOfMeasurement;
            DateCreated = dateCreated;
        }
        /// <summary>
        /// Nomabre del producto
        /// </summary>
        public string Name {get;  set;} = string.Empty;
        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price {get; set; } = 0.0m;
        /// <summary>
        /// Cantidad del producto
        /// </summary>
        public int Amount {get;set;}
        /// <summary>
        /// unidad de medida
        /// </summary>
        public string UnitOfMeasurement {get; set;}
        /// <summary>
        /// Fecha creación del producto 
        /// </summary>
        public DateTime DateCreated {get;  set;}

        public static Product Created( string name, decimal price, int amount, string unitOfMeasurement, DateTime dateCreate){

            var product = new Product(Guid.NewGuid(), name, price, amount, unitOfMeasurement,dateCreate);

            product.RaiseDomainEvent(new ProductCreatedDomainEvent(product.Id));
            return product;
        }
    }
}