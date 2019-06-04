using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.ViewModels.SoundTrack;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class SoundTrackController : Controller
    {
        private readonly IAppBLL _bll;

        public SoundTrackController(IAppBLL bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexModel();

            model.SoundTracks = (await _bll.SoundTracks.AllAsync()).Select(
                soundTrack => new SoundTrackListModel()
                {
                    Id = soundTrack.Id,
                    Name = soundTrack.Name
                }
            );

            return View(model);
        }
    }
}