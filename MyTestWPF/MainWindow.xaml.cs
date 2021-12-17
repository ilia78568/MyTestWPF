using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
using System.Net;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;
using MyTestWPF.View;

namespace MyTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();

        public ObservableCollection<Post> posts = new ObservableCollection<Post>() { };
        public MainWindow()
        {
            InitializeComponent();

            Post post = JsonConvert.DeserializeObject<Post>(GetUsers("https://jsonplaceholder.typicode.com/posts/3"));
            posts.Add(post);
            Post post2 = JsonConvert.DeserializeObject<Post>(GetUsers("https://jsonplaceholder.typicode.com/posts/4"));
            posts.Add(post2);
            postsList.ItemsSource = posts;

        }
        string GetUsers(string address)
        {
            string responseText;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                {
                    responseText = responseStream.ReadToEnd();
                }
            }
            return responseText;
        }

        private void Add_Post(object sender, RoutedEventArgs e)
        {
            string title = titleText.Text;
            string body = descriptionText.Text;

            Post post = new Post(title, body);

            posts.Add(post);

        }

        private void Delete_Post(object sender, RoutedEventArgs e)
        {
            //Button btn = (Button)sender;
            //int index = int.Parse(btn.Tag.ToString());

        }

        private void Show_Test_Window(object sender, RoutedEventArgs e)
        {
            Window1 testWindow = new Window1();
            testWindow.Show();
            this.Hide();
        }
    }
}
