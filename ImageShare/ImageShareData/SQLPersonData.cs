using ImageShare.Context;
using ImageShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            personContext.People.Add(person);
            personContext.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            personContext.People.Remove(person);
            personContext.SaveChanges();
        }

        public Person EditPerson(string email,Person person)
        {
            var exisingPerson = getPerson(email);
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

        public Person getPerson(string email)
        {
            Person person = personContext.People.Where(x=> x.email.Equals(email)).FirstOrDefault();
            
            return person;
        }

        public bool login(string email, string password) {
            var person = personContext.People.FromSqlRaw($"select * from people where user_email='" + email + "' and user_password='"+password+"';");
            if (person.ToArray().Length == 1)
            {
                return true;
            }
            return false;
        }

    }
}
