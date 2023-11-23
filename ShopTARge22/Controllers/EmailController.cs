using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.Controllers
{
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]

        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
