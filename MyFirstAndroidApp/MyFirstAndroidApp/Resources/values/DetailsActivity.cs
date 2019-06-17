
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

namespace MyFirstAndroidApp
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Details);

            int position = Intent.GetIntExtra("ItemPosition", -1);

            var item = MainActivity.Items[position];

            FindViewById<TextView>(Resource.Id.nameTextView).Text = "Name: " + item.Name;
            FindViewById<TextView>(Resource.Id.countTextView).Text = "Count: " + item.Count.ToString();
        }
    }
}
