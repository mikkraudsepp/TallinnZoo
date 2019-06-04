using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.Animal;
using WebApp.ViewModels.Media;

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
            var model = new AnimalListModel();

            model.Animals = (await _bll.Animals.AllAsync()).Select(
                animal => new AnimalItemModel()
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    Image = animal.FeaturedImgId != null ?
                        new ImageModel()
                        {
                            Name = animal.FeaturedImg.Name,
                            Url = animal.FeaturedImg.Url
                        } : 
                        new ImageModel()
                        {
                            Name = "",
                            Url = ""
                            //TODO icon or default image in no featured image is present
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

            model.AnimalPictures =
                animal.MediaInAnimals.Select(
                    image => new ImageModel
                    {
                        Url = image.Media.Url,
                        Name = image.Media.Name
                    }).ToList();

            model.AnimalSoundTracks =
                animal.AnimalSoundTracks.Select(
                    soundTrack => new SoundTrackModel()
                    {
                        Name = soundTrack.SoundTrack.Name,
                        Url = soundTrack.SoundTrack.Url
                    }).ToList();

            model.Facts =
                (await _bll.AnimalFacts.AllAsync()).Select(
                    fact => new FactModel()
                    {
                        Label = fact.Label,
                        Description = fact.Description
                    });

            return View(model);
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
                        GeoCoordinates = animal.MapSegment.GeoCoordinates.Select(
                            geoCoordinate => new GeoCoordinateModel()
                            {
                                Latitude = geoCoordinate.Latitude,
                                Longitude = geoCoordinate.Longitude
                            }
                        ).ToList()
                    },
                    Image = animal.FeaturedImgId != null ?
                        new ImageModel()
                        {
                            Name = animal.FeaturedImg.Name,
                            Url = animal.FeaturedImg.Url
                        } : 
                        new ImageModel()
                        {
                            Name = "",
                            Url = ""
                            //TODO icon or default image in no featured image is present
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