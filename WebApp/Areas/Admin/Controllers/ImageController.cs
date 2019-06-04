using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.ViewModels.Image;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class ImageController : Controller
    {
        private readonly IAppBLL _bll;

        public ImageController(IAppBLL bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexModel();

            model.Images = (await _bll.Medias.AllAsync()).Select(
                image => new ImageListModel()
                {
                    Id = image.Id,
                    Name = image.Name,
                    Url = image.Url
                }
            );

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(ImageModel model)
        {
            if (ModelState.IsValid)
            {

                string filePath = "wwwroot/media/image/" + model.ImageFile.FileName; //TODO config upload paths
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                var image = new Media()
                {
                    Name = model.Name,
                    Url = "media/image/" + model.ImageFile.FileName, //TODO config upload paths
                    UploadedDateTime = DateTime.Now,
                    FileType = model.ImageFile.ContentType
                };

                //image.Name = new MultiLangString();
                //image.Name = model.Name;

                await _bll.Medias.AddAsync(image);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new {id = image.Id});
            }

            return View(nameof(Add));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _bll.Medias.Remove(id);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(ImageDeleted));
        }

        public ActionResult ImageDeleted()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ImageModel model)
        {
            var image = await _bll.Medias.FindAsync(model.Id);

            if (image == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                image.Name = model.Name;

                _bll.Medias.Update(image);
                await _bll.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new {id = model.Id});
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var image = await _bll.Medias.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            var model = new ImageModel
            {
                Id = image.Id,
                Name = image.Name,
                Url = image.Url,
                UploadedDateTime = image.UploadedDateTime
            };


            return View(model);
        }
    }
}