namespace BankingSystem.Core.Services.Dto.Cliente
{
    public class ClienteDtoRequestInsert
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
    }
}
