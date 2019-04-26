using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchAPI.Models;
using System.Collections.Generic;
using System.Linq;
using PeopleSearchAPI;
using PeopleSearchAPI.Controllers;

namespace PeopleSearchAPI.Tests.Models
{
    [TestClass]
    public class SQLiteDataAccessTest
    {
        [TestMethod]
        public void GetPeople()
        {
            // Arrange
            // No preparations necessary

            // Act
            IEnumerable<Person> responsePeople = SQLiteDataAccess.GetPeople();

            // Assert
            Assert.IsNotNull(responsePeople);
            Assert.AreEqual(10, responsePeople.Count());
            foreach (Person person in responsePeople)
            {
                Assert.IsInstanceOfType(person.Id, typeof(long));
                Assert.IsInstanceOfType(person.Name, typeof(string));
                Assert.IsInstanceOfType(person.Age, typeof(int));
                Assert.IsInstanceOfType(person.Address, typeof(string));
                Assert.IsInstanceOfType(person.CityStateZip, typeof(string));
                Assert.IsInstanceOfType(person.Interests, typeof(string));
                Assert.IsInstanceOfType(person.PictureLocation, typeof(string));
                if (person.Id == 1)
                {
                    Assert.AreEqual(45, person.Age);
                    Assert.AreEqual("Math", person.Interests);
                    Assert.AreEqual("Ketchikan, AK  99901", person.CityStateZip);
                }
            }
        }
    }
}
