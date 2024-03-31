using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Thread simpleThread;
        private Thread fiboThread;

        private void SimleButton_Click(object sender, RoutedEventArgs e)
        {
            //защита от запусков сразу несколько потоков при нажатии кнопки
            if (simpleThread == null || simpleThread.ThreadState == ThreadState.Stopped)
            {
                int start = Convert.ToInt32(s_rangeD.Text);
                int end = Convert.ToInt32(s_rangeU.Text);

                simpleThread = new Thread(() => GenerateSimple(start, end));
                simpleThread.Start();
            }
        }

        private void FiboButton_Click(object sender, RoutedEventArgs e)
        {
            //защита от запусков сразу несколько потоков при нажатии кнопки
            if (fiboThread == null || fiboThread.ThreadState == ThreadState.Stopped)
            {
                int start = Convert.ToInt32(f_rangeD.Text);
                int end = Convert.ToInt32(f_rangeU.Text);

                fiboThread = new Thread(() => GenerateFibo(start, end));
                fiboThread.Start();
            }
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }
        }

        private void SimpleButton_Pause(object sender, RoutedEventArgs e)
        {
            if (simpleThread != null)
            {
                //проверка на два состояния, т.к. при Thread.Sleep выдаёт ThreadState.WaitSleepJoin
                if (simpleThread.ThreadState == ThreadState.Running || simpleThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    try
                    {
                        SimleButton_Pause.Content = "Resume";
                        simpleThread.Suspend(); //Метод не поддерживается платформой!

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

                if (simpleThread.ThreadState == ThreadState.Suspended)
                {
                    try
                    {
                        SimleButton_Pause.Content = "Pause";
                        simpleThread.Resume(); //Метод не поддерживается платформой!

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void FiboButton_Pause(object sender, RoutedEventArgs e)
        {
            if (fiboThread != null)
            {
                //проверка на два состояния, т.к. при Thread.Sleep выдаёт ThreadState.WaitSleepJoin
                if (fiboThread.ThreadState == ThreadState.Running || fiboThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    try
                    {
                        FibButton_Pause.Content = "Resume";
                        fiboThread.Suspend(); //Метод не поддерживается платформой!
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

                if (simpleThread.ThreadState == ThreadState.Suspended)
                {
                    try
                    {
                        FibButton_Pause.Content = "Pause";
                        fiboThread.Resume(); //Метод не поддерживается платформой!
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void Simple_Abort(object sender, RoutedEventArgs e)
        {
            if (simpleThread != null)
            {
                if (simpleThread.ThreadState == ThreadState.Running || simpleThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    try
                    {
                        simpleThread.Abort(); //Метод не поддерживается платформой!
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void Fib_Abort(object sender, RoutedEventArgs e)
        {
            if (fiboThread != null)
            {
                if (fiboThread.ThreadState == ThreadState.Running || fiboThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    try
                    {
                        fiboThread.Abort(); //Метод не поддерживается платформой!
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }
    }
}