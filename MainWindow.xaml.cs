using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snaek_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        Snake snake;
        Settings settings;
        StackPanel stackPanel;
        Direction direction;
        public MainWindow()
        {
            InitializeComponent();
            snake = new Snake(canvas, this);
            //start Timer
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);//fps
            gameTimer.Start();
            // gameTimer.Stop();      
            snake.Food();
            snake.Satellites();            
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Escape))
            {
                btnExit.Visibility = Visibility.Visible;
                btnRestart.Visibility = Visibility.Visible;
                btnResume.Visibility = Visibility.Visible;
                btnSettings.Visibility = Visibility.Visible;
                gameTimer.Stop();
            }
            else
            {
                snake.update();
            }
        }
        private void Collision()
        {
            snake.Satellites();
            snake.update();
        }
        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            direction = Direction.None;
            btnExit.Visibility = Visibility.Hidden;
            btnRestart.Visibility = Visibility.Hidden;
            btnResume.Visibility = Visibility.Hidden;
            btnSettings.Visibility = Visibility.Hidden;
        }
        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            btnRestart.Visibility = Visibility.Hidden;
            btnResume.Visibility = Visibility.Hidden;
            btnExit.Visibility = Visibility.Hidden;
            btnSettings.Visibility = Visibility.Hidden;
        }
        private void BtnResume_Click(object sender, RoutedEventArgs e)
        {
            gameTimer.Start();
            btnRestart.Visibility = Visibility.Hidden;
            btnResume.Visibility = Visibility.Hidden;
            btnSettings.Visibility = Visibility.Hidden;
            btnExit.Visibility = Visibility.Hidden;
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
