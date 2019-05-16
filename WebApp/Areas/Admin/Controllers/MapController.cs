using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Domain.Map;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Admin.ViewModels.Map.MapSegment;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MapController : Controller
    {
        private readonly IAppBLL _bll;


        public MapController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _bll.MapSegments.Remove(id);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(MapSegmentDeleted));
        }
        
        public ActionResult MapSegmentDeleted()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> MapSegmentAdd(MapSegmentModel model)
        {
            if (ModelState.IsValid)
            {
                var mapSegment = new MapSegment()
                {
                    Name = model.Name
                };

                await _bll.MapSegments.AddAsync(mapSegment);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(MapSegment), new {id = mapSegment.Id});
            }

            return View(nameof(MapSegmentAdd));
        }

        public ActionResult MapSegmentAdd()
        {
            var model = new MapSegmentModel();
            return View(model);
        }
        
        [Route("maps-segment-added")]
        public ActionResult MapSegmentAdded()
        {
            return View();
        }

        public async Task<IActionResult> MapSegments()
        {
            var model = new MapSegmentListModel();

            model.MapSegments = (await _bll.MapSegments.AllAsync()).Select(
                mapSegment => new MapSegmentItemModel()
                {
                    Id = mapSegment.Id,
                    Name = mapSegment.Name
                }
            );

            return View(model);
        }

        public async Task<IActionResult> MapSegment(Guid id)
        {
            var mapSegment = await _bll.MapSegments.FindAsync(id);

            if (mapSegment == null)
            {
                return NotFound();
            }
            
            var model = new MapSegmentModel();

            model.Name = mapSegment.Name;
            model.Id = mapSegment.Id;
            model.GeoCoordinates = mapSegment.GeoCoordinates.Select(
                geoCoordinate => new GeoCoordinateModel()
                {
                    Id = geoCoordinate.Id,
                    Latitude = geoCoordinate.Latitude,
                    Longitude = geoCoordinate.Longitude,
                    MapSegmentId = mapSegment.Id
                }
            ).ToList();


            return View(model);
        }

        public async Task<IActionResult> GeoCoordinate(Guid mapSegmentId)
        {
            var mapSegment = await _bll.MapSegments.FindAsync(mapSegmentId);

            if (mapSegment == null)
            {
                return NotFound();
            }

            var model = new GeoCoordinateModel();
            model.MapSegmentId = mapSegment.Id;
            model.MapSegmentName = mapSegment.Name;

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> GeoCoordinateAdd(GeoCoordinate model)
        {
            if (ModelState.IsValid)
            {
                var geoCoordinate = new GeoCoordinate()
                {
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    MapSegmentId = model.MapSegmentId,
                    Created = DateTime.Now
                };

                await _bll.GeoCoordinates.AddAsync(geoCoordinate);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(MapSegment), new {id = model.MapSegmentId});
            }

            return View(nameof(GeoCoordinate));
        }
        
        [HttpPost]
        public async Task<IActionResult> GeoCoordinateDelete(Guid id)
        {
            var geoCoordinate = await _bll.GeoCoordinates.FindAsync(id);

            if (geoCoordinate == null)
            {
                return NotFound();
            }

            _bll.GeoCoordinates.Remove(geoCoordinate);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(MapSegment), new {id = geoCoordinate.MapSegmentId});
        }

    }
}