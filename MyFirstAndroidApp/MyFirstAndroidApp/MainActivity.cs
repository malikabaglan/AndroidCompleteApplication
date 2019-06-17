using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using Android.Content;

namespace MyFirstAndroidApp
{

    public class Item
    {
        public Item(string name, long count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; set; }
        public long Count { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }




    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static List<Item> Items = new List<Item>();
        protected override void OnCreate(Bundle savedInstanceState)


        {


            Items.Add(new Item("Milk", 2));
            Items.Add(new Item("Crackers", 1));
            Items.Add(new Item("Apples", 5));

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);



            FindViewById<Button>(Resource.Id.itemsButton).Click += OnItemsClick;
           FindViewById<Button>(Resource.Id.addItemButton).Click += OnAddItemClick;
            FindViewById<Button>(Resource.Id.aboutButton).Click += OnAboutClick;
        }


        void OnItemsClick(object sender, EventArgs e)
        {
            //
            // Use the standard technique to start an Activity: create an Intent and then pass it to StartActivity.
            //
            var intent = new Intent(this, typeof(ItemsActivity));

            StartActivity(intent);
        }

        void OnAddItemClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddItemActivity));

            //
            // The AddItem Activity will return the Name and Count of the newly added item.
            // Use StartActivityForResult so you are notified when the AddItem Activity completes.
            // The parameter '100' is the request code that lets you identify which Activity is sending you results;
            // the value '100' is arbitrary, it has no meaning to Android.
            //
            StartActivityForResult(intent, 100);
        }
        void OnAboutClick(object sender, EventArgs e)
        {
            //
            // Use the convenience method to start an Activity without creating an Intent.
            //
            StartActivity(typeof(AboutActivity));
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            //
            // A requestCode of 100 indicates this result is from the AddItem Activity.
            // A resultCode of OK means the user touched the SAVE button and not the CANCEL button.
            // The values for the new item are stored in the Intent Extras.
            //
            if (requestCode == 100 && resultCode == Result.Ok)
            {
                string name = data.GetStringExtra("ItemName");
                int count = data.GetIntExtra("ItemCount", 0);

                MainActivity.Items.Add(new Item(name, count));
            }
        }











        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}