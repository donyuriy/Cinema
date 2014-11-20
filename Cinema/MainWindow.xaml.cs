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
        SoldPlacesDataContext db = new SoldPlacesDataContext();
        CinemaHallsRead CHallObj = new CinemaHallsRead();
        Button[,] bt;   // массив мест в зале
        List<string[,]> h1; //список расположения кресел в залах
        int height = 40;    //параметры мест(элементов) в зале(Button)
        int width = 40;
        public MainWindow()
        {
            InitializeComponent();
            foreach (string item in CHallObj.GetHallList())
            {
                cbCinemaHall.Items.Add(item);   //заполнение ComboBox имён залов
            }
            cbCinemaHall.SelectedIndex = 0;
            cbCinemaHall_SelectionChanged(null,null);   //вызов смены зала для отрисовки мест
            //РАБОТА С БД-----------------------------------------
            //ShowTime [] showtime = new ShowTime[10];
            try
            {
                var x = (from a in db.Tickets select a).ToArray();
            }
            catch (Exception e)
            {
                errLbl.Content = e.Message;
            }
           
            

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
            int numberToTagCounter = 0;
            for (int i = 0; i < bt.GetLength(0); i++)
            {

                int columnCounter = 0;
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
                        columnCounter++;
                        numberToTagCounter++;
                        bt[i, j] = new Button();
                        bt[i, j].Height = height;
                        bt[i, j].Width = width;
                        bt[i, j].Content = columnCounter.ToString();
                        bt[i, j].Tag = numberToTagCounter;
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
                        columnCounter++;
                        numberToTagCounter++;
                        bt[i, j] = new Button();
                        bt[i, j].Height = height;
                        bt[i, j].Width = width;
                        bt[i, j].Content = columnCounter.ToString();
                        bt[i, j].Tag = numberToTagCounter;
                        bt[i, j].Background = Brushes.Coral;
                        y = i * height;
                        if (j == 0)
                            x = 0;
                        x += (width + 1);
                        bt[i, j].Margin = new Thickness(x, y, 0, 0);
                        bt[i, j].Click += Button_Click;
                    }
                }
            }
            for (int i = 0; i < bt.GetLength(0); i++)
            {
                for (int j = 0; j < bt.GetLength(1); j++)
                {
                    if (bt[i, j] == null)
                        continue;                   //если на месте элемента null
                    grdMain.Children.Add(bt[i, j]); //добавление мест на форму
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
           // MessageBox.Show("button " + (sender as Button).Content, "Tag " + (sender as Button).Tag);
        }

        private void cbMovie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbShowTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
