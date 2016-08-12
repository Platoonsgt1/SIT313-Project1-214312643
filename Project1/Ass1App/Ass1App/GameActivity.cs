using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Ass1App
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        //Setup public variables
        List<ToggleButton> Switchlist = new List<ToggleButton>();
        int Score = 1000;
        List<int> switchAction = new List<int>();
        Random Rgen = new Random();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Game);

            // Setup score and score text
            TextView CurrentScore = FindViewById< TextView > (Resource.Id.currentScore);
            CurrentScore.Text = "Score: " + Score;

            // Setup all the togglebuttons
            Switchlist.Insert(0, FindViewById<ToggleButton>(Resource.Id.toggleButton1));
            Switchlist.Insert(1, FindViewById<ToggleButton>(Resource.Id.toggleButton2));
            Switchlist.Insert(2, FindViewById<ToggleButton>(Resource.Id.toggleButton3));
            Switchlist.Insert(3, FindViewById<ToggleButton>(Resource.Id.toggleButton4));
            Switchlist.Insert(4, FindViewById<ToggleButton>(Resource.Id.toggleButton5));
            Switchlist.Insert(5, FindViewById<ToggleButton>(Resource.Id.toggleButton6));
            Switchlist.Insert(6, FindViewById<ToggleButton>(Resource.Id.toggleButton7));
            Switchlist.Insert(7, FindViewById<ToggleButton>(Resource.Id.toggleButton8));
            Switchlist.Insert(8, FindViewById<ToggleButton>(Resource.Id.toggleButton9));
            Switchlist.Insert(9, FindViewById<ToggleButton>(Resource.Id.toggleButton10));
            Switchlist.Insert(10, FindViewById<ToggleButton>(Resource.Id.toggleButton11));
            Switchlist.Insert(11, FindViewById<ToggleButton>(Resource.Id.toggleButton12));
            Switchlist.Insert(12, FindViewById<ToggleButton>(Resource.Id.toggleButton13));
            Switchlist.Insert(13, FindViewById<ToggleButton>(Resource.Id.toggleButton14));
            Switchlist.Insert(14, FindViewById<ToggleButton>(Resource.Id.toggleButton15));


            // Setup switch action values
            for (int i = 0; i < Switchlist.Count; i++)
            {
                switchAction.Insert(i, (Rgen.Next((2 << 15) - 1) & (((2 << 15) - 1) - (2 << i)))); // Each bit will inticate which other button to switch, and subtracting 2^i prevents it form un-switching itself
            }
            switchAction[7] = 0; // As the central button will act differntly, set it's action to 0.

            //Setup each switch's actions (I would have done this in a loop, but I couldn't pass the i value into the array position)
            Switchlist[0].Click += delegate
            {
                Switch(0);
            };
            Switchlist[1].Click += delegate
            {
                Switch(1);
            };
            Switchlist[2].Click += delegate
            {
                Switch(2);
            };
            Switchlist[3].Click += delegate
            {
                Switch(3);
            };
            Switchlist[4].Click += delegate
            {
                Switch(4);
            };
            Switchlist[5].Click += delegate
            {
                Switch(5);
            };
            Switchlist[6].Click += delegate
            {
                Switch(6);
            };
            Switchlist[7].Click += delegate
            {
                Switch(7);
            };
            Switchlist[8].Click += delegate
            {
                Switch(8);
            };
            Switchlist[9].Click += delegate
            {
                Switch(9);
            };
            Switchlist[10].Click += delegate
            {
                Switch(10);
            };
            Switchlist[11].Click += delegate
            {
                Switch(11);
            };
            Switchlist[12].Click += delegate
            {
                Switch(12);
            };
            Switchlist[13].Click += delegate
            {
                Switch(13);
            };
            Switchlist[14].Click += delegate
            {
                Switch(14);
            };

            //Setup exit button
            Button Back = FindViewById<Button>(Resource.Id.butBack);
            Back.Click += delegate
            {
                bool GameEnd = true;
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if (!Switchlist[j].Checked)
                    { GameEnd = false; }
                }
                if (GameEnd)
                {
                    // Update the highscore table, I'm assuming it's possible to do this.
                    SharedData.ShareScore = Score;
                    SharedData.ShareWin = true;
                }
                Finish();
            };

        }
        void Switch(int i)
        {
            //Update Score
            TextView CurrentScore = FindViewById<TextView>(Resource.Id.currentScore);
            CurrentScore.Text = "Score: " + (--Score);

            //Perform action based on switch position in list
            var Action = switchAction[i];
            if (Action == 0) //This is used for the center button (Switch 7), and any other switch that happens to have a 0 value
            { Action = Rgen.Next((2 << 15) - 1) & (((2 << 15) - 1) - (2 << 7)); }
            //Perform action on each other switch based on this switch's associated value
            bool GameEnd = true;
            for (int j = 0; j < Switchlist.Count; j++)
            {
                if ((Action & (2 << j)) == (2 << j))
                { Switchlist[j].Toggle(); }
                if (!Switchlist[j].Checked)
                { GameEnd = false; }
            }
            if (GameEnd)
            {
                // Get the Back button
                Button Back = FindViewById<Button>(Resource.Id.butBack);
                Back.Text = "Finish!";

                // Deactivate switches
                for (int j = 0; j < Switchlist.Count; j++)
                { Switchlist[j].Enabled = false; }
            }
            return;
        }
    }
}