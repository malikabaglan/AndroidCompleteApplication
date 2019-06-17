
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
    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddItem);
            FindViewById<Button>(Resource.Id.saveButton).Click += OnSaveClick;
            FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
        }

 void OnSaveClick(object sender, EventArgs e)
            {
                string name = FindViewById<EditText>(Resource.Id.nameInput).Text;
                int count = int.Parse(FindViewById<EditText>(Resource.Id.countInput).Text);
                var intent = new Intent();

                intent.PutExtra("ItemName", name);
                intent.PutExtra("ItemCount", count);

                // TODO

                SetResult(Result.Ok, intent);

                Finish();
            }


            void OnCancelClick(object sender, EventArgs e)
            {
                Finish();
            }
        }
    }