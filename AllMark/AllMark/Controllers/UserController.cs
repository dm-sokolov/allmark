using AllMark.Core.Models;
using AllMark.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AllMark.Controllers
{
    public class UserController: Controller
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ActionResult> Update(User userModel)
        {
            var user = await _userRepository.GetByIdAsync(userModel?.Id);
            user.Name = userModel.Name;
            await _userRepository.UpdateAsync(user);
            return Json(user);
        }
    }
}
