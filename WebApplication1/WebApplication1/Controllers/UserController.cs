using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using Newtonsoft.Json;
using WebApplication1.DomainModels;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{UserEmail}")]
        public ActionResult GetUser(string UserEmail)
        {
           return Ok(new {Results = JsonConvert.SerializeObject(_userService.GetUser(UserEmail))});

            

        }
        [HttpGet()]
        public ActionResult GetUsers()
        {
            return Ok(new { Results = JsonConvert.SerializeObject(_userService.GetUsers()) });



        }
        [HttpPost("Edit")]
        public ActionResult EditUser([FromBody] User user)
        {

           var results= _userService.EditUserSave(user);    
            if(results.IsCompleted)
                return Ok();
            else
                return BadRequest(results); 

        }

        [HttpPost("Delete")]
        public ActionResult DeleteUser([FromBody] User user)
        {

            var results = _userService.DeleteUser(user);
            if (results.IsCompleted)
                return Ok();
            else
                return BadRequest(results);

        }

        [HttpPost("AddUser")]
        public ActionResult AddUser([FromBody] User user)
        {

            var results = _userService.SaveNewUser(user);
            if (results.IsCompleted)
                return Ok();
            else
                return BadRequest(results);

        }

        [HttpPost("AddMultipleUsersJSON")]
        public ActionResult AddUsers([FromBody]List<User> users)
        {
            List<User> badreqUsers = new List<User>();
            foreach(var user in users)
            {
                var results = _userService.SaveNewUser(user);
                if(results.IsCanceled || results.IsFaulted)
                {
                    badreqUsers.Add(user);  
                }
            }
            if (badreqUsers.Any())
                return BadRequest(badreqUsers);
            else
                return Ok();
           
           
            

        }

       
        [HttpPost("AddMultipleUsersXML")]
        [Consumes("application/xml")]
        public ActionResult AddUsersXML([FromBody] List<User> users)
        {
            List<User> badreqUsers = new List<User>();
            foreach (var user in users)
            {
                var results = _userService.SaveNewUser(user);
                if (results.IsCanceled || results.IsFaulted)
                {
                    badreqUsers.Add(user);
                }
            }
            if (badreqUsers.Any())
                return BadRequest(badreqUsers);
            else
                return Ok();




        }



    }
}