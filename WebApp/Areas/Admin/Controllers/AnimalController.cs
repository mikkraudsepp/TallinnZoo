using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Domain.Animals;
using Domain.Map;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Admin.ViewModels.Animal;
using AnimalModel = WebApp.Areas.Admin.ViewModels.Animal.AnimalModel;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnimalController : Controller
    {
        private readonly IAppBLL _bll;


        public AnimalController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var model = new IndexModel();

            model.Animals = (await _bll.Animals.AllAsync()).Select(
                animal => new AnimalListModel()
                {
                    Id = animal.Id,
                    Name = animal.Name
                }
            );

            return View(model);
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var animal = await _bll.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            var model = new AnimalModel();
            model.Id = animal.Id;
            model.Name = animal.Name;
            model.Description = animal.Description;
            model.BinomialName = animal.BinomialName;
            model.ConservationStatusId = animal.ConservationStatusId;

            if (animal.MapSegment != null)
            {
                model.MapSegment = new MapSegmentModel()
                {
                    Id = animal.MapSegment.Id,
                    Name = animal.MapSegment.Name
                };
            }
            else
            {
                model.MapSegment = new MapSegmentModel();
            }

            model.ConservationStatuses = (await _bll.ConservationStatuses.AllAsync()).Select(
                conservationStatus => new SelectListItem()
                {
                    Selected = conservationStatus.Id == animal.ConservationStatusId,
                    Value = conservationStatus.Id.ToString(),
                    Text = conservationStatus.Name
                }
            ).ToList();

            var featuredImage = await _bll.Medias.FindAsync(animal.FeaturedImgId);
            if (featuredImage != null)
            {
                model.FeaturedImage = new ImageModel()
                {
                    Id = featuredImage.Id,
                    Name = featuredImage.Name,
                    Url = featuredImage.Url
                };
            }

            model.MapSegmentsSelectListItems = (await _bll.MapSegments.AllAsync()).Select(
                mapSegment => new SelectListItem()
                {
                    Selected = mapSegment.Id == animal.MapSegment.Id,
                    Value = mapSegment.Id.ToString(),
                    Text = mapSegment.Name
                }
            ).ToList();

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(AnimalModel model)
        {
            if (ModelState.IsValid)
            {
                var animal = new Animal()
                {
                    Name = model.Name,
                    Description = model.Description,
                    BinomialName = model.BinomialName
                };

                await _bll.Animals.AddAsync(animal);
                await _bll.SaveChangesAsync();


                return RedirectToAction(nameof(AnimalAdded));
            }

            return View(nameof(Add));
        }

        public ActionResult AnimalAdded()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _bll.Animals.Remove(id);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(AnimalDeleted));
        }

        [Route("animal-deleted")]
        public ActionResult AnimalDeleted()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(AnimalModel model)
        {
            var animal = await _bll.Animals.FindAsync(model.Id);

            if (animal == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                animal.Name = model.Name;
                animal.Description = model.Description;
                animal.BinomialName = model.BinomialName;
                animal.ConservationStatusId = model.ConservationStatusId;

                animal.Name = model.Name;
                animal.Description = model.Description;
                animal.BinomialName = model.BinomialName;

                var mapSegment = await _bll.MapSegments.FindAsync(model.MapSegment.Id);

                if (mapSegment != null)
                {
                    //animal.MapSegment = mapSegment;
                    mapSegment.Animal = animal;
                }

                _bll.MapSegments.Update(mapSegment);
                //_bll.Animals.Update(animal);
                await _bll.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new {id = model.Id});
        }
    }
}