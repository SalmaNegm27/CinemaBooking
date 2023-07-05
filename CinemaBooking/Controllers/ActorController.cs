

namespace CinemaBooking.Controllers
{
    public class ActorController : Controller
    {


        private readonly ActorRepository _actorRepository;

        public ActorController(ActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }





        public async Task<IActionResult> Index()
        {
            var actors =await _actorRepository.GetAllAsync();
            return View(actors);
        }
    }
}
