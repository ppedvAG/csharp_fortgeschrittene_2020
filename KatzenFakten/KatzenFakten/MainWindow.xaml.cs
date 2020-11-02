using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;

namespace KatzenFakten
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

        IEnumerable<Fact> result = null;

        private async void GetFacts(object sender, RoutedEventArgs e)
        {
            var url = $"https://cat-fact.herokuapp.com/facts/random?amount={sl1.Value}";

            var http = new HttpClient();

            var json = await http.GetStringAsync(url);

            jsonTb.Text = json;

            result = JsonConvert.DeserializeObject<IEnumerable<Fact>>(json);

            myGrid.ItemsSource = result;
            myLb.ItemsSource = result.Select(x => x.text);
        }

        private void SundayFacts(object sender, RoutedEventArgs e)
        {
            if (result == null)
            {
                MessageBox.Show("Keine Fakten geladen!");
                return;
            }

            //query-expression
            var query = from f in result
                        where f.createdAt.DayOfWeek != System.DayOfWeek.Sunday
                        orderby f.createdAt.Month, f.createdAt.Year descending
                        select f;

            myGrid.ItemsSource = query.ToList();

        }

        private void SundayFactsLambda(object sender, RoutedEventArgs e)
        {
            if (result == null)
            {
                MessageBox.Show("Keine Fakten geladen!");
                return;
            }

            myGrid.ItemsSource = result.Where(f => f.createdAt.DayOfWeek != System.DayOfWeek.Sunday)
                                       .OrderBy(x => x.createdAt.Month).ThenByDescending(x => x.createdAt.Year);

        }

        private void FunMitLinq(object sender, RoutedEventArgs e)
        {
            if (result == null)
            {
                MessageBox.Show("Keine Fakten geladen!");
                return;
            }

            result.Count(x => x.createdAt.DayOfWeek == System.DayOfWeek.Sunday);

            MessageBox.Show(result.Average(x => x.createdAt.Month).ToString());

            var einFact = result.FirstOrDefault(x => x.user == "Fred");
            if (einFact != null)
                MessageBox.Show(einFact.text);

        }
    }
}
