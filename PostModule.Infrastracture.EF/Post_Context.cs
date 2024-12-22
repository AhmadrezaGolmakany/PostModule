using Microsoft.EntityFrameworkCore;
using PostModule.Domain.CityEntity;
using PostModule.Domain.PostEntity;
using PostModule.Domain.StateEntity;
using PostModule.Infrastracture.EF.Mapping;
using PostModule.Infrastracture.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Infrastracture.EF
{
    public partial class Post_Context : DbContext
    {
        public Post_Context(DbContextOptions<Post_Context> options)
            :base(options) 
        {
            
        }

        public DbSet<State> states { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<PostPrice> PostPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new StateMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());


            base.OnModelCreating(modelBuilder);
        }
    }
}
