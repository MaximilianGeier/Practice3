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
using Practice3;

namespace Paint
{
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();
        Stack History = new Stack();
        public bool Color = true;
        int StrokeThickness = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                if(Color)
                    line.Stroke = Brushes.Black;
                else
                    line.Stroke = Brushes.Red;
                line.StrokeThickness = StrokeThickness;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y - 30;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y - 30;

                currentPoint = e.GetPosition(this);
                History.Push(line);
                paintSurface.Children.Add(line);
            }
            if((e.LeftButton != MouseButtonState.Pressed) && !(History.Top() is string))
            {
                History.Push("end");
            }
        }

        private void DoCancel(object sender, RoutedEventArgs e)
        {
            if (!History.IsEmpty())
            {
                while (History.Top() is string)
                {
                    History.Pop();
                }
                while (!(History.Top() is string))
                {
                    paintSurface.Children.Remove((UIElement)History.Pop());
                }
                History.Pop();
            }
        }

        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            if (Color)
                ButtonChangeColor.Content = "Красный цвет";
            else
                ButtonChangeColor.Content = "Черный цвет";
            Color = !Color;
        }

        private void SubtractStrokeThickness(object sender, RoutedEventArgs e)
        {
            if(StrokeThickness > 1)
                StrokeThickness--;
            LabelStrokeThickness.Content = "Толщина кисти: " + StrokeThickness.ToString();
        }

        private void AddStrokeThickness(object sender, RoutedEventArgs e)
        {
            StrokeThickness++;
            LabelStrokeThickness.Content = "Толщина кисти: " + StrokeThickness.ToString();
        }
    }
}
