using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace MathMage
{
    public partial class MainPage : Page
    {
        public string mageIntro1, mageIntro2, spiderSpeech1, spiderSpeech2, snakeSpeech1, snakeSpeech2, batSpeech1, batSpeech2, blobSpeech1, blobSpeech2, goblinSpeech1, goblinSpeech2, ghostSpeech1, ghostSpeech2, skeletonSpeech1, skeletonSpeech2, mawSpeech1, mawSpeech2, knightSpeech1, knightSpeech2, trollSpeech1, trollSpeech2, golemSpeech1, golemSpeech2, mageSpeech1, mageSpeech2, room;
        public double gameLevel;
        public int asdLevel, mathResult;
        public MainPage()
        {
            InitializeComponent();
            DisplayScrollViewer.SizeChanged += DisplayScrollViewer_SizeChanged;
            mageIntro1 = @"
          A    __     
        _/_\_  \/     
      __|'u'|__||     
    C| * \-/ * |C     
      \ * V * /||     
      /_______\||     
""I am the Math Mage!
Welcome to my dungeon,
whelp!""";
            mageIntro2 = @"
          A    __     
        _/_\_  \/     
      __|'u'|__||     
    C| * \-/ * |C      
      \ * V * /||     
      /_______\||     
""Can you defeat all of
my minions? I think 
not! Come and try!""";
            spiderSpeech1 = @"
          |            
          |           
         / \          
     \_\(___)/_/       
      __(:_:)__       
     / / ( ) \ \      
Level 1: Spider       
""Come here and play!""";
            spiderSpeech2 = @"
          |           
          |           
         / \          
     \_\(___)/_/      
      __(;_;)__       
     / / ( ) \ \            
""Hey! No fair!""";
            snakeSpeech1 = @"
                     
     ____           
    ( '' )          
     \VV/       A    
      \_\_______|| 
       \_)_)_)_)_/  
Level 2: Snake        
""Let's see you slither
away from this!""";
            snakeSpeech2 = @"
                     
     ____           
    ( -- )          
     \VV/       A    
      \_\_______|| 
       \_)_)_)_)_/       
""You got lucky, that's
all!""";
            batSpeech1 = @"
                      
    ___  A_A  ___     
   //|\\('w')//|\\    
   \/\/\( _ )/\/\/    
         | |          
         "" ""        
Level 3: Bat
""Your feeble skills
won't fly here!""";
            batSpeech2 = @"
                      
    ___  A_A  ___     
   //|\\(*w*)//|\\    
   \/\/\( _ )/\/\/    
         | |          
         "" ""        
""I can't believe you
beat me!""";
            blobSpeech1 = @"
                      
         ___          
        /   \         
      _( '_' )_       
     /         \      
    (___________)     
Level 4: Blob         
""I may be slimy, but
you stink!""";
            blobSpeech2 = @"
                     
         ___         
        /   \        
      _( -_- )_      
     /         \     
    (___________)         
""Aww, I'll get you
next time!""";
            goblinSpeech1 = @"
                      
        |\_/| /\      
        ('U') ||      
     ()=( _ )=()      
       _|| ||_||      
      {__/ \__}       
Level 5: Goblin    
""Welcome to your
doom!""";
            goblinSpeech2 = @"
                      
        |\_/| /\      
        (;U;) ||      
     ()=( _ )=()      
       _|| ||_||      
      {__/ \__}         
""No way! I can't
believe this!""";
            ghostSpeech1 = @"
          ___         
         /  _)        
       _('_')_        
      (__   __)       
        /   \         
       /_____\        
Level 6: Ghost     
""You don't have a
ghost of a chance!""";
            ghostSpeech2 = @"
          ___         
         /  _)        
       _(*o*)_        
      (__   __)       
        /   \         
       /_____\        
