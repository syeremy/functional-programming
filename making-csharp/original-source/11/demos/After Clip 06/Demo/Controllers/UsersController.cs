using System.Linq;
using Demo.Errors;
using Demo.Functional;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private IRepository<User> UsersRepository { get; }

        public UsersController(IRepository<User> usersRepository)
        {
            this.UsersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult GetAll() =>
            Ok(this.UsersRepository.GetAll());

        [HttpGet]
        [Route("{username}", Name = "get-user")]
        public IActionResult Find(string username) =>
            this.UsersRepository.GetAll()
                .FirstOrNone(user => user.UserName == username)
                .Map<User, IActionResult>(Ok)
                .Reduce(NotFound);

        [HttpPost]
        public IActionResult Create([FromBody] InputModels.User user) =>
            this.UsersRepository.AddSafe(user.ToModel())
                .Map(created => (IActionResult)Created(Link(created), created))
                .Reduce(_ => Conflict(), error => error is UserExists)
                .Reduce(_ => InternalServerError());

        private string Link(User user) =>
            Url.Link("get-user", new { username = user.UserName });

        private IActionResult Conflict() =>
            StatusCode(StatusCodes.Status409Conflict);

        private IActionResult InternalServerError() =>
            StatusCode(StatusCodes.Status500InternalServerError);
    }
}