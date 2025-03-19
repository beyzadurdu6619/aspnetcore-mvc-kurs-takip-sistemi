using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace EntityFreamwork.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){
            
        }       
        public DbSet<Kurs> Kurslar => Set<Kurs>();
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<KursKayit> KursKayit => Set<KursKayit>();
        
         public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();
    }
}