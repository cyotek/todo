using System;
using System.Linq;
using System.Threading.Tasks;
using Cyotek.Todo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cyotek.Todo.Services
{
  public class TodoItemService : ITodoItemService
  {
    #region Constants

    private readonly ApplicationDbContext _context;

    #endregion

    #region Constructors

    public TodoItemService(ApplicationDbContext context)
    {
      _context = context;
    }

    #endregion

    #region Methods

    public async Task<TodoItem[]> GetItemsAsync(IdentityUser user)
    {
      return await _context.TodoItems.Where(x => x.OwnerId == user.Id).OrderBy(x => x.DueAt).ThenBy(x => x.Title).ToArrayAsync();
    }

    #endregion

    #region ITodoItemService Interface

    public async Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user)
    {
      int recordsAffected;

      newItem.Id = Guid.NewGuid();
      newItem.OwnerId = user.Id;
      newItem.IsComplete = false;
      newItem.Created = DateTimeOffset.Now;

      _context.TodoItems.Add(newItem);

      recordsAffected = await _context.SaveChangesAsync();

      return recordsAffected == 1;
    }

    public async Task<bool> DeleteItemAsync(Guid id, IdentityUser user)
    {
      int recordsAffected;
      TodoItem item;

      item = await _context.TodoItems.Where(x => x.Id == id && x.OwnerId == user.Id).SingleOrDefaultAsync();

      if (item == null) return false;

      _context.Remove(item);

      recordsAffected = await _context.SaveChangesAsync();

      return recordsAffected == 1; // One entity should have been updated
    }

    public async Task<TodoItem[]> GetCompleteItemsAsync(IdentityUser user)
    {
      return await _context.TodoItems.Where(x => x.OwnerId == user.Id).OrderBy(x => x.DueAt).ThenBy(x => x.Title).ToArrayAsync();
    }

    public async Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user)
    {
      return await _context.TodoItems.Where(x => !x.IsComplete && x.OwnerId == user.Id).OrderBy(x => x.DueAt).ThenBy(x => x.Title).ToArrayAsync();
    }

    public async Task<bool> MarkDoneAsync(Guid id, IdentityUser user)
    {
      int recordsAffected;
      TodoItem item;

      item = await _context.TodoItems.Where(x => x.Id == id && x.OwnerId == user.Id).SingleOrDefaultAsync();

      if (item == null) return false;

      item.IsComplete = true;

      recordsAffected = await _context.SaveChangesAsync();

      return recordsAffected == 1; // One entity should have been updated
    }

    #endregion
  }
}
