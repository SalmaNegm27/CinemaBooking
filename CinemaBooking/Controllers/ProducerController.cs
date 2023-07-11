
using CinemaBooking.Repositories.ProducerRepository;

namespace CinemaBooking.Controllers
{
    public class ProducerController : Controller
    {

        private readonly IProducerRepository _producerrepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProducerController(IProducerRepository producerrepository, IWebHostEnvironment  webHostEnvironment)
        {
            _producerrepository = producerrepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
           var producers= await _producerrepository.GetAllAsync();
            return View(producers);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName","Bio","ImageFile")]Producer producer)
         {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(producer.ImageFile.FileName);
            string extension = Path.GetExtension(producer.ImageFile.FileName);
            producer.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            string path = Path.Combine(wwwRootPath + "/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await producer.ImageFile.CopyToAsync(fileStream);
            }


            await _producerrepository.AddAsync(producer);


            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Detail(int id)
        {
            var result = await _producerrepository.GetByIdAsync(id);
            if (result == null) return View("Empty");
            return View(result);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var result = await _producerrepository.GetByIdAsync(id);
            if (result == null) return View("Empty");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("ID","FullName", "Bio", "ImagePath")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            

            await _producerrepository.EditAsync(id,producer);


            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _producerrepository.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var result = await _producerrepository.GetByIdAsync(id);
            if (result == null) return View("NotFound");



            await _producerrepository.DeleteAsync(id);


            return RedirectToAction(nameof(Index));

        }
    }
}
