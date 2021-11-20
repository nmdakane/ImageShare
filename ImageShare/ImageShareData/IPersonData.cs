using ImageShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageShare.PersonData
{
    public interface IPersonData
    {
        List<Person> GetPeople();

        Person getPerson(String email);

        bool login(string email, string password);

        void addPerson(Person person);

        void DeletePerson(Person person);

        Person EditPerson(string email,Person person);

        
    }
}
