using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote
{
    internal class Blank
    {
        public int Id { get;private set; }
        int _maxBal;
       public bool IsAnswer { get;private set; }=false;
        
       public Person Person{ get;private set; }

      public  Dictionary<string, int> Questions { get; private set; }

        public Blank(int maxBal)
        {
            _maxBal = maxBal;

            Questions = new Dictionary<string, int>();
        }

        public Blank(int maxBal, Dictionary<string, int> data,int id1) : this(maxBal)
        {
            Questions = data;
            Id=id1;
        }
     
        public void AddQuestion(string str) {

            Questions.Add(str, 0);
        
        }

        /// <summary>
        /// персона заполняет бюлетень
        /// </summary>
        /// <param name="pers"></param>
        public void Answer(Person pers) {
            Person = pers;
            IsAnswer = true;
            Random rnd = new Random();

            foreach (var item in Questions)
            {
                Questions[item.Key] = rnd.Next(_maxBal);
            }

            

            

        
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Questions)
            {
                sb.Append($"вопрос  {item.Key} балл  {item.Value}{Environment.NewLine}");
            };


            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(IsAnswer)}={IsAnswer.ToString()}, {nameof(Person)}={Person},{Environment.NewLine} {nameof(Questions)}={Environment.NewLine}{sb.ToString()}}}";
        }
    }
}
