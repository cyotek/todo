using System;

namespace Cyotek.Todo
{
  public class TodoItem
  {
    #region Properties

    public DateTimeOffset Created { get; set; }

    public DateTimeOffset? DueAt { get; set; }
    
    public Guid Id { get; set; }

    public bool IsComplete { get; set; }

    public string OwnerId { get; set; }

    public string Title { get; set; }

    #endregion
  }
}
