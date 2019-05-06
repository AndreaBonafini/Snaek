using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml.Schema;

namespace Snaek_2
{
    class Snake
    {
        private Point _head;
        Canvas canvas;
        //StackPanel GetStackPanel stk;
        Rectangle _headRectangle;
        Direction direction;
        List<Point> _body;
        List<Rectangle> _bodyRectangle;
        public Snake(Canvas c, Window w)
        {
            Random pointx1 = new Random();
            Random pointy1 = new Random();
            //pointx1.Next(3,49);
            //pointy1.Next(3, 49);
            canvas = c;
            _head = new Point(pointx1.Next(3, 49), pointy1.Next(3, 49));
            _headRectangle = new Rectangle();
            _headRectangle.Fill = Brushes.Red;
            _headRectangle.Width = 10;
            _headRectangle.Height = 10;
            canvas.Children.Add(_headRectangle);
            Canvas.SetLeft(_headRectangle, _head.X * 10);
            Canvas.SetTop(_headRectangle, _head.Y * 10);
            direction = Direction.Right;
            _body = new List<Point>();
            _bodyRectangle = new List<Rectangle>();
        }
        public void update()
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                direction = Direction.Up;
            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                direction = Direction.Left;
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                direction = Direction.Down;
            }
            else if (Keyboard.IsKeyDown(Key.D))
            {
                direction = Direction.Right;
            }
            else if (Keyboard.IsKeyDown(Key.Space))
            {
                if (_body.Count == 0)
                {
                    _body.Add(_head);
                }
                else
                {
                    _body.Add(_body[_body.Count - 1]);
                }
                _bodyRectangle.Add(new Rectangle());
                _bodyRectangle[_bodyRectangle.Count - 1].Fill = Brushes.Blue;
                _bodyRectangle[_bodyRectangle.Count - 1].Width = 10;
                _bodyRectangle[_bodyRectangle.Count - 1].Height = 10;
                canvas.Children.Add(_bodyRectangle[_bodyRectangle.Count - 1]);
                Canvas.SetTop(_bodyRectangle[_bodyRectangle.Count - 1], _body[_body.Count - 1].X * 10);
                Canvas.SetLeft(_bodyRectangle[_bodyRectangle.Count - 1], _body[_body.Count - 1].Y * 10);
            }
            else if (Keyboard.IsKeyDown(Key.Escape))
            {
            }
            switch (direction)
            {
                case Direction.Right:
                    _head = new Point(_head.X + 1, _head.Y);
                    break;
                case Direction.Down:
                    _head = new Point(_head.X, _head.Y + 1);
                    break;
                case Direction.Left:
                    _head = new Point(_head.X - 1, _head.Y);
                    break;
                case Direction.Up:
                    _head = new Point(_head.X, _head.Y - 1);
                    break;
                case Direction.None:
                    Random pointx1 = new Random();
                    Random pointy1 = new Random();
                    _head = new Point(25, 25);
                    break;
            }
            Canvas.SetLeft(_headRectangle, _head.X * 10);
            Canvas.SetTop(_headRectangle, _head.Y * 10);
            for (int i = 0; i < _bodyRectangle.Count; i++)
            {
                Canvas.SetLeft(_bodyRectangle[i], _body[i].X * 10);
                Canvas.SetTop(_bodyRectangle[i], _body[i].Y * 10);
                if (_body[i].X * 10 == _head.X * 10 && _body[i].Y * 10 == _head.Y * 10)
                {
                    var result1 = MessageBox.Show("Do you want to play again?", "You Lost", MessageBoxButton.YesNo);
                    if (result1 == MessageBoxResult.Yes)
                    {
                        direction = Direction.None;
                        for (int j = _bodyRectangle.Count - 1; j > 0; j--)
                        {
                            _bodyRectangle[_bodyRectangle.Count - j].Fill = Brushes.Black;
                        }
                        _bodyRectangle.Clear();
                    }
                    else
                    {
                        System.Windows.Application.Current.Shutdown();
                    }
                }
            }
            for (int i = _bodyRectangle.Count - 1; i > 0; i--)
            {
                _body[i] = _body[i - 1];
            }
            if (_body.Count > 0)
            {
                _body[0] = _head;
            }
            if (_head.X * 10 > 500 || _head.X * 10 < 20)
            {
                //MessageBox.Show("U lose");
                //canvas.Visibility = Visibility.Collapsed;
                var result = MessageBox.Show("Do you want to play again?", "You Lost", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    for (int i = _bodyRectangle.Count - 1; i > 0; i--)
                    {
                        _bodyRectangle[_bodyRectangle.Count - i].Fill = Brushes.Black;
                    }
                    _bodyRectangle.Clear();
                    direction = Direction.None;
                }
                else
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
            if (_head.Y * 10 > 500 || _head.Y * 10 < 20)
            {
                for (int i = _bodyRectangle.Count - 1; i > 0; i--)
                {
                    _bodyRectangle[_bodyRectangle.Count - i].Fill = Brushes.Black;
                }
                _bodyRectangle.Clear();
                direction = Direction.None;
            }
        }

        public void Food()
        {
            Random rdmFood = new Random();
            Rectangle food = new Rectangle();
            int foodX = rdmFood.Next(7, 42);
            int foodY = rdmFood.Next(7, 42);
            food.Width = 10;
            food.Height = 10;
            food.Fill = Brushes.Gold;
            canvas.Children.Add(food);
            Canvas.SetLeft(food, foodX * 10);
            Canvas.SetTop(food, foodY * 10);
        }
        public void Satellites()
        {
            Random rdmSatellite = new Random();
            Random rdmSatellite2 = new Random();
            Rectangle satellite = new Rectangle();
            int satelliteX = rdmSatellite.Next(3, 49) * 10;
            int satelliteY = rdmSatellite2.Next(3, 49) * 10;
            satellite.Width = 40;
            satellite.Height = 20;
            satellite.Fill = Brushes.White;
            canvas.Children.Add(satellite);
            Canvas.SetLeft(satellite, satelliteX);
            Canvas.SetTop(satellite, satelliteY);

            Random rdmSatellite3 = new Random();
            Random rdmSatellite4 = new Random();
            Rectangle satellite1 = new Rectangle();
            int satellite1X = rdmSatellite3.Next(3, 49) * 10;
            int satellite1Y = rdmSatellite4.Next(3, 49) * 10;
            satellite1.Width = 20;
            satellite1.Height = 60;
            satellite1.Fill = Brushes.White;
            canvas.Children.Add(satellite1);
            Canvas.SetLeft(satellite1, satellite1X);
            Canvas.SetTop(satellite1, satellite1Y - 20);
        }

    }
}