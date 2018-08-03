using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cyotek.Todo.Pages
{
  public class AboutModel : PageModel
  {
    #region Properties

    public string Message { get; set; }

    #endregion

    #region Methods

    public void OnGet()
    {
      this.Message = "Your application description page.";
    }

    #endregion
  }
}
