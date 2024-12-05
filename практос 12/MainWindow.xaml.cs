using System.Text;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace практос_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();


        }
        /// <summary>
        /// закрывает программу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Информация о задании
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Реализовать расчет задачи:\r\n• Даны три точки A, B, C на числовой оси. Точка C расположена между точками A и B. Найти произведение длин отрезков AC и BC.\r\n• Дано трехзначное число. Найти сумму и произведение его цифр.\r\n", "Задание", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// Информация о разработчике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Андрианов Алексей Вариант 14", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// Очистка всех полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            tbA.Clear();
            tbB.Clear();
            tbC.Clear();
            tbComposition.Text = "";
            tbNumber.Clear();
            tblSum.Text = "";
            tblProiz.Text = "";

        }
        /// <summary>
        /// Таймер включается при загрузке окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Windows_Louded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            tblTime.Text = now.ToString("HH:mm");
            tblData.Text = now.ToString("dd:MM:yyyy");
            timer.Start();
        }
        /// <summary>
        /// метод для подсчета сторон и их произведения 
        /// </summary>
        /// <param name="a">координата точки А</param>
        /// <param name="b">координата точки В</param>
        /// <param name="c">координата точки С</param>
        /// <returns></returns>
        private double Composition(double a, double b, double c)
        {
            double AC = c - a;
            double CB = b - c;
            double product = AC * CB;
            return product;
        }
        /// <summary>
        /// Находим произведенние
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComposition_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbA.Text, out double A) && double.TryParse(tbB.Text, out double B) && double.TryParse(tbC.Text, out double C))
            {
                if(A < C && A < B && C < B)
                {
                    tbComposition.Text = Convert.ToString(Composition(A, B, C));
                    tbA.Clear();
                    tbA.Focus();
                    tbB.Clear();
                    tbC.Clear();
                }
                else MessageBox.Show("А должно быть меньше С, а С меньше В", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Введите коректные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Находим сумму и произведенние цифр числа
        /// </summary>
        /// <param name="number">число</param>
        /// <param name="sum">сумма цифр числа</param>
        /// <param name="product">произведенние цифр числа</param>
        private void CompositionAndSum(int number, out int sum, out int product)
        {
            int num1 = number / 100;
            int num2 = (number / 10) % 10;
            int num3 = number % 10;
            sum = num1 + num2 + num3;
            product = num1 * num2 * num3;
        }
        /// <summary>
        /// Находим сумму и произведенние цифр числа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompositionAndSum_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbNumber.Text, out int number) && number >= 100 && number <= 999)
            {
                int sum = 0;
                int product = 1;
                CompositionAndSum(number, out sum, out product);
                tblSum.Text = sum.ToString();
                tblProiz.Text = product.ToString();
                tbNumber.Clear();
                tbNumber.Focus();
            }
            else MessageBox.Show("Введите коректные значения или число должно быть трехзначным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        
    }
}
