using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Cyotek.Todo.Models
{
  public class PageModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
  {
    #region Constants

    private readonly UserManager<IdentityUser> _userManager;

    #endregion

    #region Constructors

    protected PageModel(UserManager<IdentityUser> userManager)
    {
      _userManager = userManager;
    }

    #endregion

    #region Properties

    protected UserManager<IdentityUser> UserManager
    {
      get { return _userManager; }
    }

    #endregion

    #region Methods

    public async Task<IdentityUser> GetCurrentUser()
    {
      return await _userManager.GetUserAsync(this.User);
    }

    #endregion
  }
}
