using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public FeedbackController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        [Route("feedback")]
        public IActionResult Feedback()
        {
            return View(nameof(Feedback));
        }

        [HttpPost("send-feedback")]
        public async Task<IActionResult> SendFeedback(FeedbackPostModel model)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback = new Feedback
                {
                    DateCreated = DateTime.Now,
                    Description = model.Description,
                    SenderEmail = "test.email@emailemail.com"
                };

                await _uow.Feedbacks.AddAsync(feedback);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(FeedbackSent));

            }

            return View(nameof(Feedback));
        }
        
        [Route("feedback-sent")]
        public ActionResult FeedbackSent()
        {
            return View();
        }

    }
}
