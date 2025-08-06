using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MathMage
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DisplayScrollViewer.SizeChanged += DisplayScrollViewer_SizeChanged;
            string rawString = @"
          A    __     
        _/_\_  \/     
      __|'u'|__||     
    C| * \-/ * |C      
      \ * V * /||     
      /_______\||     
""I am the Math Mage!
Welcome to my dungeon,
whelp!""";
            MathMageIntro1.Text = StringCorrector(rawString);
        }
        private void DisplayScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double scale = Math.Min(e.NewSize.Width / 800, e.NewSize.Height / 600);
            DisplayGrid.RenderTransform = new ScaleTransform
            {
                ScaleX = scale * 2.1,
                ScaleY = scale * 2.1
            };
        }
        public string StringCorrector(string asciiString)
        {
            string[] lines = asciiString.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            StringBuilder asciiStringBuilder = new StringBuilder();

            foreach (string line in lines)
            {
                string convertedLine = line.Replace(" ", "\u00A0");
                asciiStringBuilder.AppendLine(convertedLine);
            }

            return asciiStringBuilder.ToString();
        }
    }
}
