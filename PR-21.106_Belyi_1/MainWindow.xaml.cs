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

namespace PR_21._106_Belyi_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StrError(textBoxInput.Text);

                double.TryParse(textBoxInput.Text, out var namder);
                int proiz = 1;
                int sum = 0;
                for (int i = 12; i > 0; i--)
                {
                    if (i > 9)
                        proiz *= Convert.ToInt32((namder / Math.Pow(10, i - 1)) % 10);
                    else
                    {
                        sum += Convert.ToInt32((namder / Math.Pow(10, i)) % 10);
                    }
                }

                textBlockOutpun.Text = proiz == sum ? "Равны" : "Не равны";
            }
            catch (StringError ex)
            {
                textBlockOutpun.Text = ex.Message;
            }
        }

        static void StrError(string s)
        {
            if (s.Length != 12)
            {
                throw new StringError("Неправильно введены данные");
            }

            if (!double.TryParse(s, out var namder))
            {
                throw new StringError("Неправильно введены данные");
            }
        }

        class StringError : ArgumentException
        {
            public StringError(string message)
                : base(message)
            {
            }
        }

    }
}
