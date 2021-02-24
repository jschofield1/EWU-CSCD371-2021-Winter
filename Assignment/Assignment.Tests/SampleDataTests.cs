using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        [DataRow(@".\People.csv")]
        public void SampleData_CsvRows_ReturnsCollection(string fileName)
        {
            SampleData sampleData = new SampleData();

            IEnumerable<string> testList = new List<String>();

            IEnumerable<string> result = sampleData.CsvRows;

            using (var fileReader = new StreamReader(fileName))
            {
                for (string? s = fileReader.ReadLine(); !fileReader.EndOfStream; s = fileReader.ReadLine())
                {
                    ((List<string>)testList).Add(s!);
                }
            }

            testList = testList.Skip<string>(1);

            CollectionAssert.AreEqual(testList.ToList<string>(), result.ToList<string>());
        }

        [TestMethod]
        public void SampleData_CsvRows_SkipsFirstLine()
        {
            SampleData sampleData = new SampleData();

            IEnumerable<string> result = sampleData.CsvRows;

            Assert.AreNotEqual("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip", result.First<string>());
        }

        [TestMethod]
        public void SampleData_CsvRowsPassedFilePath_LoadsDataProperly()
        {
            SampleData sampleData = new();

            IEnumerable<string> result = sampleData.CsvRows;

            Assert.AreEqual("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", result.First());
        }

        [TestMethod]
        public void SampleData_GetUniqueSortedListOFStatesPassedCsvRows_LinqReturnsOrderedList()
        {
            SampleData sampleData = new();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            bool result = states.SequenceEqual(states.OrderBy(item => item));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SampleData_GetAggregateSortedListOfStatesUsingCsvRows_ReturnsArrayOfStates()
        {
            SampleData sampleData = new SampleData();

            IEnumerable<string> stateCollection = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            string[] expectedStringArray = stateCollection.ToArray<string>();
            string expectedString = String.Join(", ", expectedStringArray);

            string actualString = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SampleData_GetAggregateSortedListOfStatesUsingCsvRows_ReturnsStringofStates()
        {
            SampleData sampleData = new();

            string expected = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
            string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void SampleData_PeopleGivenRows_CreatesSortedPeopleEnum()
        {
            SampleData sampleData = new();

            IEnumerable<IPerson> actual = sampleData.CsvRows.Select(item =>
            {
                string[] items = item.Split(',');
                Person person = new(items[1], items[2], new Address(items[4], items[5], items[6], items[7]), items[3]);
                return person;
            }).OrderBy(item => item.Address.State)
            .ThenBy(item => item.Address.City)
            .ThenBy(item => item.Address.Zip);

            IEnumerable<(IPerson, IPerson)> output = actual.Zip(sampleData.People);

            Assert.IsTrue(output.All(item =>
                (item.Item1.FirstName == item.Item2.FirstName) &&
                (item.Item1.LastName == item.Item2.LastName) &&
                (item.Item1.EmailAddress == item.Item2.EmailAddress)));
        }

        [TestMethod]
        public void SampleData_PeoplePassedHardCodedPerson_FoundInList()
        {
            SampleData sampleData = new();

            Address address = new("7 Onsgard Lane", "Frederick", "MD", "56551");
            Person person = new("Jermaine", "Danelutti", address, "jdaneluttim@jimdo.com");

            bool output = sampleData.People.Any(item =>
            (item.FirstName == person.FirstName &&
            item.LastName == person.LastName &&
            item.EmailAddress == person.EmailAddress &&
            item.Address.StreetAddress == person.Address.StreetAddress &&
            item.Address.City == person.Address.City &&
            item.Address.State == person.Address.State &&
            item.Address.Zip == person.Address.Zip));

            Assert.IsTrue(output);
        }

        [TestMethod]
        public void SampleData_FilterByEmailAddress_ReturnsFilteredList()
        {
            SampleData sampleData = new SampleData();

            IEnumerable<IPerson> expected = sampleData.People;

            expected = expected.Where(item => item.EmailAddress.Equals("cstennine2@wired.com"));
            
            IEnumerable<(string FirstName, string LastName)> expectedTuple = expected.Select(item => (item.FirstName, item.LastName));
            IEnumerable<(string FirstName, string LastName)> filteredList = sampleData.FilterByEmailAddress(item => item.Equals("cstennine2@wired.com"));

            CollectionAssert.AreEqual(expectedTuple.ToList(), filteredList.ToList());
        }

        [TestMethod]
        public void SampleData_FilterByEmailAddressUsingValidPreicate_ReturnsPerson()
        {
            SampleData sampleData = new();

            IEnumerable<(string, string)> actual = sampleData.FilterByEmailAddress(item => item.Contains("addthis"));

            bool firstPerson = actual.Any(item => item.Item1 == "Iggy" && item.Item2 == "Baughen");
            bool secondPerson = actual.Any(item => item.Item1 == "Sayres" && item.Item2 == "Rumble");

            Assert.IsTrue(firstPerson);
            Assert.IsTrue(secondPerson);
        }

        [TestMethod]
        public void SampleData_GetAggregateListOfStatesGivenPeopleCollectionWithValidObject_ReturnsValidString()
        {
            SampleData sampleData = new();

            string actual = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);
            string expected = string.Join(", ", sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

            Assert.AreEqual<string>(expected, actual);
        }
    }
}
