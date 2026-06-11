using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaPerfume.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perfumaria.Models;


namespace Perfumaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produtos>>> GetProdutos()
        {
            var ListaProdutos = await _context.produtos.ToListAsync();

            return Ok(ListaProdutos);
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> CriarProduto(Produtos pro)
        {
            var isProdutoExistente = await _context.produtos.AnyAsync(p => p.ProdutoId == pro.ProdutoId);
            if(isProdutoExistente)
            {
                return BadRequest("Produto ja cadastrado!");
            }

            await _context.produtos.AddAsync(pro);
            await _context.SaveChangesAsync();

            return Ok();
        }

       // [HttpPut("{id}")]
       // public async Task<ActionResult<Produtos>> EditarProdutos(Produtos pro)
    }
}