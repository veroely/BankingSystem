namespace BankingSystem.Core.Services.Dto.Cliente
{
    public class ClienteDtoResponse
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
        public bool EsActivo { get; set; }
    }
}
