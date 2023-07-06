

using CinemaBooking.Repositories.ActorRepository;

namespace CinemaBooking.Controllers
{
    public class ActorController : Controller
    {


        private readonly IActorRepository _actorRepository;

        public ActorController(IActorRepository actorRepository)
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
