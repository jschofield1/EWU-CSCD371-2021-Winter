using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                List<string> result = new List<string>();
                using (var fileReader = new StreamReader(@$".\People.csv"))
                {
                    for (string? s = fileReader.ReadLine(); !fileReader.EndOfStream; s = fileReader.ReadLine())
                    {
                        result.Add(s!);
                    }
                }
                return result.Skip<string>(1);
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
        {
            SampleData sampleData = new SampleData();
            IEnumerable<IPerson> personCollection = sampleData.People;

            IEnumerable<string> statesList = personCollection.Select(item => item.Address.State).Distinct<string>().OrderBy(s => s);

            return statesList;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            SampleData sample = new SampleData();
            IEnumerable<string> stateCollection = sample.GetUniqueSortedListOfStatesGivenCsvRows();
            string[] stateStringArray = stateCollection.ToArray<string>();
            return String.Join(", ", stateStringArray);
        }

        // 4.
        public IEnumerable<IPerson> People => CsvRows.Select(item =>
        {
            string[] items = item.Split(',');
            Person person = new(items[1], items[2], new Address(items[4], items[5], items[6], items[7]), items[3]);
            return person;
        }).OrderBy(item => item.Address.State)
            .ThenBy(item => item.Address.City)
            .ThenBy(item => item.Address.Zip);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return from Person in People where filter(Person.EmailAddress) select (Person.FirstName, Person.LastName);
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            return people.Select(item => item.Address.State).Distinct().Aggregate((result, next) => result + ", " + next);
        }
    }
}
