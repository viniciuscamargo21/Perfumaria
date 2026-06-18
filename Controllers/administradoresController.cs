using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaPerfume.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perfumaria.DTO;
using Perfumaria.Models;

namespace Perfumaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class administradoresController : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public administradoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<administradores>>> GetAdm()
        {
            var ListaAdm = await _context.administradores.ToListAsync();

            return Ok(ListaAdm);
        }
            

        [HttpPost]
        public async Task<ActionResult<administradores>> CriarAdm(administradoresBase admcadastro)
        {
            administradores adm = new administradores();

            adm.NomeAdm = admcadastro.NomeAdm;
            adm.EmailAdm = admcadastro.EmailAdm;
            adm.SenhaAdm = admcadastro.SenhaAdm;

            await _context.administradores.AddAsync(adm);
            await _context.SaveChangesAsync();

            return Ok(adm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarAdm(int id)
        {
            var admD = await _context.administradores.FindAsync(id);
            if(admD == null)
            {
                return NotFound($"ADM com id {id} não encontrado");
            }

            string nomeAdm = admD.NomeAdm;

            _context.administradores.Remove(admD);
            await _context.SaveChangesAsync();

            return Ok($"Adm {nomeAdm} deletado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<administradores>> EditarAdm(int id, administradoresBase admEditar)
        {
            var admExistente = await _context.administradores.FindAsync(id);
            if(admExistente == null)
            {
                return NotFound($"Adm com id = {id} não existe!");
            }

            admExistente.NomeAdm = admEditar.NomeAdm;
            admExistente.EmailAdm = admEditar.EmailAdm;
            admExistente.SenhaAdm = admEditar.SenhaAdm;

            _context.administradores.Update(admExistente);
            await _context.SaveChangesAsync();

            return Ok(admExistente);
        }
    }
}