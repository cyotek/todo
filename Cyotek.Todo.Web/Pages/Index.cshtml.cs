using System;
using System.Threading.Tasks;
using Cyotek.Todo.Models;
using Cyotek.Todo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cyotek.Todo.Pages
{
  public class IndexModel : PageModel
  {
    #region Constants

    private readonly ITodoItemService _todoItemService;

    #endregion

    #region Fields

    private TodoItem[] _items;

    #endregion

    #region Constructors

    public IndexModel(UserManager<IdentityUser> userManager, ITodoItemService todoItemService)
      : base(userManager)
    {
      _todoItemService = todoItemService;
    }

    #endregion

    #region Properties

    public TodoItem[] Items
    {
      get { return _items; }
    }

    #endregion

    #region Methods

    public async Task OnGetAsync()
    {
      IdentityUser user;

      user = await this.GetCurrentUser();

      if (user != null)
      {
        _items = await _todoItemService.GetIncompleteItemsAsync(user);
      }
    }

    public async Task<IActionResult> OnPostAddItemAsync(TodoItem item)
    {
      IdentityUser user;

      user = await this.GetCurrentUser();
        await _todoItemService.AddItemAsync(item, user);

      return this.Redirect("./");
    }
    public async Task<IActionResult> OnPostDeleteItemAsync(Guid id)
    {
      IdentityUser user;

      user = await this.GetCurrentUser();
      await _todoItemService.DeleteItemAsync(id, user);

      return this.Redirect("./");
    }
    public async Task<IActionResult> OnPostMarkDoneAsync(Guid id)
    {
      IdentityUser user;

      user = await this.GetCurrentUser();
      await _todoItemService.MarkDoneAsync(id, user);

      return this.Redirect("./");
    }

    #endregion
  }
}
