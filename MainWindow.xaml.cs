﻿using System;
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

        public MainWindow()
        {
            InitializeComponent();
            snake = new Snake(canvas, this);
            //start Timer
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);//fps
            gameTimer.Start();
            // gameTimer.Stop();      
            snake.Collision();      
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            snake.update();
            /*counter++;
            if (counter % 10 == 0)
            {
                
                counter = 0;
            }
            else
            {
                snake.update();
            }*/
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnResume_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
