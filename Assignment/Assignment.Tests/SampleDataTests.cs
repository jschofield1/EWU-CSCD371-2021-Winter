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
        const int firstName = 1;
        const int lastName = 2;
        const int emailAddress = 3;
        const int streetAddress = 4;
        const int city = 5;
        const int state = 6;
        const int zip = 7;

        [TestMethod]
        [DataRow(@".\People.csv")]
        public void CsvRows_GivenData_ReturnsCollection(string fileName)
        {
            SampleData sampleData = new SampleData();

            IEnumerable<string> expected = new List<String>();

            IEnumerable<string> actual = sampleData.CsvRows;

            using (var fileReader = new StreamReader(fileName))
            {
                for (string? line = fileReader.ReadLine(); !fileReader.EndOfStream; line = fileReader.ReadLine())
                {
                    ((List<string>)expected).Add(line!);
                }
            }

            expected = expected.Skip<string>(1);

            CollectionAssert.AreEqual(expected.ToList<string>(), actual.ToList<string>());
        }
        
        [TestMethod]
        public void CsvRows_GivenCsvRows_FirstLineNotHeader()
        {
            SampleData sampleData = new();

            string expected = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";

            IEnumerable<string> result = sampleData.CsvRows;
            string actual = result.First();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUniqueSortedListOFStates_GivenUniqueSortedListOfStates_LinqReturnsOrderedList()
        {
            SampleData sampleData = new();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            bool statesInOrder = states.SequenceEqual(states.OrderBy(item => item));

            Assert.IsTrue(statesInOrder);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStates_GivenUniqueSortedListOfStates_ReturnsArrayOfStates()
        {
            SampleData sampleData = new SampleData();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            string[] statesArray = states.ToArray<string>();
            string expected = String.Join(", ", statesArray);

            string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStates_GivenAggregateSortedListOfStates_ReturnsStringofStates()
        {
            SampleData sampleData = new();

            string expected = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
            
            string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void People_GivenCsvRows_CreatesSortedPeopleEnum()
        {
            SampleData sampleData = new();

            IEnumerable<IPerson> result = sampleData.CsvRows.Select(item =>
            {
                string[] items = item.Split(',');
                Person person = new(items[firstName], items[lastName], new Address(items[streetAddress], items[city], items[state], items[zip]), items[emailAddress]);
                return person;
            }).OrderBy(item => item.Address.State)
            .ThenBy(item => item.Address.City)
            .ThenBy(item => item.Address.Zip);

            IEnumerable<(IPerson, IPerson)> output = result.Zip(sampleData.People);

            Assert.IsTrue(output.All(item =>
                (item.Item1.FirstName == item.Item2.FirstName) &&
                (item.Item1.LastName == item.Item2.LastName) &&
                (item.Item1.EmailAddress == item.Item2.EmailAddress)));
        }

        [TestMethod]
        public void People_GivenHardCodedPerson_FindsPersonInList()
        {
            SampleData sampleData = new();

            Address address = new("7 Onsgard Lane", "Frederick", "MD", "56551");
            Person person = new("Jermaine", "Danelutti", address, "jdaneluttim@jimdo.com");

            bool correctPerson = sampleData.People.Any(item =>
            (item.FirstName == person.FirstName &&
            item.LastName == person.LastName &&
            item.EmailAddress == person.EmailAddress &&
            item.Address.StreetAddress == person.Address.StreetAddress &&
            item.Address.City == person.Address.City &&
            item.Address.State == person.Address.State &&
            item.Address.Zip == person.Address.Zip));

            Assert.IsTrue(correctPerson);
        }

        [TestMethod]
        public void FilterByEmailAddress_GivenPeopleObject_ReturnsFilteredList()
        {
            SampleData sampleData = new SampleData();

            IEnumerable<IPerson> result = sampleData.People;
            result = result.Where(item => item.EmailAddress.Equals("cstennine2@wired.com"));
            IEnumerable<(string FirstName, string LastName)> expectedTuple = result.Select(item => (item.FirstName, item.LastName));
            
            IEnumerable<(string FirstName, string LastName)> filteredList = sampleData.FilterByEmailAddress(item => item.Equals("cstennine2@wired.com"));

            CollectionAssert.AreEqual(expectedTuple.ToList(), filteredList.ToList());
        }

        [TestMethod]
        public void FilterByEmailAddress_FilterBySpecificStringInEmailAddress_ValidPersonInResults()
        {
            SampleData sampleData = new();

            IEnumerable<(string, string)> result = sampleData.FilterByEmailAddress(item => item.Contains("addthis"));
            bool containsExpectedString = result.Any(item => item.Item1 == "Iggy" && item.Item2 == "Baughen");

            Assert.IsTrue(containsExpectedString);
        }

        [TestMethod]
        public void GetAggregateListOfStates_GivenAggregateListOfStates_ReturnsExpectedString()
        {
            SampleData sampleData = new();

            string actual = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);
            
            string expected = string.Join(", ", sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

            Assert.AreEqual<string>(expected, actual);
        }
    }
}
