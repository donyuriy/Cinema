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
        SoldPlaces db = new SoldPlaces();
        CinemaHallsRead CHallObj = new CinemaHallsRead();
        Button[,] bt;
        List<string[,]> h1;
        int height = 40;
        int width = 40;
        public MainWindow()
        {
            InitializeComponent();
            grdMain.Children.Clear();
            foreach (string item in CHallObj.GetHallList())
            {
                cbCinemaHall.Items.Add(item);   //заполнение ComboBox имён залов
            }
            cbCinemaHall.SelectedIndex = 0;
            cbCinemaHall_SelectionChanged(null,null);   //вызов смены зала для отрисовки мест
            var showTime = from st in db. select st;
                 
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
        }

        private void cbCinemaHall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grdMain.Children.Clear();
            h1 = new List<string[,]>(CHallObj.ReadHallStructure());
            bt = new Button[h1[cbCinemaHall.SelectedIndex].GetLength(0), h1[cbCinemaHall.SelectedIndex].GetLength(1)];
            double x = 0, y = 0;

            for (int i = 0; i < bt.GetLength(0); i++)
            {
                int counter = 0;
                for (int j = 0; j < bt.GetLength(1); j++)
                {
                    if (Convert.ToInt32(h1[cbCinemaHall.SelectedIndex][i, j]) == 0)
                    {   //места помеченные "0" это проходы и пустые пространства
                        y = i * height;
                        if (j == 0)
                            x = 0;
                        x += (width + 1);
                    }
                    if (Convert.ToInt32(h1[cbCinemaHall.SelectedIndex][i, j]) == 1)
                    {   //места помеченные "1" - первая ценовая категория
                        counter++;
                        bt[i, j] = new Button();
                        bt[i, j].Height = height;
                        bt[i, j].Width = width;
                        bt[i, j].Content = counter.ToString();
                        bt[i, j].Tag = i;
                        bt[i, j].Background = Brushes.Green;
                        y = i * height;
                        if (j == 0)
                            x = 0;
                        x += (width + 1);
                        bt[i, j].Margin = new Thickness(x, y, 0, 0);
                        bt[i, j].Click += Button_Click;
                    }
                    if (Convert.ToInt32(h1[cbCinemaHall.SelectedIndex][i, j]) == 2)
                    {   //места помеченные "2" - вторая ценовая категория
                        counter++;
                        bt[i, j] = new Button();
                        bt[i, j].Height = height;
                        bt[i, j].Width = width;
                        bt[i, j].Content = counter.ToString();
                        bt[i, j].Tag = i;
                        bt[i, j].Background = Brushes.Coral;
                        y = i * height;
                        if (j == 0)
                            x = 0;
                        x += (width + 1);
                        bt[i, j].Margin = new Thickness(x, y, 0, 0);
                        bt[i, j].Click += Button_Click;
                    }
                    else
                    {
                    }
                }
            }
            for (int i = 0; i < bt.GetLength(0); i++)
            {
                for (int j = 0; j < bt.GetLength(1); j++)
                {
                    if (bt[i, j] == null)
                        continue;
                    grdMain.Children.Add(bt[i, j]);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
        }

        private void cbMovie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbShowTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
