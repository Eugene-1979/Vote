using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote
{
    internal class Person : IEquatable<Person?>
    {
       public int Age { get; private set; }
       public string Name { get; private set; }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }/// <summary>
        /// persona voted
        /// </summary>
        /// <param name="blank"></param>
        void Vote(Blank blank) {
            blank.Answer(this);
        }

        public override string ToString()
        {
            return $"{{{nameof(Age)}={Age.ToString()}, {nameof(Name)}={Name}}}";
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person? other)
        {
            return other is not null &&
                   Age == other.Age &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Age, Name);
        }

        public static bool operator ==(Person? left, Person? right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person? left, Person? right)
        {
            return !(left == right);
        }
    }
}
