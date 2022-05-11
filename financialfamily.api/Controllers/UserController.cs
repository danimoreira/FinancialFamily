using financialfamily.api.Models.Request;
using financialfamily.api.Models.Response;
using financialfamily.domain.Entity.AuthenticationContext;
using financialfamily.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financialfamily.api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public List<UserResponseViewModel> GetAll()
        {
            var users = _userServices.GetAll();
            var result = users
                                        .Select(x => (UserResponseViewModel)x)
                                        .ToList();
            return result;
        }

        [HttpGet("{id}")]
        public UserResponseViewModel GetById(Guid id)
        {
            var user = _userServices.GetById(id);

            return user;
        }

        [HttpPost]
        public UserResponseViewModel Insert(UserRequestCreateViewModel userCreate)
        {
            _userServices.Create(userCreate);
            var userObj = (User)userCreate;

            return userObj;
        }

        [HttpPut]
        public bool Authenticate(string userName, string password)
        {
            var user = _userServices.Autenticate(username: userName, password: password);
            return (user != null);
        }
    }
}
