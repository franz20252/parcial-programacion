using Microsoft.EntityFrameworkCore;
using parcial_programacion.Models;

namespace parcial_programacion.Data;

public class MascotaDbContext(DbContextOptions<MascotaDbContext> options) : DbContext(options)
{
    public DbSet<Mascota> Mascotas => Set<Mascota>();
}