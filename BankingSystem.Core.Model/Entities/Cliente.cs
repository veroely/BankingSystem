using BankingSystem.Core.Model.Entities.Base;

namespace BankingSystem.Core.Model.Entities
{
    public class Cliente:Persona
    {
        public int IdCliente { get; set; }
        public string Contrasenia { get; set; }
        public  bool EsActivo { get; set; }
    }
}
