using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumaria.Models
{
    public class ItensPedidos
    {
        [Key]
        [Column("item_id")]
        public int ItemID { get; set; }

        [Column("pedido_id")]
        public int PedidoId { get; set; }

        [Column("produto_id")]
        public int ProdutoId { get; set; }

        [Column("quantidade")]
        public int QuantidadeItens { get; set; }

        [Column("preco_unitario")]
        public decimal PrecoUnitario { get; set; }
    }
}