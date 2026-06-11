using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaPerfume.Models
{
    public class clientes
    {   
        [Key]
        [Column("cliente_id")]
        public int IdCliente { get; set; }

        [Column("nome")]
        public string NomeCliente { get; set; }

        [Column("whatsapp")]
        public string TelefoneCliente {get; set; }

        [Column("email")]
        public string EmailCliente { get; set; }

        [Column("senha")]
        public string SenhaCliente { get; set; }

        [Column("cep")]
        public string CepCliente { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }


    }
}