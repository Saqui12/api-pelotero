using Dominio.Entities;
using Dominio.Entities.Identity;
using Dominio.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class PeloterosDbContext : IdentityDbContext<AppUser>
{


    public PeloterosDbContext(DbContextOptions<PeloterosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bloqueo> Bloqueos { get; set; }

    public DbSet<RefreshToken> RefreshToken { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<HorariosDisponibilidad> HorariosDisponibilidads { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Recurso> Recursos { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnectionString");

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Bloqueo>(entity =>
        {
            entity.HasKey(e => e.BloqueoId).HasName("PK__Bloqueos__23A6D9CE349ADE33");

            entity.HasIndex(e => e.Fecha, "idx_bloqueos_fecha");

            entity.Property(e => e.BloqueoId)
                .HasColumnName("bloqueo_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.Motivo)
                .HasColumnType("text")
                .HasColumnName("motivo");
            entity.Property(e => e.RecursoId).HasColumnName("recurso_id");

            entity.HasOne(d => d.Recurso).WithMany(p => p.Bloqueos)
                .HasForeignKey(d => d.RecursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bloqueos__recurs__4AB81AF0");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__47E34D6463C3D9ED");

            entity.HasIndex(e => e.Email, "UQ__Clientes__AB6E616474DE82F3").IsUnique();

            entity.Property(e => e.ClienteId)
                .HasColumnName("cliente_id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<HorariosDisponibilidad>(entity =>
        {
            entity.HasKey(e => e.HorariosDisponibilidadId).HasName("PK__Horarios__5A3872289CFC8D99");

            entity.ToTable("HorariosDisponibilidad");

            entity.Property(e => e.HorariosDisponibilidadId)
                .HasColumnName("horario_id");
            entity.Property(e => e.DiaSemana).HasColumnName("dia_semana");
            entity.Property(e => e.HoraApertura).HasColumnName("hora_apertura");
            entity.Property(e => e.HoraCierre).HasColumnName("hora_cierre");
            entity.Property(e => e.RecursoId).HasColumnName("recurso_id");

            entity.HasOne(d => d.Recurso).WithMany(p => p.HorariosDisponibilidads)
                .HasForeignKey(d => d.RecursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HorariosD__recur__47DBAE45");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PK__Pagos__FFF0A58EA84C92A1");

            entity.Property(e => e.PagoId)
                .HasColumnName("pago_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaPago)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("fecha_pago");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.TransaccionId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("transaccion_id");
            entity.Property(e => e.TurnoId).HasColumnName("turno_id");

            entity.HasOne(d => d.Turno).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.TurnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pagos__turno_id__440B1D61");
        });

        modelBuilder.Entity<Recurso>(entity =>
        {
            entity.HasKey(e => e.RecursoId).HasName("PK__Recursos__054F2526F67C96EA");

            entity.Property(e => e.RecursoId)
                .HasColumnName("recurso_id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioHora)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_hora");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.TurnoId).HasName("PK__Turnos__8E611ADF24DACE81");

            entity.HasIndex(e => e.ClienteId, "idx_turnos_cliente");

            entity.HasIndex(e => new { e.Fecha, e.HoraInicio, e.HoraFin }, "idx_turnos_fecha_hora");

            entity.HasIndex(e => e.RecursoId, "idx_turnos_recurso");

            entity.Property(e => e.TurnoId)
                  .HasColumnName("turno_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaReserva)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto_total");
            entity.Property(e => e.Notas)
                .HasColumnType("text")
                .HasColumnName("notas");
            entity.Property(e => e.RecursoId).HasColumnName("recurso_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turnos__cliente___3F466844");

            entity.HasOne(d => d.Recurso).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.RecursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turnos__recurso___403A8C7D");
        });

        modelBuilder.ApplyConfiguration(new RolesConfiguration());
        modelBuilder.ApplyConfiguration(new RecursoConfiguration());
        modelBuilder.ApplyConfiguration(new ClientesConfiguration());
        modelBuilder.ApplyConfiguration(new HorariosDisponibilidadConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new RolesUserConfiguration());


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
