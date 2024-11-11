using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Models
{
    /// <summary>
    /// Contexto de la base de datos para la aplicación Challenge, que configura las entidades y sus relaciones.
    /// </summary>
    public partial class ChallengedbContext : DbContext
    {
        public ChallengedbContext()
        {
        }

        public ChallengedbContext(DbContextOptions<ChallengedbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Conjunto de datos de los estados en la base de datos.
        /// </summary>
        public virtual DbSet<Estado> Estados { get; set; }

        /// <summary>
        /// Conjunto de datos de los archivos médicos en la base de datos.
        /// </summary>
        public virtual DbSet<TArchivoMedico> TArchivoMedicos { get; set; }

        /// <summary>
        /// Conjunto de datos de tipos de archivos médicos en la base de datos.
        /// </summary>
        public virtual DbSet<TipoArchivoMedico> TipoArchivoMedicos { get; set; }

        /// <summary>
        /// Configura las entidades y sus relaciones en el modelo de base de datos.
        /// </summary>
        /// <param name="modelBuilder">El generador de modelos que se utiliza para configurar las entidades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado).HasName("estado_pkey");
                entity.ToTable("estado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TArchivoMedico>(entity =>
            {
                entity.HasKey(e => e.IdArchivoMedico).HasName("t_archivo_medico_pkey");
                entity.ToTable("t_archivo_medico");

                entity.Property(e => e.IdArchivoMedico).HasColumnName("id_archivo_medico");
                entity.Property(e => e.Audiometria)
                    .HasMaxLength(2)
                    .HasColumnName("audiometria");
                entity.Property(e => e.CambioArea)
                    .HasMaxLength(2)
                    .HasColumnName("cambio_area");
                entity.Property(e => e.CambioPuesto)
                    .HasMaxLength(2)
                    .HasColumnName("cambio_puesto");
                entity.Property(e => e.DatosMadre)
                    .HasMaxLength(2000)
                    .HasColumnName("datos_madre");
                entity.Property(e => e.DatosOtroFamiliar)
                    .HasMaxLength(2000)
                    .HasColumnName("datos_otro_familiar");
                entity.Property(e => e.DatosPadre)
                    .HasMaxLength(2000)
                    .HasColumnName("datos_padre");
                entity.Property(e => e.Diagnostico)
                    .HasMaxLength(100)
                    .HasColumnName("diagnostico");
                entity.Property(e => e.EjectuarMicros)
                    .HasMaxLength(2)
                    .HasColumnName("ejectuar_micros");
                entity.Property(e => e.EjecutarExtra)
                    .HasMaxLength(2)
                    .HasColumnName("ejecutar_extra");
                entity.Property(e => e.EvaluacionVoz)
                    .HasMaxLength(2)
                    .HasColumnName("evaluacion_voz");
                entity.Property(e => e.FecBaja).HasColumnName("fec_baja");
                entity.Property(e => e.FecIng).HasColumnName("fec_ing");
                entity.Property(e => e.FecMod).HasColumnName("fec_mod");
                entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
                entity.Property(e => e.IdEstado).HasColumnName("id_estado");
                entity.Property(e => e.IdTipoArchivoMedico).HasColumnName("id_tipo_archivo_medico");
                entity.Property(e => e.Incapacidad)
                    .HasMaxLength(2)
                    .HasColumnName("incapacidad");
                entity.Property(e => e.JuntaMedica)
                    .HasMaxLength(200)
                    .HasColumnName("junta_medica");
                entity.Property(e => e.MotivoBaja)
                    .HasMaxLength(2000)
                    .HasColumnName("motivo_baja");
                entity.Property(e => e.Observaciones)
                    .HasMaxLength(2000)
                    .HasColumnName("observaciones");
                entity.Property(e => e.PorcentajeIncap)
                    .HasPrecision(10)
                    .HasColumnName("porcentaje_incap");
                entity.Property(e => e.UserBaja)
                    .HasMaxLength(2000)
                    .HasColumnName("user_baja");
                entity.Property(e => e.UserIng)
                    .HasMaxLength(2000)
                    .HasColumnName("user_ing");
                entity.Property(e => e.UserMod)
                    .HasMaxLength(2000)
                    .HasColumnName("user_mod");

                entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.TArchivoMedicos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("fk_id_estado_archivo");

                entity.HasOne(d => d.IdTipoArchivoMedicoNavigation).WithMany(p => p.TArchivoMedicos)
                    .HasForeignKey(d => d.IdTipoArchivoMedico)
                    .HasConstraintName("fk_id_tipo_archivo");
            });

            modelBuilder.Entity<TipoArchivoMedico>(entity =>
            {
                entity.HasKey(e => e.IdTipoArchivoMedico).HasName("tipo_archivo_medico_pkey");
                entity.ToTable("tipo_archivo_medico");

                entity.Property(e => e.IdTipoArchivoMedico).HasColumnName("id_tipo_archivo_medico");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
