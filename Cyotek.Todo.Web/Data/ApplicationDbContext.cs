using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cyotek.Todo.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    #region Constructors

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    { }

    #endregion

    #region Properties

    public DbSet<TodoItem> TodoItems { get; set; }

    #endregion
  }
}
