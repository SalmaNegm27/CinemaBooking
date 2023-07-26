
namespace CinemaBooking.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CinemaController(ICinemaRepository cinemaRepository, IWebHostEnvironment webHostEnvironment)
        {
            _cinemaRepository = cinemaRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize]

        public async Task<IActionResult> Index()
        {
            var cinemas= await _cinemaRepository.GetAllAsync();
            return View(cinemas);
        }
        [Authorize]
        public async Task<IActionResult> Detail(int id)
        {
            var cinema = await _cinemaRepository.GetByIdAsync(id);
            return View(cinema);
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Descripition", "ImageFile")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(cinema.ImageFile.FileName);
            string extension = Path.GetExtension(cinema.ImageFile.FileName);
            cinema.Logo = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            string path = Path.Combine(wwwRootPath + "/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await cinema.ImageFile.CopyToAsync(fileStream);
            }


            await _cinemaRepository.AddAsync(cinema);


            return RedirectToAction("Index");

        }
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaRepository.GetByIdAsync(id);
            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("ID", "Name", "Descripition", "Logo")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }



            await _cinemaRepository.EditAsync(id,cinema);


            return RedirectToAction("Index");

        }
        [Authorize]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cinemaRepository.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var result = await _cinemaRepository.GetByIdAsync(id);
            if (result == null) return View("NotFound");



            await _cinemaRepository.DeleteAsync(id);


            return RedirectToAction(nameof(Index));

        }

    }
}
