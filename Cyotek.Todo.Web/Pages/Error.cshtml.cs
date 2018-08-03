using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cyotek.Todo.Pages
{
  public class ErrorModel : PageModel
  {
    #region Properties

    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

    #endregion

    #region Methods

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public void OnGet()
    {
      this.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
    }

    #endregion
  }
}
