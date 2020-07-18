using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AccountService.Models
{
    public partial class OnlinebankingContext : DbContext
    {
        public OnlinebankingContext()
        {
        }

        public OnlinebankingContext(DbContextOptions<OnlinebankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<AmountTransfer> AmountTransfer { get; set; }
        public virtual DbSet<Benificiary> Benificiary { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CustState> CustState { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConnection"));
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNo)
                    .HasColumnName("account_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Created)
                   .HasColumnName("created")
                   .HasColumnType("datetime");


            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.AccTypeId);

                entity.Property(e => e.AccTypeId).HasColumnName("acc_type_id");

                entity.Property(e => e.AccTypeName)
                    .HasColumnName("acc_type_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AmountTransfer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromAccount)
                    .HasColumnName("from_account")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToAccount)
                    .HasColumnName("to_account")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Benificiary>(entity =>
            {
                entity.ToTable("benificiary");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BenId).HasColumnName("ben_id");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.HasOne(d => d.Ben)
                    .WithMany(p => p.BenificiaryBen)
                    .HasForeignKey(d => d.BenId)
                    .HasConstraintName("FK_benificiary_Customer1");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.BenificiaryCust)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_benificiary_Customer");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.ContId);

                entity.Property(e => e.ContId).HasColumnName("cont_id");

                entity.Property(e => e.ContName)
                    .HasColumnName("cont_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.StateName)
                    .HasColumnName("state_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.AccTypeId).HasColumnName("acc_type_id");

                entity.Property(e => e.AccountNo)
                    .HasColumnName("account_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContId).HasColumnName("cont_id");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contact_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustAddress)
                    .HasColumnName("cust_address")
                    .IsUnicode(false);

                entity.Property(e => e.CustEmail)
                    .HasColumnName("cust_email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasColumnName("cust_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustPassword)
                    .HasColumnName("cust_password")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustUserName)
                    .HasColumnName("cust_user_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.InitialAmount)
                    .HasColumnName("initial_amount")
                    .HasColumnType("money");

                entity.Property(e => e.Pan)
                    .HasColumnName("pan")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AccType)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.AccTypeId)
                    .HasConstraintName("FK_Customer_AccountType");

                entity.HasOne(d => d.Cont)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.ContId)
                    .HasConstraintName("FK_Customer_Country");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Customer_CustState");
            });
        }
    }
}
