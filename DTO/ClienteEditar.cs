using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumaria.DTO
{
    public class ClienteEditar
    {
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string EmailCliente { get; set; }
        public string SenhaCliente { get; set; }
        public string CepCliente { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        
    }
}