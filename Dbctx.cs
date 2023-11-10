using WebAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Controllers;

namespace WebAppMVC
{
    public class Dbctx:DbContext
    {
        public Dbctx(DbContextOptions<DbContext> options) : base(options) 
        {

        
        }
        public DbSet<MyDbModel>DATA { get; set; }
        //public DbSet<MyDbModel> Models{ get; set; }
    }
}
