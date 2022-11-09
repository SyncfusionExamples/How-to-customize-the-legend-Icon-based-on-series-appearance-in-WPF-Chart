# How to customize the legend icon based on series appearance in WPF Chart (SfChart)?

This example illustrates how to customize the legend icon based on series appearance in [WPF Chart](https://help.syncfusion.com/wpf/charts/getting-started) by following these steps:

**Step 1:** You can display dotted lines in [FastLineSeries](https://help.syncfusion.com/cr/Syncfusion.UI.Xaml.Charts.FastLineSeries.html) by using the [StrokeDashArray](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastLineSeries.html#Syncfusion_UI_Xaml_Charts_FastLineSeries_StrokeDashArray) property.

**Step 2:** The customized line style of [FastLineSeries](https://help.syncfusion.com/cr/Syncfusion.UI.Xaml.Charts.FastLineSeries.html) can be shown in the legend icon by applying the [LegendIconTemplate](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_LegendIconTemplate) as shown in the following code example. 

```
<Grid>
    <Grid.DataContext>
        <local:ViewModel></local:ViewModel>
    </Grid.DataContext>
    <chart:SfChart Margin="10">
        <chart:SfChart.Legend>
            <chart:ChartLegend></chart:ChartLegend>
        </chart:SfChart.Legend>
        <chart:SfChart.PrimaryAxis>
            <chart:CategoryAxis  LabelFormat="MMM/dd"></chart:CategoryAxis>
        </chart:SfChart.PrimaryAxis>
        <chart:SfChart.SecondaryAxis>
            <chart:NumericalAxis ></chart:NumericalAxis>
        </chart:SfChart.SecondaryAxis>
        <chart:FastLineSeries Label="Series 1" StrokeDashArray="1,1" ItemsSource="{Binding DataCollection}" XBindingPath="Date" YBindingPath="Value">
            <chart:FastLineSeries.LegendIconTemplate>
                <DataTemplate >
                    <Polyline Points="0,8,25,8" Stroke="{Binding Interior}" StrokeThickness="{Binding StrokeThickness}" StrokeDashArray="1,1"/>
                </DataTemplate>
            </chart:FastLineSeries.LegendIconTemplate>
        </chart:FastLineSeries>
    </chart:SfChart>
</Grid>
```
```
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
```
```
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
```

### Output:

![LegendIcon Customization WPF Chart](https://user-images.githubusercontent.com/53489303/200763243-f6d50ba1-7c88-443f-8d80-44a07d42e9c3.png)

KB article - [How to customize the legend icon based on series appearance in WPF Chart](https://www.syncfusion.com/kb/11672/how-to-customize-the-legend-icon-based-on-series-appearance-in-wpf-chart)

### See also

[How to modify the label of each legend](https://www.syncfusion.com/kb/4687/how-to-set-or-modify-the-label-of-the-each-legend)

[How to achieve draggable legend in WPF Chart](https://www.syncfusion.com/kb/4687/how-to-set-or-modify-the-label-of-the-each-legend)

[How to create custom legend items in WPF Chart](https://www.syncfusion.com/kb/10675/how-to-create-custom-legenditems-in-wpf-sfchart)

[How to wrap the text in WPF Chart Legend](https://www.syncfusion.com/kb/10996/how-to-wrap-the-text-in-the-wpf-chart-legend)

[How to format the legend text in Chart WPF](https://www.syncfusion.com/kb/4691/how-to-format-the-legend-text)
