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
    public class AdminController : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAdm()
        {
            var ListaAdm = await _context.admin.ToListAsync();

            return Ok(ListaAdm);
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> CriarAdm(Admin admin)
        {
            var isAdmExistente = await _context.admin.AnyAsync(a => a.EmailAdm == admin.EmailAdm);
            if(isAdmExistente)
            {
                return BadRequest("Adm ja cadastrado!");
            }

            await _context.admin.AddAsync(admin);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}