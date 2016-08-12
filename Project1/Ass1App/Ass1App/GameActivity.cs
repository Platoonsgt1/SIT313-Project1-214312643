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

            // Setup score and score text
            int Score = 1000;
            TextView CurrentScore = FindViewById< TextView > (Resource.Id.currentScore);
            CurrentScore.Text = "Score: " + Score;

            // Setup all the togglebuttons
            List<ToggleButton> Switchlist = new List<ToggleButton>();
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

            List<int> switchAction = new List<int>();
            Random Rgen = new Random();

            // Setup switch action values
            for (int i = 0; i < Switchlist.Count; i++)
            {
                switchAction.Insert(i, (Rgen.Next((2 << 15) - 1) & (((2 << 15) - 1) - (2 << i)))); // Each bit will inticate which other button to switch, and subtracting 2^i prevents it form un-switching itself
            }
            switchAction[7] = 0; // As the central button will act differntly, set it's action to 0.

            //Setup each switch's actions (I would have done this in a loop, but I couldn't pass the i value into the array position)
            Switchlist[0].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[0];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[1].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[1];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[2].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[2];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[3].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[3];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[4].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[4];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[5].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[5];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[6].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[6];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[7].Click += delegate //This one performs a random action each time, rather than having an action set at the start of the game.
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = Rgen.Next((2 << 15) - 1) & (((2 << 15) - 1) - (2 << 7));
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[8].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[8];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[9].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[9];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[10].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[10];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[11].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[11];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[12].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[12];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[13].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[13];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };
            Switchlist[14].Click += delegate
            {
                CurrentScore.Text = "Score: " + (--Score);

                //Perform action based on switch position in list
                var Action = switchAction[14];
                //Perform action on each other switch based on this switch's associated value
                for (int j = 0; j < Switchlist.Count; j++)
                {
                    if ((Action & (2 << j)) == (2 << j))
                    {
                        Switchlist[j].Toggle();
                    }
                }
            };

            //Setup exit button
            Button Back = FindViewById<Button>(Resource.Id.butBack);
            Back.Click += delegate
            {
                Finish();
            };


        }
    }
}