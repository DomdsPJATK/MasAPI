using System;
using MasAPI.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace MasAPI.Models
{
    public class DataBaseContext : DbContext
    {
        //Definiowanie setow (Tabel) - Do operacji na tabelach
        public DbSet<Person> People { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Fan> Fans { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        
        protected DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            
            
        }
        
        //Konfiguracja polaczenia z mysql hostowanym na dockerze
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=root;database=fcmsDataBase";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            
            //optionsBuilder.UseSqlServer("server=localhost:3306;user=root;password=root;database=fcmsDataBase");
            optionsBuilder.UseMySql(connectionString,serverVersion);
        }
        
        //Definiowanie konfiguracji dla modeli (Relacje, właściwości pól)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new PersonEfConfiguration());
            modelBuilder.ApplyConfiguration(new CoachEfConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerEfConfiguration());
            modelBuilder.ApplyConfiguration(new RefereeEfConfiguration());
            modelBuilder.ApplyConfiguration(new FanEfConfiguration());
            modelBuilder.ApplyConfiguration(new AddressEfConfiguration());
            modelBuilder.ApplyConfiguration(new TeamEfConfiguration());
            modelBuilder.ApplyConfiguration(new MatchEfConfiguration());
            modelBuilder.ApplyConfiguration(new FieldEfConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingEfConfiguration());
            modelBuilder.ApplyConfiguration(new AccessoryEfConfiguration());
            modelBuilder.ApplyConfiguration(new TicketEfConfiguration());
        }
    }
}