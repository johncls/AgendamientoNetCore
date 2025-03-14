namespace Domain.Abstractions
{
    public record Error(string Code, string Name)
    {

        public static Error None = new(string.Empty, string.Empty);
        public static Error NullValue = new("Error.NullValue", "Un valor Null fue ingresado");
        public static Error Client = new("cliente", "El cliente ya se encuentra registrado");
        public static Error Product  = new("producto", "El producto ya se encuentra registrado");
        public static Error Invoice = new("La factura", "la factura ya se encuentra registrada");

    }
}