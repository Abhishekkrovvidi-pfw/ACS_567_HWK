namespace HWK4.Models
{
    public class steps
    {
        /// <summary>
        /// Takes input for the day in week along with the steps made on that day.
        /// </summary>
        public int Id { get; set; }

        public string Day { get; set; }

        public int StepsToday { get; set; }



        public steps()
        {

        }

        public static string Reports(List<steps> s)
        {

            var totalSteps = s.Sum(x => x.StepsToday);

            var avgSteps = s.Average(x => x.StepsToday);



            string result = "";

            result += String.Format("Total Steps made Till Date: " + totalSteps);
            result += String.Format("\t Your Average Steps : " + avgSteps);

            return result;
        }



    }
}
