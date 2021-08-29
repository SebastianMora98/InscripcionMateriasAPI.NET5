using Microsoft.EntityFrameworkCore;
using Prueba_Conocimiento_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Conocimiento_Backend
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alumno_Materia>()
                .HasKey(am => new { am.AlumnoId, am.MateriaId });

            //modelBuilder.Entity<Alumno_Materia>()
            //    .HasOne(am => am.Alumno)
            //    .WithMany(am => am.Materias)
            //    .HasForeignKey(am => am.AlumnoId);

            //modelBuilder.Entity<Alumno_Materia>()
            //  .HasOne(am => am.Materia)
            //  .WithMany(am => am.Alumnos)
            //  .HasForeignKey(am => am.MateriaId);

        }

        public DbSet<Alumno_Materia> Alumno_Materias { get; set; }



    }
}
