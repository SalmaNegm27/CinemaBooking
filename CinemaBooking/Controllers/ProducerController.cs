
using CinemaBooking.Repositories.ProducerRepository;

namespace CinemaBooking.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerRepository _producerrepository;
        public ProducerController(IProducerRepository producerrepository)
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
