using Microsoft.Graph;
using System.Globalization;

namespace NETCoreMVCwithMSGraph.Graph
{
    public class ToDoTaskClient
    {
        private readonly ILogger<ToDoTaskClient> _logger = null;
        private readonly GraphServiceClient _graphServiceClient = null;
        public ToDoTaskClient(ILogger<ToDoTaskClient> logger, GraphServiceClient graphServiceClient)
        {
            _logger= logger;
            _graphServiceClient= graphServiceClient;
        }
        public async Task<IEnumerable<TodoTaskList>> GetToDoTaskList()
        {
            try
            {
                var toDoList = await _graphServiceClient.Me.Todo.Lists
                            .Request()
                            .GetAsync();
                return toDoList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error calling Graph /me/Todo: {ex.Message}");
                throw;
            }
        }

    }
}
