using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Shuffle
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<String> words;
        Random rand;
        public MainPage()
        {
            words = new List<String>();
            rand = new Random();
            Window.Current.CoreWindow.KeyDown += (s, e) =>
            {
                if (e.VirtualKey == VirtualKey.Enter)
                {
                    inputNewWords();
                }
            };
            this.InitializeComponent();
        }
        void inputNewWords()
        {
            if (!String.IsNullOrEmpty(input.Text))
            {
                words.Add(input.Text.ToString());
                input.Text = "";
            }
        }
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNewWords();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            words.Clear();
        }

        private void shuffleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (words.Count<3)
            {
                resultTxt.Text = "Not enough words";
            } else
            {
                StringBuilder build = new StringBuilder();
                var holder = new List<String>(words);
                for (int i=0;i<3;i++)
                {
                    int u=rand.Next(0, holder.Count() - 1);
                    if (i != 0) build.Append(", ");
                    build.Append(holder[u]);
                    Debug.WriteLine("This str: "+holder[u]);
                    holder.RemoveAt(u);
                }
                resultTxt.Text = build.ToString();
            }
        }
    }
}
