using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace MeuApp.Context
{
    public class AgendaContexto : DbContext
    {
        public AgendaContexto(DbContextOptions<AgendaContexto> options) : base(options)
        {

        }
        
        public DbSet<Contato> Contatos { get; set; }
    }
}