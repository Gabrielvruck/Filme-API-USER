using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //1 pra 1
            builder.Entity<Endereco>().HasOne(endereco => endereco.Cinema)
                .WithOne(cinema=>cinema.Endereco)
                .HasForeignKey<Cinema>(cinema =>cinema.EnderecoId);

            // 1:n  1 para muitos
            builder.Entity<Cinema>().HasOne(Cinema => Cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId);
            //a funcao logo abaixo faz com o que na hora de deletar o gerente não deleta o cinema junto.
            //obs gerente está como delete em cascata.
            //.OnDelete(DeleteBehavior.Restrict);

            //a funcao logo abaixo faz com o que o gerente não seja obrigatorio no cinema.
            //.IsRequired(false)

            //No modo cascata, se tentarmos deletar um recurso que é dependência de outro, todos os outros recursos que dependem desse serão excluídos também.No modo restrito não conseguiremos efetuar a deleção.

            //-------------------- N:N -------------
            builder.Entity<Sessao>().HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            builder.Entity<Sessao>().HasOne(sessao => sessao.Cinema)
              .WithMany(cinema => cinema.Sessoes)
              .HasForeignKey(sessao => sessao.CinemaId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }
     
        public string ObterStringConexao()
        {
            string strcon = "Data Source =localhost; Initial Catalog =FilmeDB; Integrated Security = true; Encrypt = False; TrustServerCertificate = true";
            return strcon;
        }
    }
}
