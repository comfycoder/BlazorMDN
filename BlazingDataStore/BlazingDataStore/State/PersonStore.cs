using BlazingDataStore.Models;
using System.Collections.Generic;

namespace BlazingDataStore.State
{
    public class PersonStore
    {
        public ICollection<Person> People { get; private set; } = new List<Person>();

        public PeopleResponse PeopleResponse { get; set; }

        public void SetPeople(ICollection<Person> people)
        {
            People = people;
        }

        public void SetPeopleResponse(PeopleResponse response)
        {
            People = response.Results;
            PeopleResponse = response;
        }
    }
}
