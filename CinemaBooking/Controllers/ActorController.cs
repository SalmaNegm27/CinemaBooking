

using CinemaBooking.Repositories.ActorRepository;
using System.Linq;

namespace CinemaBooking.Controllers
{
    public class ActorController : Controller
    {


        private readonly IActorRepository _actorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ActorController(IActorRepository actorRepository,IWebHostEnvironment webHostEnvironment)
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
        public async Task<IActionResult> Create([Bind("FullName", "Bio", "ImageFiles")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName= Path.GetFileNameWithoutExtension(actor.ImageFile.FileName);
                string extension= Path.GetExtension(actor.ImageFile.FileName);
                actor.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                string path = Path.Combine(wwwRootPath+"/Images",fileName);


               

                _actorRepository.AddAsync(actor);
              

                return RedirectToAction("Index");
            }
            else
            {
                return View(actor); 
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _actorRepository.GetByIdAsync(id);
            if (result == null) return View("Empty");
            return View(result);
        }

    }
}



