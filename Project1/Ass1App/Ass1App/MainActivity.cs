using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Ass1App
{
    [Activity(Label = "Ass1App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        class Score : IComparable
        {
            public int Value;
            public string Name;

            public Score(int V, string N)
            {
                Value = V;
                Name = N;
            }

            //Setup how it's compard to allow it to be sorted
            public int CompareTo(object obj)
            {
                if (obj == null) { return 1; }
                Score CSc = obj as Score;
                if (CSc != null)
                { return Value.CompareTo(CSc.Value); }
                else
                { return 1; }
            }
        }

        List<Score> Scorelist = new List<Score>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Setup starting variables
            for (int i = 0; i < 10; i++)
            {
                Scorelist.Insert(i, new Score((i) * 50, "AAA"));
            }
            Scorelist.Sort();
            //Public variables

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our textview from the layout resource
            TextView ScoreText = FindViewById<TextView>(Resource.Id.textScore);

            //Setup default values
            string Text = "";
            for (int i = 0; i < 10; i++)
            {
                Text = Scorelist[i].Value + " - " + Scorelist[i].Name + "\r\n" + Text;
            }
            ScoreText.Text = Text;

            TextView NameBar = FindViewById<TextView>(Resource.Id.textName);
            TextView StartButton = FindViewById<TextView>(Resource.Id.butStart);
            StartButton.Click += delegate
            {
                SharedData.ShareName = NameBar.Text;
                var game = new Intent(this, typeof(GameActivity));
                StartActivity(game);
            };

            TextView ExitButton = FindViewById<TextView>(Resource.Id.butExit);
            ExitButton.Click += delegate
            {
                Finish();
            };
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (SharedData.ShareWin)
            {
                //Update Highscores
                Scorelist.Insert(10, new Score(SharedData.ShareScore, SharedData.ShareName));
                Scorelist.Sort();
                Scorelist.RemoveAt(0);

                //Update highscore table
                TextView ScoreText = FindViewById<TextView>(Resource.Id.textScore);
                string Text = "";
                for (int i = 0; i < 10; i++)
                {
                    Text = Scorelist[i].Value + " - " + Scorelist[i].Name + "\r\n" + Text;
                }
                ScoreText.Text = Text;
            }
        }
    }

    public class SharedData
    {
        public static int ShareScore = 0;
        public static string ShareName = "AAA";
        public static bool ShareWin = false;
    }
}

