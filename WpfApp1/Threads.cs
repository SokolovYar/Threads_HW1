using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private void GenerateSimple(int start, int end)
        {
            //проверка на адекватность ввода выполняется в обработчике textBox_PreviewTextInput
            SimpleNumber simple = new SimpleNumber(start, end);
            while (simple.Next())
            {
                // s_tBox.Text = simple.Number.ToString();  - ТАК ВЫДАЁТ ОШИБКУ, ЧТО s_tBox - является частью потока UI  и не может быть вызван из другого потока
                Dispatcher.Invoke(() => s_tBox.Text = simple.Number.ToString());
                Thread.Sleep(250);
            }
        }

        private void GenerateFibo(int start, int end)
        {
            Fibo fibo = new Fibo(start, end);
            while (fibo.Next() != -1)
            {
                Dispatcher.Invoke(() => f_tBox.Text = fibo.Number.ToString());
                Thread.Sleep(250);
            }
        }
    }

}
