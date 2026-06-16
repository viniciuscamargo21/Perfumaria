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

        [HttpPut("{id}")]
        public async Task<ActionResult<Produtos>> EditarProdutos(int id)
        {
            var produtoExistente = await _context.produtos.FindAsync(id);
            if(produtoExistente == null)
            {
                return NotFound($"Produto com id = {id} não encontrado!");
            }

            _context.produtos.Update(produtoExistente);
            await _context.SaveChangesAsync();

            return Ok(produtoExistente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            var produto = await _context.produtos.FindAsync(id);
            if(produto == null)
            {
                return NotFound($"Produto com o id = {id} não encontrado!");
            }
            _context.produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return Ok("Usuario deletado com sucesso!");
        }
    }
}