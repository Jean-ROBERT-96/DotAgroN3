using Kernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Batiment> Batiments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAdresse> ClientAdresses { get; set; }
        public DbSet<Devis> Devis { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<HistoriqueClient> HistoriqueClients { get; set; }
        public DbSet<LigneDevis> LigneDevis { get; set; }
        public DbSet<LigneFacture> LigneFactures { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Societe> Societes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Societe>(e =>
            {
                e.HasOne(s => s.AdresseFK)
                    .WithMany()
                    .HasForeignKey(s => s.AdresseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Batiment>(e =>
            {
                e.HasOne(s => s.AdresseFK)
                    .WithMany()
                    .HasForeignKey(s => s.AdresseId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.SocieteFK)
                    .WithMany()
                    .HasForeignKey(s => s.SocieteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Service>(e =>
            {
                e.HasOne(s => s.SocieteFK)
                    .WithMany()
                    .HasForeignKey(s => s.SocieteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.HasOne(s => s.SocieteFK)
                    .WithMany()
                    .HasForeignKey(s => s.SocieteId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.BatimentFK)
                    .WithMany()
                    .HasForeignKey(s => s.BatimentId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.ServiceFK)
                    .WithMany()
                    .HasForeignKey(s => s.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Client>(e =>
            {
                e.HasOne(s => s.SocieteFK)
                    .WithMany()
                    .HasForeignKey(s => s.SocieteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ClientAdresse>(e =>
            {
                e.HasKey(ca => new { ca.ClientId, ca.AdresseId });

                e.HasOne(s => s.ClientPK)
                    .WithMany()
                    .HasForeignKey(s => s.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.AdressePK)
                    .WithMany()
                    .HasForeignKey(s => s.AdresseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<HistoriqueClient>(e =>
            {
                e.HasOne(s => s.ClientFK)
                    .WithMany()
                    .HasForeignKey(s => s.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.SocieteFK)
                    .WithMany()
                    .HasForeignKey(s => s.SocieteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<LigneFacture>(e =>
            {
                e.HasOne(s => s.ArticleFK)
                    .WithMany()
                    .HasForeignKey(s => s.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.Property(ld => ld.FactureId)
                    .HasColumnName("facture_id")
                    .IsRequired();
            });

            modelBuilder.Entity<LigneDevis>(e =>
            {
                e.HasOne(s => s.ArticleFK)
                    .WithMany()
                    .HasForeignKey(s => s.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.Property(ld => ld.DevisId)
                    .HasColumnName("devis_id")
                    .IsRequired();
            });

            modelBuilder.Entity<Facture>(e =>
            {
                e.HasOne(s => s.ClientFK)
                    .WithMany()
                    .HasForeignKey(s => s.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.DevisFK)
                    .WithMany()
                    .HasForeignKey(s => s.DevisId)
                    .OnDelete(DeleteBehavior.SetNull);

                e.HasOne(s => s.AdresseFacturationFK)
                    .WithMany()
                    .HasForeignKey(s => s.AdresseFacturationId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.AdresseLivraisonFK)
                    .WithMany()
                    .HasForeignKey(s => s.AdresseLivraisonId)
                    .OnDelete(DeleteBehavior.SetNull);

                e.HasOne(s => s.SocieteFK)
                    .WithMany()
                    .HasForeignKey(s => s.SocieteId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(e => e.LignesFacture)
                    .WithOne()
                    .HasForeignKey(e => e.FactureId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Devis>(e =>
            {
                e.HasOne(s => s.ClientFK)
                    .WithMany()
                    .HasForeignKey(s => s.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.SocieteFK)
                    .WithMany()
                    .HasForeignKey(s => s.SocieteId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(e => e.LignesDevis)
                    .WithOne()
                    .HasForeignKey(e => e.DevisId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
