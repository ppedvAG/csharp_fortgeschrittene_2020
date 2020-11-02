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

        private async void GetFacts(object sender, RoutedEventArgs e)
        {
            var url = $"https://cat-fact.herokuapp.com/facts/random?amount={sl1.Value}";

            var http = new HttpClient();

            var json = await http.GetStringAsync(url);

            jsonTb.Text = json;
        }
    }
}
