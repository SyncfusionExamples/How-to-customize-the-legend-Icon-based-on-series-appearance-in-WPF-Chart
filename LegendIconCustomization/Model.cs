namespace LegendIconCustomization
{
    public class Data
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public Data(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}
