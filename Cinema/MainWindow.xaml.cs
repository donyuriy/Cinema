using System;
using System.Collections.Generic;
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
namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CinemaHallsRead CHallObj = new CinemaHallsRead();
        Button[,] bt;
        List<string[,]> h1;
        int height = 20;
        int width = 40;
        public MainWindow()
        {
            InitializeComponent();
            grdMain.Children.Clear();
            foreach (string item in CHallObj.GetHallList())
            {
                cbCinemaHall.Items.Add(item);
            }
            cbCinemaHall.SelectedIndex = 0;
            h1 = new List<string[,]>(CHallObj.ReadHallStructure());
            bt = new Button[h1[cbCinemaHall.SelectedIndex].GetLength(0), h1[cbCinemaHall.SelectedIndex].GetLength(1)];
            double x = 0, y = 0;
            for (int i = 0; i < bt.GetLength(0); i++)
            {
                for (int j = 0; j < bt.GetLength(1); j++)
                {
                    bt[i, j] = new Button();
                    bt[i, j].Height = height;
                    bt[i, j].Width = width;
                    bt[i, j].Content = (j + 1).ToString();
                    bt[i, j].Tag = i;
                    y = i * height;
                    if (j == 0)
                        x = 0;
                    x += (width + 1);
                    bt[i, j].Margin = new Thickness(x, y, 0, 0);
                }
            }
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < bt.GetLength(0); i++)
            {
                for (int j = 0; j < bt.GetLength(1); j++)
                {
                    grdMain.Children.Add(bt[i, j]);
                }
            }
        }

        private void cbCinemaHall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grdMain.Children.Clear();
        }

        private void cbMovie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbShowTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
