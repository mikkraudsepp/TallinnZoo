using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.Animal;

namespace WebApp.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAppBLL _bll;

        public AnimalController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var model = new IndexModel();

            model.Animals = (await _bll.Animals.AllAsync()).Select(
                    animal => new AnimalListModel()
                    {
                        Id = animal.Id,
                        Name = animal.Name,
                        Image = new ImageListModel()
                        {
                            Name = animal.FeaturedImg.Name,
                            Url = animal.FeaturedImg.Url
                        }
                    }
                );
            
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var model = new AnimalModel();
            var animal = await _bll.Animals.FindAsync(id);

            model.Id = animal.Id;
            model.Name = animal.Name;
            model.Description = animal.Description;
            model.BinomialName = animal.BinomialName;
            
            var featuredImage = await _bll.Medias.FindAsync(animal.FeaturedImgId);
            if (featuredImage != null)
            {
                model.FeaturedImage = new ImageModel()
                {
                    Name = featuredImage.Name,
                    Url = featuredImage.Url
                };
            }
            
            foreach (var mediaInAnimal in animal.MediaInAnimals)
            {
                model.AnimalPictures.Add(new ImageModel
                {
                    Url = mediaInAnimal.Media.Url,
                    Name = mediaInAnimal.Media.Name
                });
            }
            
            foreach (var soundTrack in animal.AnimalSoundTracks)
            {
                model.AnimalSoundTracks.Add(new SoundTrackModel()
                {
                    Name = soundTrack.SoundTrack.Name,
                    Url = soundTrack.SoundTrack.Url
                });
            }
            
            
//            model.AnimalPictures = (await _uow.Medias.AllAsync()).Select(
//                image => new ImageModel()
//                {
//                    Name = image.Name,
//                    Url = image.Url
//                }
//            );

                model.Facts = (await _bll.AnimalFacts.AllAsync()).Select(
                    fact => new FactModel()
                    {
                        Label = fact.Label,
                        Description = fact.Description
                    }
                );

                return View(model);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> TrackAnimal()
        {
            var model = new TrackAnimalModel();

            model.Animals = (await _bll.Animals.AllAsync()).Select(
                animal => new TrackAnimalListModel()
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    MapSegment = new MapSegmentModel()
                    {
                        Name = animal.MapSegment.Name,
                        Latitude = animal.MapSegment.Latitude,
                        Longitude = animal.MapSegment.Longitude
                    },
                    Image = new ImageListModel()
                    {
                        Name = animal.FeaturedImg.Name,
                        Url = animal.FeaturedImg.Url
                    }
                }
            );
            
            return View(model);
        }

        public IActionResult TrackingStats()
        {
            return View();
        }
    }
}