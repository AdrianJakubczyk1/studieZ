using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
/// <summary>
/// Static class,with purpose to help manage Bees
/// </summary>
namespace _Animacje.View
{
   static class Helper
    {
        //creating Bees
        public static AnimatedImage BeeFactory(double width, double height, TimeSpan flapInterval)
        {
            List<string> imageNames = new List<string>()
            {
                "Bee animation 1.png",
                "Bee animation 2.png",
                "Bee animation 3.png",
                "Bee animation 4.png",
            };
            AnimatedImage bee = new AnimatedImage(imageNames, flapInterval);
            bee.Width = width;
            bee.Height = height;
            return bee;
        }

        public static void SetCanvasLocation(UIElement control, double x, double y)
        {
            Canvas.SetLeft(control, x); //setting X pos of control
            Canvas.SetTop(control, y); //setting Y pos of control
        }

        public static void MoveElementOnCanvas(UIElement uiElement, double toX, double toY)
        {
            double fromX = Canvas.GetLeft(uiElement); //getting X of control
            double fromY = Canvas.GetTop(uiElement); //getting Y of control

            Storyboard storyboard = new Storyboard();
            DoubleAnimation animationX = CreateDoubleAnimation(uiElement, fromX, toX, "(Canvas.Left)"); //moving control <- ->
            DoubleAnimation animationY = CreateDoubleAnimation(uiElement, fromY, toY, "(Canvas.Top)"); //moving control up, down

            storyboard.Children.Add(animationX);
            storyboard.Children.Add(animationY);
            storyboard.Begin();//startting animation
        }

       //creating animation
        private static DoubleAnimation CreateDoubleAnimation(UIElement uiElement, double from, double to, string ToAnimate)
        {
            DoubleAnimation animation = new DoubleAnimation();
            Storyboard.SetTarget(animation, uiElement);
            Storyboard.SetTargetProperty(animation, ToAnimate);
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(3); //animation will last 3 seconds
            return animation;
        }
        //setting order of star control on panel
        public static void SendToBack(StarControl newStar)
        {
            Canvas.SetZIndex(newStar, -1000);
        }
    }
}
