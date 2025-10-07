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
        public int asdLevel;
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
| / _?_?_?_?_?_=__ \ | 
|/__________________\|";
            asdLevel = 111;
            gameLevel = 1.1;
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
            List<char> randSigns = new List<char>();
            List<int> randNums = new List<int>();
            Random randNum = new Random();

            int levelInt = ((int)Math.Abs(gameLevel) - 1) * 6 + 12;

            //switch (levelInt)
            //{
            //    case 3:
            //        stringBuild.Replace("   ", "3-6", 36, 3);
            //        break;
            //    case 24:
            //        stringBuild.Replace("     ", "24-48", 36, 5);
            //        break;
            //    case 81:
            //        stringBuild.Replace("      ", "81-162", 36, 6);
            //        break;
            //    case 192:
            //        stringBuild.Replace("       ", "192-384", 36, 7);
            //        break;
            //    case 375:
            //        stringBuild.Replace("       ", "375-750", 36, 7);
            //        break;
            //    case 648:
            //        stringBuild.Replace("        ", "648-1256", 36, 8);
            //        break;
            //    case 1029:
            //        stringBuild.Replace("         ", "1029-2058", 36, 9);
            //        break;
            //    case 1536:
            //        stringBuild.Replace("         ", "1536-3042", 36, 9);
            //        break;
            //    case 2187:
            //        stringBuild.Replace("         ", "2187-4374", 36, 9);
            //        break;
            //    case 3000:
            //        stringBuild.Replace("         ", "3000-6000", 36, 9);
            //        break;
            //    case 3993:
            //        stringBuild.Replace("         ", "3993-7986", 36, 9);
            //        break;
            //    case 5184:
            //        stringBuild.Replace("          ", "5184-10368", 36, 10);
            //        break;
            //}

            //if (levelInt < 10)
            //{
            //    stringBuild.Replace("_", " ", 193, 1);
            //    stringBuild.Replace("_", levelInt.ToString(), 194, 1);
            //}
            //else
            //{
            //    stringBuild.Replace("__", levelInt.ToString(), 193, 2);
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    int newNum;

            //    if (levelInt == 3 || levelInt == 6)
            //    {
            //        switch (randNum.Next(0, 2))
            //        {
            //            case 0:
            //                randSigns.Add('+');
            //                break;
            //            case 1:
            //                randSigns.Add('-');
            //                break;
            //        }
            //        do
            //        {
            //            newNum = randNum.Next(0, 3);
            //        } while (i > 0 && newNum == randNums[i - 1]);
            //        randNums.Add(newNum);
            //    }
            //    else if (levelInt == 9 || levelInt == 12)
            //    {
            //        switch (randNum.Next(0, 2))
            //        {
            //            case 0:
            //                randSigns.Add('+');
            //                break;
            //            case 1:
            //                randSigns.Add('-');
            //                break;
            //        }
            //        randNums.Add(randNum.Next(0, 5));
            //    }
            //    else if (levelInt == 15 || levelInt == 18)
            //    {
            //        switch (randNum.Next(0, 3))
            //        {
            //            case 0:
            //                randSigns.Add('+');
            //                break;
            //            case 1:
            //                randSigns.Add('-');
            //                break;
            //            case 2:
            //                randSigns.Add('×');
            //                break;
            //        }
            //        randNums.Add(randNum.Next(0, 7));
            //    }
            //    else if (levelInt == 21 || levelInt == 24)
            //    {
            //        switch (randNum.Next(0, 3))
            //        {
            //            case 0:
            //                randSigns.Add('+');
            //                break;
            //            case 1:
            //                randSigns.Add('-');
            //                break;
            //            case 2:
            //                randSigns.Add('×');
            //                break;
            //        }
            //        randNums.Add(randNum.Next(0, 9));
            //    }
            //    else if (levelInt == 27 || levelInt == 30)
            //    {
            //        switch (randNum.Next(0, 4))
            //        {
            //            case 0:
            //                randSigns.Add('+');
            //                break;
            //            case 1:
            //                randSigns.Add('-');
            //                break;
            //            case 2:
            //                randSigns.Add('×');
            //                break;
            //            case 3:
            //                randSigns.Add('÷');
            //                break;
            //        }
            //        randNums.Add(randNum.Next(0, 11));
            //    }
            //    else if (levelInt == 33 || levelInt == 36)
            //    {
            //        switch (randNum.Next(0, 4))
            //        {
            //            case 0:
            //                randSigns.Add('+');
            //                break;
            //            case 1:
            //                randSigns.Add('-');
            //                break;
            //            case 2:
            //                randSigns.Add('×');
            //                break;
            //            case 3:
            //                randSigns.Add('÷');
            //                break;
            //        }
            //        randNums.Add(randNum.Next(0, 13));
            //    }
            //}
            //stringBuild.Replace(" ", randSigns[0].ToString(), 82, 1);
            //stringBuild.Replace(" ", randSigns[1].ToString(), 87, 1);
            //stringBuild.Replace(" ", randSigns[2].ToString(), 92, 1);
            //stringBuild.Replace(" ", randNums[0].ToString(), 83, 1);
            //stringBuild.Replace(" ", randNums[1].ToString(), 88, 1);
            //stringBuild.Replace(" ", randNums[2].ToString(), 93, 1);

            stringBuild.Replace("__", levelInt.ToString(), 193, 2);

            for (int i = 0; i < 10; i++)
            {
                randNums.Add(randNum.Next(0, 10));
                stringBuild.Replace("_", randNums[i].ToString(), 181 + i + i, 1);
            }

            return stringBuild;
        }
        private void LevelMath(double level)
        {
            StringBuilder roomStringBuilder = new StringBuilder();
            roomStringBuilder.Append(room);

            switch (level)
            {
                case 1.1:
                case 1.2:
                case 1.3:
                case 1.4:
                case 1.5:
                case 2.1:
                case 2.2:
                case 2.3:
                case 2.4:
                case 2.5:
                case 3.1:
                case 3.2:
                case 3.3:
                case 3.4:
                case 3.5:
                case 4.1:
                case 4.2:
                case 4.3:
                case 4.4:
                case 4.5:
                case 5.1:
                case 5.2:
                case 5.3:
                case 5.4:
                case 5.5:
                case 6.1:
                case 6.2:
                case 6.3:
                case 6.4:
                case 6.5:
                case 7.1:
                case 7.2:
                case 7.3:
                case 7.4:
                case 7.5:
                case 8.1:
                case 8.2:
                case 8.3:
                case 8.4:
                case 8.5:
                case 9.1:
                case 9.2:
                case 9.3:
                case 9.4:
                case 9.5:
                case 10.1:
                case 10.2:
                case 10.3:
                case 10.4:
                case 10.5:
                case 11.1:
                case 11.2:
                case 11.3:
                case 11.4:
                case 11.5:
                case 12.1:
                case 12.2:
                case 12.3:
                case 12.4:
                case 12.5:
                    Randomizer(roomStringBuilder);
                    break;
            }

            room = roomStringBuilder.ToString();
        }
        public void DisplayLevel(double level)
        {
            string levelGraphics = "";

            switch (level)
            {
                case 0.1:
                    levelGraphics = mageIntro1;
                    break;
                case 0.2:
                    levelGraphics = mageIntro2;
                    break;
                case 1.0:
                    levelGraphics = spiderSpeech1;
                    break;
                case 1.1:
                    levelGraphics = room;
                    break;
                case 1.2:
                    levelGraphics = room;
                    break;
                case 1.3:
                    levelGraphics = room;
                    break;
                case 1.4:
                    levelGraphics = room;
                    break;
                case 1.5:
                    levelGraphics = room;
                    break;
                case 1.6:
                    levelGraphics = spiderSpeech2;
                    break;
                case 2.0:
                    levelGraphics = snakeSpeech1;
                    break;
                case 2.1:
                    levelGraphics = room;
                    break;
                case 2.2:
                    levelGraphics = room;
                    break;
                case 2.3:
                    levelGraphics = room;
                    break;
                case 2.4:
                    levelGraphics = room;
                    break;
                case 2.5:
                    levelGraphics = room;
                    break;
                case 2.6:
                    levelGraphics = snakeSpeech2;
                    break;
                case 3.0:
                    levelGraphics = batSpeech1;
                    break;
                case 3.1:
                    levelGraphics = room;
                    break;
                case 3.2:
                    levelGraphics = room;
                    break;
                case 3.3:
                    levelGraphics = room;
                    break;
                case 3.4:
                    levelGraphics = room;
                    break;
                case 3.5:
                    levelGraphics = room;
                    break;
                case 3.6:
                    levelGraphics = batSpeech2;
                    break;
                case 4.0:
                    levelGraphics = blobSpeech1;
                    break;
                case 4.1:
                    levelGraphics = room;
                    break;
                case 4.2:
                    levelGraphics = room;
                    break;
                case 4.3:
                    levelGraphics = room;
                    break;
                case 4.4:
                    levelGraphics = room;
                    break;
                case 4.5:
                    levelGraphics = room;
                    break;
                case 4.6:
                    levelGraphics = blobSpeech2;
                    break;
                case 5.0:
                    levelGraphics = goblinSpeech1;
                    break;
                case 5.1:
                    levelGraphics = room;
                    break;
                case 5.2:
                    levelGraphics = room;
                    break;
                case 5.3:
                    levelGraphics = room;
                    break;
                case 5.4:
                    levelGraphics = room;
                    break;
                case 5.5:
                    levelGraphics = room;
                    break;
                case 5.6:
                    levelGraphics = goblinSpeech2;
                    break;
                case 6.0:
                    levelGraphics = ghostSpeech1;
                    break;
                case 6.1:
                    levelGraphics = room;
                    break;
                case 6.2:
                    levelGraphics = room;
                    break;
                case 6.3:
                    levelGraphics = room;
                    break;
                case 6.4:
                    levelGraphics = room;
                    break;
                case 6.5:
                    levelGraphics = room;
                    break;
                case 6.6:
                    levelGraphics = ghostSpeech2;
                    break;
                case 7.0:
                    levelGraphics = skeletonSpeech1;
                    break;
                case 7.1:
                    levelGraphics = room;
                    break;
                case 7.2:
                    levelGraphics = room;
                    break;
                case 7.3:
                    levelGraphics = room;
                    break;
                case 7.4:
                    levelGraphics = room;
                    break;
                case 7.5:
                    levelGraphics = room;
                    break;
                case 7.6:
                    levelGraphics = skeletonSpeech2;
                    break;
                case 8.0:
                    levelGraphics = mawSpeech1;
                    break;
                case 8.1:
                    levelGraphics = room;
                    break;
                case 8.2:
                    levelGraphics = room;
                    break;
                case 8.3:
                    levelGraphics = room;
                    break;
                case 8.4:
                    levelGraphics = room;
                    break;
                case 8.5:
                    levelGraphics = room;
                    break;
                case 8.6:
                    levelGraphics = mawSpeech2;
                    break;
                case 9.0:
                    levelGraphics = knightSpeech1;
                    break;
                case 9.1:
                    levelGraphics = room;
                    break;
                case 9.2:
                    levelGraphics = room;
                    break;
                case 9.3:
                    levelGraphics = room;
                    break;
                case 9.4:
                    levelGraphics = room;
                    break;
                case 9.5:
                    levelGraphics = room;
                    break;
                case 9.6:
                    levelGraphics = knightSpeech2;
                    break;
                case 10.0:
                    levelGraphics = trollSpeech1;
                    break;
                case 10.1:
                    levelGraphics = room;
                    break;
                case 10.2:
                    levelGraphics = room;
                    break;
                case 10.3:
                    levelGraphics = room;
                    break;
                case 10.4:
                    levelGraphics = room;
                    break;
                case 10.5:
                    levelGraphics = room;
                    break;
                case 10.6:
                    levelGraphics = trollSpeech2;
                    break;
                case 11.0:
                    levelGraphics = golemSpeech1;
                    break;
                case 11.1:
                    levelGraphics = room;
                    break;
                case 11.2:
                    levelGraphics = room;
                    break;
                case 11.3:
                    levelGraphics = room;
                    break;
                case 11.4:
                    levelGraphics = room;
                    break;
                case 11.5:
                    levelGraphics = room;
                    break;
                case 11.6:
                    levelGraphics = golemSpeech2;
                    break;
                case 12.0:
                    levelGraphics = mageSpeech1;
                    break;
                case 12.1:
                    levelGraphics = room;
                    break;
                case 12.2:
                    levelGraphics = room;
                    break;
                case 12.3:
                    levelGraphics = room;
                    break;
                case 12.4:
                    levelGraphics = room;
                    break;
                case 12.5:
                    levelGraphics = room;
                    break;
                case 12.6:
                    levelGraphics = mageSpeech2;
                    break;
            }

            LevelMath(gameLevel);
            GraphicsTextBlock.Text = StringCorrector(levelGraphics);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.KeyDown += Current_KeyDown;
            DisplayLevel(gameLevel);
        }

        private void Current_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case VirtualKey.A:
                    AButton_Click(AButton, null);
                    break;
                case VirtualKey.S:
                    SButton_Click(SButton, null);
                    break;
                case VirtualKey.D:
                    DButton_Click(DButton, null);
                    break;
            }
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            switch (asdLevel)
            {
                case 111:
                    DisplayLevel(0.1);
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

            asdLevel += 100;
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

            asdLevel += 10;
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

            asdLevel += 1;
        }
    }
}
