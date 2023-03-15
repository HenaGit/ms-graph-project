using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using NETCoreMVCwithMSGraph.Graph;
using NETCoreMVCwithMSGraph.Models;
using System.Diagnostics;


namespace NETCoreMVCwithMSGraph.Controllers
{
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProfileClient _profileClient;
       
        readonly ITokenAcquisition _tokenAcquisition;
        public HomeController(ILogger<HomeController> logger, ProfileClient profileClient, ITokenAcquisition tokenAcquisition)
        {
            _logger = logger;
            _profileClient = profileClient;
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task<IActionResult> Index()
        {
            Profile profile = new Profile();
            var user = await _profileClient.GetUserProfile();
            profile.UserDisplayName = user.DisplayName.Split(' ')[0];
            profile.UserPhoto = await _profileClient.GetUserProfileImage();
            return View(profile);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}