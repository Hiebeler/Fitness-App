using FitnessApp.respository.GenericRepository;
using FitnessApp.respository.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGenericRepository<User> _userRepository = null;

        public UserController()
        {
            this._userRepository = new GenericRepository<User>();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{uid}")]
        public User Get(Guid uid)
        {
            return _userRepository.GetById(uid);
        }

        [HttpGet]
        [Route("GetByName/{email}")]
        public Guid? GetUserByName(string email)
        {
            User user = null;
            using (var ctx = new fitness_appContext())
            {
                user = ctx.Users.FirstOrDefault(s => s.Email == email);
            }

            if (user == null)
            {
                return null;
            }

            return user.Uid;
        }

        [HttpPost]
        public void Post(User user)
        {
            _userRepository.Insert(user);
            _userRepository.Save();
        }

        [HttpPut()]
        public void Put(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
        }

        [HttpDelete("{uid}")]
        public string Delete(Guid uid)
        {
            string result = _userRepository.Delete(uid);
            _userRepository.Save();
            return result;
        }
    }
}