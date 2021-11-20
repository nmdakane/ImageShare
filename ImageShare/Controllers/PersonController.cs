using ImageShare.Models;
using ImageShare.PersonData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonData personData;

        public PersonController(IPersonData a)
        {
            personData = a;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult getUsers()
        {
          
            return Ok(personData.GetPeople());
        }

        [HttpGet]
        [Route("get/{email}")]
        public IActionResult getUser(String email) {
            var user = personData.getPerson(email);
            if (user != null) {
                return Ok(user);
            }
            return NotFound("Person not found");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult loginUser([FromBody] Login user)
        {
            string email = user.username;
            string password = user.password;
            if (personData.login(email,password))
            {
                return Ok(true);
            }
            return NotFound("Person not found");
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddUser(Person person)
        {
            personData.addPerson(person);
            return Ok("Successfully created"+person);

        }

        [HttpDelete]
        [Route("delete/{email}")]
        public IActionResult DeleteUser(String email)
        {
            var user = personData.getPerson(email);
            if (user != null) {
                personData.DeletePerson(user);
                return Ok("User Successfully removed");
            }
            return NotFound("User with email "+ email +" is not found");
        }

        [HttpPatch]
        [Route("update/{email}")]
        public IActionResult updateUser(string email,Person per)
        {
            var newUser = personData.getPerson(email);
            if (newUser != null) {
                per.id = newUser.id;
                personData.EditPerson(email,per);
            }
            return Ok(newUser);
        }

    }
}
