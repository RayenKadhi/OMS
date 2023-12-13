using Microsoft.AspNetCore.Mvc;
using OMS.Interfaces;

namespace OMS.Data
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var receiver = "kadhimohamedrayen@gmail.com";
            var subject = "Test";
            var message = "Hello World";
            await _emailSender.SendEmailAsync(receiver, subject, message);
            return View();
        }
    }
}
