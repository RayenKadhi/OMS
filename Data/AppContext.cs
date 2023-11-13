using Microsoft.EntityFrameworkCore;
namespace OMS.Data
{
    public class AppContext : DbContext
    {
        public AppContext() { }
        public AppContext(DbContextOptions<AppContext> options) :
              base(options)
        { }
    }
}