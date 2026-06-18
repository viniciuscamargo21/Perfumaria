using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumaria.DTO
{
    public class ProdutosBase
    {
        public string NomeProduto {get; set;}

            public string MarcaProduto {get; set;}

            public string CategoriaProduto {get; set;}

            public decimal PrecoProduto {get; set;}

            public int EstoqueProduto {get; set;}

            public string FotoPerfil {get; set;}

            public string Descricao {get; set;}
    }
}