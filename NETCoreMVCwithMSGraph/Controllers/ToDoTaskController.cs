using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using NETCoreMVCwithMSGraph.Graph;
using NETCoreMVCwithMSGraph.Models;

namespace NETCoreMVCwithMSGraph.Controllers
{
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
    public class ToDoTaskController : Controller
    {
        private readonly ToDoTaskClient _toDoTaskClient;
        public ToDoTaskController(ToDoTaskClient toDoTaskClient)
        {
            _toDoTaskClient= toDoTaskClient;
        }
        public async Task<IActionResult> Index()
        {
            ToDoTaskModel toDoTaskModel = new ToDoTaskModel();
            var toDoTaskList = await _toDoTaskClient.GetToDoTaskList();
            toDoTaskModel.TaskLists = toDoTaskList;         
            return View(toDoTaskModel);
        }
    }
}
