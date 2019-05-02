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

namespace Snaek_2
{
    //enum Direction { up, right, down, left }

    class Snake
    {
        //Variables
        Direction direction;
      //int speed;
        List<Rectangle> body;
        Canvas canvas;
        Window window;

        //Constructor
        public Snake(Canvas c, Window w)
        {
            Random rdm = new Random((int)DateTime.Now.Ticks);
            Random mdr = new Random((int)DateTime.Now.Ticks);
            double k = rdm.Next(20, 500);
            double l = mdr.Next(20, 500);
            canvas = c;
            window = w;
            body = new List<Rectangle>();
            Rectangle temp = new Rectangle();
            temp.Fill = Brushes.Red;
            temp.Width = 10;
            temp.Height = 10;
            body.Add(temp);
            if (k > 500)
            {
                body.Clear();
                temp.Fill = Brushes.Transparent;
            }
            if (k < 20)
            {
                body.Clear();
                temp.Fill = Brushes.Transparent;
            }
            if (l > 500)
            {
                body.Clear();
                temp.Fill = Brushes.Transparent;
            }
            if (l < 20)
            {
                body.Clear();
                temp.Fill = Brushes.Transparent;
            }

            for (int i = 0; i < body.Count; i++)
            {
                canvas.Children.Add(body[i]);
                Canvas.SetTop(body[i], l);
                Canvas.SetLeft(body[i], k);
            }

            if(Keyboard.IsKeyDown(Key.W ))
            {
                direction = Direction.Up;
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                direction = Direction.Left;
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                direction = Direction.Down;
            }

            if (Keyboard.IsKeyDown(Key.D))
            {
                direction = Direction.Right;
            }
        }

        public void update()
        {
            if (direction == Direction.Right)
            {
                Rectangle temp = new Rectangle();
                temp.Fill = Brushes.Red;
                temp.Width = 10;
                temp.Height = 10;
                body.Add(temp);
                canvas.Children.Add(body[body.Count - 1]);
                double x = Canvas.GetLeft(body[body.Count - 2]);
                Canvas.SetTop(body[body.Count - 1], Canvas.GetTop(body[body.Count - 2]));
                Canvas.SetLeft(body[body.Count - 1], Canvas.GetLeft(body[body.Count - 2]) + 10);
                foreach (Rectangle r in canvas.Children)
                {
                    //Console.WriteLine(Canvas.get)
                }
                Console.WriteLine(canvas.Children.Count);
                canvas.Children.Remove(body[0]);
                body.RemoveAt(0);
            }
            if (direction == Direction.Down)
            {
                Rectangle temp = new Rectangle();
                temp.Fill = Brushes.Red;
                temp.Width = 10;
                temp.Height = 10;
                body.Add(temp);
                canvas.Children.Add(body[body.Count - 1]);
                double x = Canvas.GetLeft(body[body.Count - 2]);
                Canvas.SetTop(body[body.Count - 1], Canvas.GetTop(body[body.Count - 2]));
                Canvas.SetLeft(body[body.Count - 1], Canvas.GetLeft(body[body.Count - 2]));
                foreach (Rectangle r in canvas.Children)
                {
                    //Console.WriteLine(Canvas.get)
                }
                Console.WriteLine(canvas.Children.Count);
                canvas.Children.Remove(body[0]);
                body.RemoveAt(0);
            }
            if (direction == Direction.Left)
            {
                Settings.Speed = 30;
                Rectangle temp = new Rectangle();
                temp.Fill = Brushes.Red;
                temp.Width = 10;
                temp.Height = 10;
                body.Add(temp);
                canvas.Children.Add(body[body.Count - 1]);
                double x = Canvas.GetLeft(body[body.Count - 2]);
                Canvas.SetTop(body[body.Count - 1], Canvas.GetTop(body[body.Count - 2]));
                Canvas.SetLeft(body[body.Count - 1], Canvas.GetLeft(body[body.Count - 2]) + 10);
                foreach (Rectangle r in canvas.Children)
                {
                    //Console.WriteLine(Canvas.get)
                }
                Console.WriteLine(canvas.Children.Count);
                canvas.Children.Remove(body[0]);
                body.RemoveAt(0);
            }
            if (direction == Direction.Up)
            {
                Settings.Speed = 30;
                Rectangle temp = new Rectangle();
                temp.Fill = Brushes.Red;
                temp.Width = 10;
                temp.Height = 10;
                body.Add(temp);
                canvas.Children.Add(body[body.Count - 1]);
                double x = Canvas.GetLeft(body[body.Count - 2]);
                Canvas.SetTop(body[body.Count - 1], Canvas.GetTop(body[body.Count - 2]));
                Canvas.SetLeft(body[body.Count - 1], Canvas.GetLeft(body[body.Count - 2]) + 10);
                foreach (Rectangle r in canvas.Children)
                {
                    //Console.WriteLine(Canvas.get)
                }
                Console.WriteLine(canvas.Children.Count);
                canvas.Children.Remove(body[0]);
                body.RemoveAt(0);
            }
        }

        internal void grow()
        {
            if (direction == Direction.Right)
            {
                Rectangle temp = new Rectangle();
                temp.Fill = Brushes.Red;
                temp.Width = 10;
                temp.Height = 10;
                body.Add(temp);
                canvas.Children.Add(body[body.Count - 1]);
                Canvas.SetTop(body[body.Count - 1], Canvas.GetTop(body[body.Count - 2]));
                Canvas.SetLeft(body[body.Count - 1], Canvas.GetLeft(body[body.Count - 2]) + 10);
            }
        }
    }
}