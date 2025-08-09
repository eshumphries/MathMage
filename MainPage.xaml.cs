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
            string mageIntro1 = @"
          A    __     
        _/_\_  \/     
      __|'u'|__||     
    C| * \-/ * |C      
      \ * V * /||     
      /_______\||     
""I am the Math Mage!
Welcome to my dungeon,
whelp!""";
            string mageIntro2 = @"
          A    __     
        _/_\_  \/     
      __|'u'|__||     
    C| * \-/ * |C      
      \ * V * /||     
      /_______\||     
""Can you defeat all of
my minions? I think 
not! Come and try!""";
            string spiderSpeech1 = @"
          |            
          |           
         / \          
     \_\(___)/_/       
      __(:_:)__       
     / / ( ) \ \      
Level 1: Spider       
""Come here and play!""";
            string spiderSpeech2 = @"
          |            
          |           
         / \          
     \_\(___)/_/       
      __(;_;)__       
     / / ( ) \ \      
Level 1: Spider       
""Hey! No fair!""";
            string snakeSpeech1 = @"
                       
     ____           
    ( '' )          
     \VV/       A    
      \_\_______|| 
       \_)_)_)_)_/  
Level 2: Snake        
""Let's see you slither
away from this!""";
            string snakeSpeech2 = @"
                       
     ____           
    ( -- )          
     \VV/       A    
      \_\_______|| 
       \_)_)_)_)_/  
Level 2: Snake        
""You got lucky, that's
all!""";
            string batSpeech1 = @"
                       
    ___  A_A  ___     
   //|\\('w')//|\\    
   \/\/\( _ )/\/\/     
         | |          
         "" ""          
Level 3: Bat
""Your feeble skills
won't fly here!""";
            string batSpeech2 = @"
                       
    ___  A_A  ___     
   //|\\(*w*)//|\\    
   \/\/\( _ )/\/\/     
         | |          
         "" ""          
Level 3: Bat
""I can't believe you
beat me!""";
            string blobSpeech1 = @"
                       
         ___          
        /   \         
      _( '_' )_        
     /         \      
    (___________)     
Level 4: Blob                     
""I may be slimy, but
you stink!""";
            string blobSpecch2 = @"
                       
         ___          
        /   \         
      _( -_- )_        
     /         \      
    (___________)     
Level 4: Blob                     
""Aww, I'll get you
next time!""";
            string goblinSpeech1 = @"
                       
        |\_/| /\      
        ('U') ||      
     ()=( _ )=()       
       _|| ||_||      
      {__/ \__}       
Level 5: Goblin    
""Welcome to your
doom!""";
            string goblinSpeech2 = @"
                       
        |\_/| /\      
        (;U;) ||      
     ()=( _ )=()       
       _|| ||_||      
      {__/ \__}       
Level 5: Goblin    
""No way! I can't
believe this!""";
            string ghostSpeech1 = @"
          ___          
         /  _)        
       _('_')_        
      (__   __)        
        /   \         
       /_____\        
Level 6: Ghost     
""You don't have a
ghost of a chance!""";
            string ghostSpeech2 = @"
          ___          
         /  _)        
       _(*o*)_        
      (__   __)        
        /   \         
       /_____\        
Level 6: Ghost     
""What? How? That's
impossible!""";
            string skeletonSpeech1 = @"
         ___           
        (' ')         
       __[#]__        
      / {=|=} \        
     M'  <|>  'M      
       _/   \_        
Level 7: Skeleton
""I've got a bone to
pick with you!""";
            string skeletonSpeech2 = @"
         ___           
        (O O)         
       __[#]__        
      / {=|=} \        
     M'  <|>  'M      
       _/   \_        
Level 7: Skeleton
""There's no way! You
cheated!""";
            string mawSpeech1 = @"
                       
       _______        
      ( '   ' )       
      (|WWWWW|)        
      (|MMMMM|)       
      (_______)       
Level 8: Maw                   
""You're gonna taste
defeat!""";
            string mawSpeech2 = @"
                       
       _______        
      ( ;   ; )       
      (|WWWWW|)        
      (|MMMMM|)       
      (_______)       
Level 8: Maw                   
""Okay, okay! Stop! I
give up!""";
            string knightSpeech1 = @"
         _~_   |       
    __  /'|'\  |      
   /  \_|\-/|_===     
   |  |_\   /__E       
    \/  //-\\         
      _/_| |_\_       
Level 9: Knight
""You can't beat me! I
have nerves of steel!""";
            string knightSpeech2 = @"
         _~_   |       
    __  /-|-\  |      
   /  \_|\n/|_===     
   |  |_\   /__E       
    \/  //-\\         
      _/_| |_\_       
Level 9: Knight
""You've defeated me! I
concede!""";
            string trollSpeech1 = @"
         ___           
      |\/'U'\/|       
     _(_ A_A _)_      
    / __. | .__ \     
  _/ / (  .  ) \ \_  
 (__)'_/_| |_\_'(__) 
Level 10: Troll
""You're in big, big
trouble!""";
            string trollSpeech2 = @"
         ___           
      |\/*U*\/|       
     _(_ A,A _)_      
    / __. | .__ \     
  _/ / (  .  ) \ \_  
 (__)'_/_| |_\_'(__) 
Level 10: Troll
""Whoa! You're good!""";
            string golemSpeech1 = @"
        _____          
    ___['   ']___     
   [    [ _ ]    ]    
  /  ][__ | __][  \   
 [,,]' \  _  / '[,,] 
       /_| |_\       
Level 11: Golem
""Nobody's stronger
than me!""";
            string golemSpeech2 = @"
        _____          
    ___[;   ;]___     
   [    [ ^ ]    ]    
  /  ][__ | __][  \   
 [,,]' \  _  / '[,,] 
       /_| |_\       
""This can't be
happening!""";
            string mageSpeech1 = @"
          A    __     
        _/_\_  \/     
      __|'u'|__||     
    C| * \-/ * |C      
      \ * V * /||     
      /_______\||     
Level 12: Mage
""So, you've beaten my
minions! Come at me!""";
            string mageSpeech2 = @"
          A    __     
        _/_\_  \/     
      __|OuO|__||     
    C| * \O/ * |C      
      \ * V * /||     
      /_______\||     
Level 12: Mage
""I can't lose! I am
the mighty Math Mage!
Noooooooooooooooooo!""";
            GraphicsTextBlock.Text = StringCorrector(mageIntro1);
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
