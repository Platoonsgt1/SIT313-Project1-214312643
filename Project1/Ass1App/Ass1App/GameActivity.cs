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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Game);

            int Score = 1000;
            TextView CurrentScore = FindViewById< TextView > (Resource.Id.currentScore);
            CurrentScore.Text = "Score: " + Score;

            List<ToggleButton> Switchlist = new List<ToggleButton>();
            Switchlist.Insert(0, FindViewById<ToggleButton>(Resource.Id.toggleButton1));
            Switchlist.Insert(1, FindViewById<ToggleButton>(Resource.Id.toggleButton2));
            Switchlist.Insert(2, FindViewById<ToggleButton>(Resource.Id.toggleButton3));
            Switchlist.Insert(3, FindViewById<ToggleButton>(Resource.Id.toggleButton4));
            Switchlist.Insert(4, FindViewById<ToggleButton>(Resource.Id.toggleButton5));
            Switchlist.Insert(5, FindViewById<ToggleButton>(Resource.Id.toggleButton6));
            Switchlist.Insert(6, FindViewById<ToggleButton>(Resource.Id.toggleButton7));
            Switchlist.Insert(7, FindViewById<ToggleButton>(Resource.Id.toggleButton9));
            Switchlist.Insert(8, FindViewById<ToggleButton>(Resource.Id.toggleButton10));
            Switchlist.Insert(9, FindViewById<ToggleButton>(Resource.Id.toggleButton11));
            Switchlist.Insert(10, FindViewById<ToggleButton>(Resource.Id.toggleButton12));
            Switchlist.Insert(11, FindViewById<ToggleButton>(Resource.Id.toggleButton13));
            Switchlist.Insert(12, FindViewById<ToggleButton>(Resource.Id.toggleButton14));
            Switchlist.Insert(13, FindViewById<ToggleButton>(Resource.Id.toggleButton15));
            Switchlist.Insert(14, FindViewById<ToggleButton>(Resource.Id.toggleButton8)); //Number 8 acts differently, so I'll put it at the end of the list

            for (int i = 0; i < Switchlist.Count; i++)
            {
                Switchlist[i].Click += delegate
                {
                    //Perform action based on switch position in list
                    CurrentScore.Text = "Score: " + (--Score);
                };
            }

            Button Back = FindViewById<Button>(Resource.Id.butBack);
            Back.Click += delegate
            {
                Finish();
            };
        }
    }
}