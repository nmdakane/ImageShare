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
        [Route("get/{id}")]
        public IActionResult getUser(Guid id) {
            var user = personData.getPerson(id);
            if (user != null) {
                return Ok(personData.getPerson(id));
            }
            return NotFound("Person not found");
        }

        [HttpPut]
        [Route("add")]
        public IActionResult AddUser(Person person)
        {
            personData.addPerson(person);
            return Created(HttpContext.Request.Scheme + "//"+ HttpContext.Request.Host+ HttpContext.Request.Path+"/"+person.id,person);

        }

        [HttpDelete]
        [Route("delete/{person}")]
        public IActionResult DeleteUser(Person per)
        {
            var user = personData.getPerson(per.id);
            if (user != null) {

                return Ok();
            }
            return NotFound("User with id "+ per.id+" is not found");
        }

        [HttpPatch]
        [Route("update/{person}")]
        public IActionResult updateUser(Guid id,Person per)
        {
            var newUser = personData.getPerson(id);
            if (newUser != null) {
                per.id = newUser.id;
                personData.EditPerson(per);
            }
            return Ok(personData.getPerson(id));
        }

    }
}
