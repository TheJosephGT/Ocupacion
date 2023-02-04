using Microsoft.EntityFrameworkCore;



    public class Contexto: DbContext
    {
        public DbSet<Ocupaciones> ocupaciones { get; set; }
        public DbSet<Persona> Persona {get; set;}
        public DbSet<Prestamo> Prestamo {get; set;}

        public Contexto(DbContextOptions <Contexto> options) : base(options)
        {
            
        }
    }