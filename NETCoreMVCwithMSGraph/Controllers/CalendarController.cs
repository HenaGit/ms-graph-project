using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using NETCoreMVCwithMSGraph.Graph;
using NETCoreMVCwithMSGraph.Models;

namespace NETCoreMVCwithMSGraph.Controllers
{
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly CalendarClient _calendarClient;
        private readonly ProfileClient _profileClient;
        private MailboxSettings? MailboxSettings { get; set; }
        public CalendarController(ILogger<CalendarController> logger, CalendarClient calendarClient, ProfileClient profileClient)
        {
            _logger = logger;
            _calendarClient = calendarClient;
            _profileClient = profileClient;
        }
        public async Task<IActionResult> Index()
        {
            CalendarModel calendarModel = new CalendarModel();
            MailboxSettings = await _calendarClient.GetUserMailboxSettings();
            var userTimeZone = (String.IsNullOrEmpty(MailboxSettings.TimeZone))
                                ? "Pacific Standard Time" : MailboxSettings.TimeZone;
            //calendarModel.Events = await _calendarClient.GetEvents(userTimeZone);
            calendarModel.Events = await _calendarClient.GetEventsAsync();
            return View(calendarModel);
        }
        public string FormatDateTimeTimeZone(DateTimeTimeZone value)
        {
            // Parse the date/time string from Graph into a DateTime
            var graphDatetime = value.DateTime;
            if (DateTime.TryParse(graphDatetime, out DateTime dateTime))
            {
                var dateTimeFormat = $"{MailboxSettings.DateFormat} {MailboxSettings.TimeFormat}".Trim();
                if (!String.IsNullOrEmpty(dateTimeFormat))
                {
                    return dateTime.ToString(dateTimeFormat);
                }
                else
                {
                    return $"{dateTime.ToShortDateString()} {dateTime.ToShortTimeString()}";
                }
            }
            else
            {
                return graphDatetime;
            }
        }
    }
}
