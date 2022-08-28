namespace BankingSystem.Core.Services.Dto.Cliente
{
    public class ClienteDtoRequestUpdate
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
        public bool EsActivo { get; set; }
    }
}
