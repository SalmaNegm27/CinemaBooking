
namespace CinemaBooking.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ProducerRepository _producerrepository;
        public ProducerController(ProducerRepository producerrepository)
        {
            _producerrepository = producerrepository;
        }

        public async Task<IActionResult> Index()
        {
           var producers= await _producerrepository.GetAllAsync();
            return View(producers);
        }
    }
}
