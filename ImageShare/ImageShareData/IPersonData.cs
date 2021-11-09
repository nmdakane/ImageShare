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

        Person getPerson(Guid id);

        void addPerson(Person person);

        void DeletePerson(Person person);

        Person EditPerson(Person person);

        
    }
}
