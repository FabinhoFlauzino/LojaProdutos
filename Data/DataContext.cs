using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Data
{
    // Define uma classe DataContext que herda de DbContext, que representa a conexão com o banco de dados.
    public class DataContext : DbContext
    {
        // Construtor que recebe um parâmetro de configuração (DbContextOptions) para configurar o contexto.
        // O parâmetro 'options' é passado para a classe base (DbContext) para configurar o comportamento do contexto.
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaModel>().HasData(
                new CategoriaModel { Id= 1, Nome = "Tenis" },
                new CategoriaModel { Id= 2, Nome = "Botas" },
                new CategoriaModel { Id= 3, Nome = "Sandalhas" },
                new CategoriaModel { Id= 4, Nome = "Sapatos" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}