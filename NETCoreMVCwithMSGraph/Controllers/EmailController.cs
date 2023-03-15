using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using NETCoreMVCwithMSGraph.Graph;
using NETCoreMVCwithMSGraph.Models;
using System.Net.Mail;

namespace NETCoreMVCwithMSGraph.Controllers
{
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
    public class EmailController : Controller
    {
        private readonly EmailClient _emailClient;
        public EmailController(EmailClient emailClient)
        {
            _emailClient=emailClient;
        }
        public async Task<IActionResult> Index()
        {
            Email email = new Email();
            var messagesPagingData = await _emailClient.GetUserMessagesPage(email.NextLink);
            email.Messages = messagesPagingData.Messages;
            email.NextLink = messagesPagingData.NextLink;
            return View(email);
        }
    }
}
