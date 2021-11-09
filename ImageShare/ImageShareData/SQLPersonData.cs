using ImageShare.Context;
using ImageShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageShare.PersonData
{
    public class SQLPersonData : IPersonData
    {
        private DatabaseContext personContext;
        public SQLPersonData(DatabaseContext a)
        {
            personContext = a;
        }

        public void addPerson(Person person)
        {
            person.id = new Guid();
            person.dob = DateTime.Now;
            personContext.People.Add(person);
            personContext.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            personContext.People.Remove(person);
            personContext.SaveChanges();
        }

        public Person EditPerson(Person person)
        {
            var exisingPerson = personContext.People.Find(person.id);
            if (exisingPerson != null) {
                personContext.People.Update(person);
                personContext.SaveChanges();
            }
            return person;
        }

        public List<Person> GetPeople()
        {
            return personContext.People.ToList();
        }

        public Person getPerson(Guid id)
        {
            var person = personContext.People.FromSql();
            return person;
        }
    }
}
