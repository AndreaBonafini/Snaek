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
    //enum Direction { up, right, down, left }

    class Snake
    {
        private Point _head;
        Canvas canvas;
        StackPanel GetStackPanel stk;
        Rectangle _headRectangle;
        Direction direction;
        List<Point> _body;
        List<Rectangle> _bodyRectangle;

        public object DialogResult { get; private set; }

        public Snake(Canvas c,Window w)
        {
            Random pointx1 = new Random();
            Random pointy1 = new Random();
            //pointx1.Next(3,49);
            //pointy1.Next(3, 49);
            canvas = c;
            _head = new Point(pointx1.Next(3,49), pointy1.Next(3,49));
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
                stackpanel.Children.Add("stkPause");
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
                    _head = new Point(25,25);
                    break;
            }
            Canvas.SetLeft(_headRectangle, _head.X * 10);
            Canvas.SetTop(_headRectangle, _head.Y * 10);
            for (int i = 0; i < _bodyRectangle.Count; i++)
            {
                Canvas.SetLeft(_bodyRectangle[i], _body[i].X * 10);
                Canvas.SetTop(_bodyRectangle[i], _body[i].Y * 10);
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
                var result = MessageBox.Show("You Lost", "Do you want to play again?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                direction = Direction.None;
                }          
                else
                {
                    System.Windows.Application.Current.Shutdown();
                }
                
            }
            if (_head.Y * 10 > 500 || _head.Y * 10 < 20)
            {
                //MessageBox.Show("U lose");
                //canvas.Visibility = Visibility.Collapsed;
                direction = Direction.None;
            }
        }       

        public void Collision()
        {
            Random rdmFood = new Random();
            Rectangle food = new Rectangle();
            int foodX = rdmFood.Next(3, 49) * 10;
            int foodY = rdmFood.Next(3, 49) * 10;
            food.Width = 10;
            food.Height = 10;
            food.Fill = Brushes.Gold;
            canvas.Children.Add(food);
            Canvas.SetLeft(food,foodX);
            Canvas.SetTop(food, foodY);
            
            if (foodX == _head.X*10 )
            {
                if (foodY == _head.Y * 10)
                {
                    canvas.Children.Remove(food); 
                }
            }
        }
    }
} 