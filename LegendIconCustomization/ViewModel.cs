namespace LegendIconCustomization
{
    using System.Collections.ObjectModel;

    public class ViewModel
    {
        public int DataCount = 100;

        private Random randomNumber;

        public ObservableCollection<Data> DataCollection { get; set; }

        public ViewModel()
        {
            randomNumber = new Random();
            DataCollection = GenerateData();
        }

        public ObservableCollection<Data> GenerateData()
        {
            ObservableCollection<Data> datas = new ObservableCollection<Data>();

            DateTime date = new DateTime(2000, 1, 1);
            double value = 100;
            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new Data(date, value));
                date = date.Add(TimeSpan.FromDays(5));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }
    }
}
