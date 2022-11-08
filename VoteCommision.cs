using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote
{


 class SummaryStatistic {
        public SummaryStatistic(string Question)
        {
            Question = Question;
        }

        public string Question { get; set; }
            public int[] Summary { get; set; } = new int[4];




        }




    internal class VoteCommision
    {

       


        public Dictionary<string, int[]> CountVote(IEnumerable<Blank> lst) {

            Dictionary<string, int[]> keyValues = new Dictionary<string, int[]>();
            

            foreach (var item in lst.First().Questions)
            {
                keyValues.Add(item.Key,new int[4]);
            }



            int v_do30 = 0;
            int v_ot31_60 = 0;
            int v_ot61 = 0;
            int itogo = 0;
            foreach (var blank in lst)
            {
                if (!blank.IsAnswer) continue;
  
                foreach (var question in blank.Questions)
                {
                    itogo++;
                    string str = question.Key;
                        int ball = question.Value;
                    keyValues[str][0] += ball;
                  

                    if (blank.Person.Age < 31) {
                        v_do30++;


                        keyValues[str][1] += ball;
                    }
                    else if (blank.Person.Age < 61) {
                        v_ot31_60++;

                        keyValues[str][2] += ball;
                    }
                    else {
                        v_ot61++;

                        keyValues[str][3] += ball;
                    }
                    continue;
                }


            }

            foreach (var item in keyValues)
            {
                var temp = item.Value;
                if (itogo != 0)
                {
                    temp[0] *= keyValues.Count();
                    temp[0] /= itogo;
                }

                if (v_do30 != 0) 
                { temp[1] *= keyValues.Count();
                    temp[1] /= v_ot31_60 ; }

                if (v_ot31_60 != 0) {temp[2] *= keyValues.Count();
                temp[2] /= v_ot31_60; }




                if (v_ot61 != 0) {
                    temp[3] *= keyValues.Count();
                    temp[3] /= v_ot61;
                
                }
                Console.WriteLine($"Вопрос {item.Key}  средний " +
                    $"{temp[0]}  " +
                    $"до30лет      {temp[1]}бал   " +
                    $"31-60лет       {temp[2]}бал   " +
                    $" от61лет       {temp[3]}бал");

            }


            return keyValues;
        
        }

      
    }
}
