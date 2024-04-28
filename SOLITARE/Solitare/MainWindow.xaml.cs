using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Diagnostics;

namespace Solitare
{
    public partial class MainWindow : Window
    {
  
        private Table table =new Table();


        public MainWindow()
        {
            InitializeComponent();
            DisplayStacks();
        }

        private void DisplayStacks()
        {
            int stacks = 10;
            //double columnWidth = TopStacksGrid.ActualWidth / (double)stacks * 0.8;
            // i hate wpf i hate wpf i hate wpf i hate wpf i hate wpf
            // this stupid TopStacksGrid is not initialized yet and has a width of 0 how stupid is that who even thought of this as a feature what

            // Display top stacks
            for (int i = 0; i < stacks; i++)
            {
                Canvas canvas = new Canvas();

                var currentStack = table.SpiderStacks[i].ToList();
                var reversed = new Stack<Card>(currentStack);
                // how???

                foreach (var card in reversed)
                {
                    Image cardImage = new Image();
                    cardImage.Source = new BitmapImage(new Uri(card.GetCardImagePath(), UriKind.Relative));
                    cardImage.Width = 100;
                    cardImage.Height = 80;
                    canvas.Children.Add(cardImage);
                    Canvas.SetTop(cardImage, 20 * canvas.Children.Count);
                }

                Grid.SetColumn(canvas, i);
                Grid.SetRow(canvas, 0);
                TopStacksGrid.Children.Add(canvas);
                

                //StackPanel stackPanel = new StackPanel();
                //stackPanel.Orientation = Orientation.Vertical;

                //foreach (var card in table.SpiderStacks[i])
                //{
                //   Image cardImage = new Image();
                //    Trace.WriteLine(card.GetCardImagePath());
                //    cardImage.Source = new BitmapImage(new Uri(card.GetCardImagePath(),UriKind.Relative));
                //    stackPanel.Children.Add(cardImage);
                //}

                //Grid.SetColumn(stackPanel, i);
                //Grid.SetRow(stackPanel, 0);
                //TopStacksGrid.Children.Add(stackPanel);
            }

            // Display bottom stack
            StackPanel bottomStackPanel = new StackPanel();
            bottomStackPanel.Orientation = Orientation.Vertical;

            foreach (var card in table.Stock)
            {
                TextBlock cardText = new TextBlock();
                cardText.Text = card.GetCardImagePath();
                bottomStackPanel.Children.Add(cardText);
            }

            Grid.SetColumn(bottomStackPanel, 0);
            Grid.SetRow(bottomStackPanel, 0);
            BottomStackGrid.Children.Add(bottomStackPanel);
        }
    }
}
