namespace Vote
{
    internal class Program
    {
   



        static void Main(string[] args)

        {
           /* создаём шаблон на 20 вопросов для анкет*/
            Dictionary<string,int> quest = new Dictionary<string, int>();
            for (int i = 0; i <20; i++)
            {
                quest.Add($"quest{i}", 0);
            }
         
         
         /*   создаём персоны и бланки
                персоны отвечают на вопросы*/
            HashSet<Person> pers =new  HashSet<Person>();
            HashSet<Blank> blanks =new  HashSet<Blank>();
            Random random = new Random();
            for (int i = 0; i <30; i++)
            {
                Person persona = new Person(random.Next(18, 100), $"pers{i}");
                pers.Add(persona);

               /* делаем бланки ,с максимальным баллом 100 на 30 персон */
                Blank blank = new Blank(maxBal: 100, new Dictionary<string, int>(quest), id1: i);                
                blank.Answer(persona);

                /*   добавляем бланки*/
                blanks.Add(blank);
            }


            foreach (var item in blanks)
            {
                Console.WriteLine(item+Environment.NewLine+Environment.NewLine);


            }

            /* сохраняем и віводим статистику ключ-вопрос, 
                 значение -(все(<31,31-60,>60))*/

            /*Статистика заполненные анкеты персоной, раскладывает по вопросам с баллами ответов
                и веводит средреее арифметическое по каждому вопросу, а также в разрезе по возрастам персон,
                которые заполнили анкету*/
           /* в CountVote-есть вывод в консоль*/
            Dictionary<string, int[]> statistics
                = new VoteCommision().CountVote(blanks);

        }
    }
}