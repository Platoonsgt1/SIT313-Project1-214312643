using System;
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
        struct Score
        {
            public int Value;
            public string Name;

            public Score(int V, string N)
            {
                Value = V;
                Name = N;
            }
        }

        //Public variables
        JavaList<Score> Scorelist = new JavaList<Score>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Setup starting variables
            for (int i = 0; i < 10; i++)
            {
                Scorelist.Insert(i, new Score((i) * 111, "AAA"));
            }

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our textview from the layout resource
            TextView ScoreText = FindViewById<TextView>(Resource.Id.textScore);

            //Setup default values
            string Text = "";
            for (int i = 0; i < 10; i++)
            {
                Text += Scorelist[i].Value + " - " + Scorelist[i].Name + "\r\n";
            }
            ScoreText.Text = Text;

            TextView StartButton = FindViewById<TextView>(Resource.Id.butStart);
            StartButton.Click += delegate
            {
                var game = new Intent(this, typeof(GameActivity));
                StartActivity(game);
            };

            TextView ExitButton = FindViewById<TextView>(Resource.Id.butExit);
            ExitButton.Click += delegate
            {
                Finish();
            };
        }
    }
}

