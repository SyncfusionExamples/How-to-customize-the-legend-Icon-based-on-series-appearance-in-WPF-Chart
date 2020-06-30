using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LegendIconCustomization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class Data
    {
        public Data(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
    }

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
