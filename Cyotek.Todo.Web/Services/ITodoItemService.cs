using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Cyotek.Todo.Services
{
  public interface ITodoItemService
  {
    #region Methods

    Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user);

    Task<bool> DeleteItemAsync(Guid id, IdentityUser user);

    Task<TodoItem[]> GetCompleteItemsAsync(IdentityUser user);

    Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user);

    Task<bool> MarkDoneAsync(Guid id, IdentityUser user);

    #endregion
  }
}
