using Calculatorwebapi.model;
using Microsoft.EntityFrameworkCore;

namespace Calculatorwebapi.Database
{
    public class Dbcontextclass :DbContext
    {
        public Dbcontextclass(DbContextOptions<Dbcontextclass> options) : base(options)
        {

        }

        public DbSet <Calculatormodel> calculatormodel { get; set; }
    }

    
   
}
