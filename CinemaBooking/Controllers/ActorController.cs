

using CinemaBooking.Repositories.ActorRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaBooking.Controllers
{
    public class ActorController : Controller
    {


        private readonly IActorRepository _actorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ActorController(IActorRepository actorRepository, IWebHostEnvironment webHostEnvironment)
        {
            _actorRepository = actorRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var actors = await _actorRepository.GetAllAsync();
            return View(actors);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName", "Bio", "ImageFile")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(actor.ImageFile.FileName);
            string extension = Path.GetExtension(actor.ImageFile.FileName);
            actor.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            string path = Path.Combine(wwwRootPath + "/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await actor.ImageFile.CopyToAsync(fileStream);
            }


            await _actorRepository.AddAsync(actor);


            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Detail(int id)
        {
            var result = await _actorRepository.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _actorRepository.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("ID", "FullName", "Bio", "ImagePath")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
           

            await _actorRepository.EditAsync(id, actor);


            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _actorRepository.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var result = await _actorRepository.GetByIdAsync(id);
            if (result == null) return View("NotFound");
           


            await _actorRepository.DeleteAsync(id);


            return RedirectToAction(nameof(Index));

        }

    }
}



