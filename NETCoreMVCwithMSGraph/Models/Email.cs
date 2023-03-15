using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace NETCoreMVCwithMSGraph.Models
{
    public class Email
    {
        [BindProperty(SupportsGet = true)]
        public string NextLink { get; set; }
        public IEnumerable<Message>? Messages { get; set; }
    }
}
