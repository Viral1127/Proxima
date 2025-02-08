using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class MyTaskController : Controller
    {
        public IActionResult TaskList()
        {
            ViewBag.DelayedTasks = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> {
                    { "title", "Research competitors and market trends." },
                    { "project", "Tipe Website 2.0" },
                    { "timeAgo", "1 month ago" },
                    { "assignee", "/Content/images/user1.png" } // Change to real image URL
                }
            };

            ViewBag.OtherTasks = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> {
                    { "title", "Implement the website from design" },
                    { "project", "OptiFlow: Growth" },
                    { "assignee", "/Content/images/user2.png" }
                },
                new Dictionary<string, string> {
                    { "title", "Integrate plugins or third-party services" },
                    { "project", "OptiFlow: Growth" },
                    { "assignee", "/Content/images/user3.png" }
                },
                new Dictionary<string, string> {
                    { "title", "Track performance and adjust strategies" },
                    { "project", "Reactify: FB Ads" },
                    { "assignee", "/Content/images/user4.png" }
                }
            };

            return View();
        }
    }
}
