namespace knapsackproblem
{
    public class Thing
    {
        public int Weight { get; }
        public int Value { get; }


        public Thing(int weight, int value)
        {
            Weight = weight;
            Value = value;
        }

        public double EvaluationValue => (double) Value / Weight;
    }
}