""What? How? That's
impossible!""";
            skeletonSpeech1 = @"
         ___          
        (' ')         
       __[#]__        
      / {=|=} \       
     M'  <|>  'M      
       _/   \_        
Level 7: Skeleton
""I've got a bone to
pick with you!""";
            skeletonSpeech2 = @"
         ___          
        (O O)         
       __[#]__        
      / {=|=} \       
     M'  <|>  'M      
       _/   \_        
""There's no way! You
cheated!""";
            mawSpeech1 = @"
                      
       _______        
      ( '   ' )       
      (|WWWWW|)       
      (|MMMMM|)       
      (_______)       
Level 8: Maw          
""You're gonna taste
defeat!""";
            mawSpeech2 = @"
                      
       _______        
      ( ;   ; )       
      (|WWWWW|)       
      (|MMMMM|)       
      (_______)       
""Okay, okay! Stop! I
give up!""";
            knightSpeech1 = @"
         _~_   |      
    __  /'|'\  |      
   /  \_|\-/|_===     
   |  |_\   /__E      
    \/  //-\\         
      _/_| |_\_       
Level 9: Knight
""You can't beat me! I
have nerves of steel!""";
            knightSpeech2 = @"
         _~_   |      
    __  /-|-\  |      
   /  \_|\n/|_===     
   |  |_\   /__E      
    \/  //-\\         
      _/_| |_\_       
""You've defeated me! I
concede!""";
            trollSpeech1 = @"
         ___         
      |\/'U'\/|      
     _(_ A_A _)_     
    / __. | .__ \    
  _/ | (  .  ) | \_  
 (__)U_/_| |_\_U(__) 
Level 10: Troll
""You're in big, big
trouble!""";
            trollSpeech2 = @"
         ___         
      |\/*U*\/|      
     _(_ A,A _)_     
    / __. | .__ \    
  _/ | (  .  ) | \_  
 (__)U_/_| |_\_U(__) 
""Whoa! You're good!""";
            golemSpeech1 = @"
        _____        
    ___['   ']___    
   [    [ _ ]    ]   
  /  ][__ | __][  \  
 [,,]' \  _  / '[,,] 
       /_| |_\       
Level 11: Golem
""Nobody's stronger
than me!""";
            golemSpeech2 = @"
        _____        
    ___[;   ;]___    
   [    [ ^ ]    ]   
  /  ][__ | __][  \  
 [,,]' \  _  / '[,,] 
       /_| |_\       
""This can't be
happening!""";
            mageSpeech1 = @"
          A    __     
        _/_\_  \/     
      __|'u'|__||     
    C| * \-/ * |C     
      \ * V * /||     
      /_______\||     
Level 12: Mage
""So, you've beaten my
minions! Come at me!""";
            mageSpeech2 = @"
          A    __     
        _/_\_  \/     
      __|OuO|__||     
    C| * \O/ * |C     
      \ * V * /||     
      /_______\||     
""I can't lose! I am
the mighty Math Mage!
Noooooooooooooooooo!""";
            room = @"
 ____________________  
|\                  /| 
| \ ______________ / | 
|  |              |  | 
|  | __   __   __ |  | 
|  ||. | |. | |. ||  | 
|  ||__|_|__|_|__||  | 
| /         =      \ | 
|/__________________\|";
            asdLevel = 111;
            mathResult = 0;
            gameLevel = 0;
            Page_Loaded(null, null);
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
        public StringBuilder Randomizer(StringBuilder stringBuild)
        {
            Random randNum = new Random();
            string[] allSigns = { "+", "-", "×", "÷" };
            string[] allNumbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var selectedSigns = allSigns.OrderBy(x => randNum.Next()).Take(3).ToList();
            var selectedNumbers = allNumbers.OrderBy(x => randNum.Next()).Take(3).ToList();

            if (stringBuild.Length > 93)
            {
                stringBuild.Remove(82, 1).Insert(82, selectedSigns[0]);
                stringBuild.Remove(87, 1).Insert(87, selectedSigns[1]);
                stringBuild.Remove(92, 1).Insert(92, selectedSigns[2]);
                stringBuild.Remove(83, 1).Insert(83, selectedNumbers[0]);
                stringBuild.Remove(88, 1).Insert(88, selectedNumbers[1]);
                stringBuild.Remove(93, 1).Insert(93, selectedNumbers[2]);
            }

            int levelInt = ((int)Math.Abs(gameLevel) - 1) * 6 + 12;

            if (levelInt.ToString().Length == 2)
                stringBuild.Remove(37, 2).Insert(37, levelInt.ToString());
            else if (levelInt.ToString().Length == 3)
                stringBuild.Remove(36, 3).Insert(36, levelInt.ToString());

            return stringBuild;
        }
        public StringBuilder LevelMath(StringBuilder stringBuild, object sender = null)
        {
            //string mathSign = stringBuild.ToString().Substring(82, 1);
            //int firstNumber = Convert.ToInt32(stringBuild.ToString().Substring(181, 3).Trim());
            //int secondNumber = Convert.ToInt32(stringBuild.ToString().Substring(83, 1));
            //int result;

            string mathSign = "";
            int firstNumber = mathResult;
            int secondNumber = 0;

            stringBuild.Remove(181, 3).Insert(181, "   ");
            stringBuild.Remove(184 - mathResult.ToString().Length, mathResult.ToString().Length).Insert(184 - mathResult.ToString().Length, mathResult);
            stringBuild.Remove(185, 1).Insert(185, "?");
            stringBuild.Remove(187, 1).Insert(187, "_");
            stringBuild.Remove(191, 3).Insert(191, "___");

            if (sender == AButton)
            {
                mathSign = stringBuild.ToString().Substring(82, 1);
                secondNumber = Convert.ToInt32(stringBuild.ToString().Substring(83, 1));
            }
            else if (sender == SButton)
            {
                mathSign = stringBuild.ToString().Substring(87, 1);
                secondNumber = Convert.ToInt32(stringBuild.ToString().Substring(88, 1));
            }
            else if (sender == DButton)
            {
                mathSign = stringBuild.ToString().Substring(92, 1);
                secondNumber = Convert.ToInt32(stringBuild.ToString().Substring(93, 1));
            }

            switch (mathSign)
            {
                case "+":
                    mathResult = firstNumber + secondNumber;
                    break;
                case "-":
                    mathResult = firstNumber - secondNumber;
                    break;
                case "×":
                    mathResult = firstNumber * secondNumber;
                    break;
                case "÷":
                    mathResult = firstNumber / secondNumber;
                    break;
            }

            if (sender != null)
            {
                stringBuild.Remove(185, 1).Insert(185, mathSign);
                stringBuild.Remove(188 - secondNumber.ToString().Length, secondNumber.ToString().Length).Insert(188 - secondNumber.ToString().Length, secondNumber);
                stringBuild.Remove(191, 3).Insert(191, "   ");
                stringBuild.Remove(191, mathResult.ToString().Length).Insert(191, mathResult);
            }

            return stringBuild;
        }

        public void DisplayLevel(double level, object sender = null, bool skipRandomizer = false)
        {
            StringBuilder roomStringBuilder = new StringBuilder();

            switch (level)
            {
                case 0.1:
                    roomStringBuilder.Append(mageIntro1);
                    break;
                case 0.2:
                    roomStringBuilder.Append(mageIntro2);
                    break;
                case 1.0:
                    roomStringBuilder.Append(spiderSpeech1);
                    break;
                case 1.2:
                    roomStringBuilder.Append(spiderSpeech2);
                    break;
                case 2.0:
                    roomStringBuilder.Append(snakeSpeech1);
                    break;
                case 2.2:
                    roomStringBuilder.Append(snakeSpeech2);
                    break;
                case 3.0:
                    roomStringBuilder.Append(batSpeech1);
                    break;
                case 3.2:
                    roomStringBuilder.Append(batSpeech2);
                    break;
                case 4.0:
                    roomStringBuilder.Append(blobSpeech1);
                    break;
                case 4.2:
                    roomStringBuilder.Append(blobSpeech2);
                    break;
                case 5.0:
                    roomStringBuilder.Append(goblinSpeech1);
                    break;
                case 5.2:
                    roomStringBuilder.Append(goblinSpeech2);
                    break;
                case 6.0:
                    roomStringBuilder.Append(ghostSpeech1);
                    break;
                case 6.2:
                    roomStringBuilder.Append(ghostSpeech2);
                    break;
                case 7.0:
                    roomStringBuilder.Append(skeletonSpeech1);
                    break;
                case 7.2:
                    roomStringBuilder.Append(skeletonSpeech2);
                    break;
                case 8.0:
                    roomStringBuilder.Append(mawSpeech1);
                    break;
                case 8.2:
                    roomStringBuilder.Append(mawSpeech2);
                    break;
                case 9.0:
                    roomStringBuilder.Append(knightSpeech1);
                    break;
                case 9.2:
                    roomStringBuilder.Append(knightSpeech2);
                    break;
                case 10.0:
                    roomStringBuilder.Append(trollSpeech1);
                    break;
                case 10.2:
                    roomStringBuilder.Append(trollSpeech2);
                    break;
                case 11.0:
                    roomStringBuilder.Append(golemSpeech1);
                    break;
                case 11.2:
                    roomStringBuilder.Append(golemSpeech1);
                    break;
                case 12.0:
                    roomStringBuilder.Append(mageSpeech1);
                    break;
                case 12.2:
                    roomStringBuilder.Append(mageSpeech2);
                    break;
                case 1.1:
                case 2.1:
                case 3.1:
                case 4.1:
                case 5.1:
                case 6.1:
                case 7.1:
                case 8.1:
                case 9.1:
                case 10.1:
                case 11.1:
                case 12.1:
                    roomStringBuilder.Append(room);
                    if (!skipRandomizer)
                        LevelMath(Randomizer(roomStringBuilder), sender);
                    else
                        LevelMath(roomStringBuilder, sender);
                    room = roomStringBuilder.ToString();
                    break;
            }

            GraphicsTextBlock.Text = StringCorrector(roomStringBuilder.ToString());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.KeyDown += Current_KeyDown;
            DisplayLevel(gameLevel, null);
        }

        private void Current_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            e.Handled = true;

            switch (e.Key)
            {
                case VirtualKey.A:
                    Dispatcher.BeginInvoke(() => AButton_Click(AButton, new RoutedEventArgs()));
                    break;
                case VirtualKey.S:
                    Dispatcher.BeginInvoke(() => SButton_Click(SButton, new RoutedEventArgs()));
                    break;
                case VirtualKey.D:
                    Dispatcher.BeginInvoke(() => DButton_Click(DButton, new RoutedEventArgs()));
                    break;
            }
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            switch (asdLevel)
            {
                case 111:
                    if (gameLevel == 0)
                    {
                        DisplayLevel(gameLevel = 0.1);
                        AButtonText.Text = "Continue";
                        SButton.Visibility = Visibility.Collapsed;
                        DButton.Visibility = Visibility.Collapsed;
                        asdLevel += 100;
                    }
                    else
                    {
                        DisplayLevel(gameLevel);
                        AButtonText.Text = "Left";
                        AButtonSymbol.Text = "3";
                        SButton.Visibility = Visibility.Visible;
                        SButtonText.Text = "Middle";
                        SButtonSymbol.Text = "5";
                        DButton.Visibility = Visibility.Visible;
                        DButtonText.Text = "Right";
                        DButtonSymbol.Text = "4";
                        asdLevel += 200;
                    }
                    break;
                case 112:

                    break;
                case 113:

                    break;
                case 121:

                    break;
                case 122:

                    break;
                case 123:

                    break;
                case 131:

                    break;
                case 132:

                    break;
                case 133:

                    break;
                case 211:
                    if (gameLevel == 0.1)
                    {
                        DisplayLevel(gameLevel = 0.2);
                    }
                    else if (gameLevel == 0.2)
                    {
                        DisplayLevel(gameLevel = 1.0);
                    }
                    else if (gameLevel % 1.0 == 0)
                    {
                        switch (gameLevel)
                        {
                            case 1.0:
                                DisplayLevel(gameLevel = 1.1);
                                break;
                            case 2.0:
                                DisplayLevel(gameLevel = 2.1);
                                break;
                            case 3.0:
                                DisplayLevel(gameLevel = 3.1);
                                break;
                            case 4.0:
                                DisplayLevel(gameLevel = 4.1);
                                break;
                            case 5.0:
                                DisplayLevel(gameLevel = 5.1);
                                break;
                            case 6.0:
                                DisplayLevel(gameLevel = 6.1);
                                break;
                            case 7.0:
                                DisplayLevel(gameLevel = 7.1);
                                break;
                            case 8.0:
                                DisplayLevel(gameLevel = 8.1);
                                break;
                            case 9.0:
                                DisplayLevel(gameLevel = 9.1);
                                break;
                            case 10.0:
                                DisplayLevel(gameLevel = 10.1);
                                break;
                            case 11.0:
                                DisplayLevel(gameLevel = 11.1);
                                break;
                            case 12.0:
                                DisplayLevel(gameLevel = 12.1);
                                break;
                        }
                        AButtonText.Text = "Left";
                        AButtonSymbol.Text = "3";
                        SButton.Visibility = Visibility.Visible;
                        SButtonText.Text = "Middle";
                        SButtonSymbol.Text = "5";
                        DButton.Visibility = Visibility.Visible;
                        DButtonText.Text = "Right";
                        DButtonSymbol.Text = "4";
                        asdLevel += 100;
                    }
                    break;
                case 212:

                    break;
                case 213:

                    break;
                case 221:

                    break;
                case 222:

                    break;
                case 223:

                    break;
                case 232:

                    break;
                case 233:

                    break;
                case 311:
                    DisplayLevel(gameLevel, sender, skipRandomizer: true);
                    AButtonText.Text = "Continue";
                    SButton.Visibility = Visibility.Collapsed;
                    DButton.Visibility = Visibility.Collapsed;
                    asdLevel -= 200;
                    //if (gameLevel % 1.1 == 0)
                    //{
                    //    switch (gameLevel)
                    //    {
                    //        case 1.1:
                    //            DisplayLevel(gameLevel = 1.2);
                    //            break;
                    //        case 2.1:
                    //            DisplayLevel(gameLevel = 2.2);
                    //            break;
                    //        case 3.1:
                    //            DisplayLevel(gameLevel = 3.2);
                    //            break;
                    //        case 4.1:
                    //            DisplayLevel(gameLevel = 4.2);
                    //            break;
                    //        case 5.1:
                    //            DisplayLevel(gameLevel = 5.2);
                    //            break;
                    //        case 6.1:
                    //            DisplayLevel(gameLevel = 6.2);
                    //            break;
                    //        case 7.1:
                    //            DisplayLevel(gameLevel = 7.2);
                    //            break;
                    //        case 8.1:
                    //            DisplayLevel(gameLevel = 8.2);
                    //            break;
                    //        case 9.1:
                    //            DisplayLevel(gameLevel = 9.2);
                    //            break;
                    //        case 10.1:
                    //            DisplayLevel(gameLevel = 10.2);
                    //            break;
                    //        case 11.1:
                    //            DisplayLevel(gameLevel = 11.2);
                    //            break;
                    //        case 12.1:
                    //            DisplayLevel(gameLevel = 12.2);
                    //            break;
                    //    }
                    //}
                    //AButtonText.Text = "Continue";
                    //SButton.Visibility = Visibility.Collapsed;
                    //DButton.Visibility = Visibility.Collapsed;
                    //asdLevel -= 100;
                    break;
                case 312:

                    break;
                case 313:

                    break;
                case 321:

                    break;
                case 322:

                    break;
                case 323:

                    break;
                case 331:

                    break;
                case 332:

                    break;
                case 333:

                    break;
            }
        }
        private void SButton_Click(object sender, RoutedEventArgs e)
        {
            switch (asdLevel)
            {
                case 111:

                    break;
                case 112:

                    break;
                case 113:

                    break;
                case 121:

                    break;
                case 122:

                    break;
                case 123:

                    break;
                case 131:

                    break;
                case 132:

                    break;
                case 133:

                    break;
                case 211:

                    break;
                case 212:

                    break;
                case 213:

                    break;
                case 221:

                    break;
                case 222:

                    break;
                case 223:

                    break;
                case 232:

                    break;
                case 233:

                    break;
                case 311:
                    DisplayLevel(gameLevel, sender, skipRandomizer: true);
                    AButtonText.Text = "Continue";
                    SButton.Visibility = Visibility.Collapsed;
                    DButton.Visibility = Visibility.Collapsed;
                    asdLevel -= 200;
                    break;
                case 312:

                    break;
                case 313:

                    break;
                case 321:

                    break;
                case 322:

                    break;
                case 323:

                    break;
                case 331:

                    break;
                case 332:

                    break;
                case 333:

                    break;
            }
        }
        private void DButton_Click(object sender, RoutedEventArgs e)
        {
            switch (asdLevel)
            {
                case 111:

                    break;
                case 112:

                    break;
                case 113:

                    break;
                case 121:

                    break;
                case 122:

                    break;
                case 123:

                    break;
                case 131:

                    break;
                case 132:

                    break;
                case 133:

                    break;
                case 211:

                    break;
                case 212:

                    break;
                case 213:

                    break;
                case 221:

                    break;
                case 222:

                    break;
                case 223:

                    break;
                case 232:

                    break;
                case 233:

                    break;
                case 311:
                    DisplayLevel(gameLevel, sender, skipRandomizer: true);
                    AButtonText.Text = "Continue";
                    SButton.Visibility = Visibility.Collapsed;
                    DButton.Visibility = Visibility.Collapsed;
                    asdLevel -= 200;
                    break;
                case 312:

                    break;
                case 313:

                    break;
                case 321:

                    break;
                case 322:

                    break;
                case 323:

                    break;
                case 331:

                    break;
                case 332:

                    break;
                case 333:

                    break;
            }
        }
    }
}
