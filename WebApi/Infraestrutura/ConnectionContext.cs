using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Domain.Model.EmployeeAggregate;
using WebApi.Domain.Model.PersonAggregate;

namespace WebApi.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }

        // Adicione este construtor que aceita DbContextOptions
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações do modelo, se necessário
        }
    }
}
