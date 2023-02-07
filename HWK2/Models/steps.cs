namespace HWK2.Models
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
    }
}
