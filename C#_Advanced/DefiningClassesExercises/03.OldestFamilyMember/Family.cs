using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetTheOldestMember()
        {
            Person oldestMember = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestMember;
        }
    }
}
