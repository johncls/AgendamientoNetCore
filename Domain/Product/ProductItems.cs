namespace Domain.Product
{
    public class ProductItems
    {
        /// <summary>
        /// Ide del producto
        /// </summary>
        public Guid Id {get;set;}
        /// <summary>
        /// Nomabre del producto
        /// </summary>
        public required string Name {get;  set;}
        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price {get; set; }
        /// <summary>
        /// Cantidad del producto
        /// </summary>
        public int Amount {get;set;}
        /// <summary>
        /// unidad de medida
        /// </summary>
        public required string UnitOfMeasurement {get; set;}
        /// <summary>
        /// Fecha creación del producto 
        /// </summary>
        public DateTime DateCreated {get;  set;}
    }
}