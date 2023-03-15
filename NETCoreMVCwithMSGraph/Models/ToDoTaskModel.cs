using Microsoft.Graph;

namespace NETCoreMVCwithMSGraph.Models
{
    public class ToDoTaskModel
    {
      public IEnumerable<TodoTaskList>? TaskLists { get; set; }
    }
}
