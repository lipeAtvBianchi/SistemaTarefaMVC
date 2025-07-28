using Microsoft.EntityFrameworkCore;
using sistemaAgendamento.Models;

namespace sistemaAgendamento.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options) { }
        
        public DbSet<TarefaModel> Tarefas { get; set; }
    }
}