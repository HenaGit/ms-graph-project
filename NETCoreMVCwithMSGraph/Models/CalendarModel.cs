using Microsoft.Graph;

namespace NETCoreMVCwithMSGraph.Models
{
    public class CalendarModel
    {
        public IEnumerable<Event>? Events { get; set; }
        
    }
}
