using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumaria.Models
{
    public class Produtos
    {
        [Key]
        [Column("produto_id")]
        public int ProdutoId { get; set; }

        [Column("nome")]
        public string NomeProduto { get; set; }

        [Column("marca")]
        public string MarcaProduto { get; set; }

        [Column("categoria")]
        public string CategoriaProduto { get; set; }
        [Column("preco")]
        public decimal PrecoProduto { get; set; }
        [Column("estoque")]
        public int EstoqueProduto { get; set; }
        [Column("imagem_url")]
        public string FotoPerfil { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("data_cadastro")]
        public DateTime CadastroProduto { get; set; }

    }
}