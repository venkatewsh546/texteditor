using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using static EncryptTextEditor.CommonMethods;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Android;
using Android.Content.PM;

namespace EncryptTextEditor
{
    [Activity(Label = "EncryptTextEditor", MainLauncher = true)]
    public class MainActivity : Activity, IChangeViewvalues
    {
        EditText selectFileEditText;
        ListView DataListView;
       static Dictionary<string, dynamic> JObj;
        static List<string> AccountSourceType;
        static EditText Passcode;


        public void Changevalues()
        {
            selectFileEditText.Text = Filepath;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            CommonMethods.Context = this;
            Activityobj = this;

            selectFileEditText = FindViewById<EditText>(Resource.Id.SelectFileEditText);
            selectFileEditText.SetRawInputType(Android.Text.InputTypes.Null);
            selectFileEditText.SetCursorVisible(true);
            selectFileEditText.Click += DisplayFilesAndFolders;


            DataListView=FindViewById<ListView>(Resource.Id.DataListView);
            DataListView.ItemClick += DecryptAndDisplayData;


            Button button = FindViewById<Button>(Resource.Id.ShowFileDataButton);

            button.Click += delegate
             {
                 try
                 {
                     JObj = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(File.ReadAllText(selectFileEditText.Text));
                     AccountSourceType = new List<string>();

                     foreach (KeyValuePair<string,dynamic> values in JObj)
                     {
                         AccountSourceType.Add(values.Key);
                     }

                     ArrayAdapter<string> adapter = new ArrayAdapter<string>(_context, Android.Resource.Layout.SimpleSpinnerItem, AccountSourceType);

                     DataListView.Adapter = adapter;

                 }
                 catch(Exception ex)
                 {

                 }
             };

            RequestPermissions();
        }

        private void DecryptAndDisplayData(object sender, AdapterView.ItemClickEventArgs e)
        {
           string selectedFromList = ((ListView)e.Parent).GetItemAtPosition(e.Position).ToString();

           Passcode = new EditText(this);

            new AlertDialog.Builder(this)
              .SetTitle("input Password")
              .SetMessage("Enter Password to Decrypt Data")
              .SetView(Passcode)
              .SetPositiveButton("Ok", (c, ev) => {

                  Intent intent = new Intent(this, typeof(TextActivity));
                  intent.PutExtra("SelectedFile", selectFileEditText.Text);
                  intent.PutExtra("DecryptionKey", Passcode.Text);
                  intent.PutExtra("DataForDecrypt", JObj[selectedFromList]);
                  StartActivity(intent);


              })
              .SetNegativeButton("Cancel", (c, ev) =>{})
              .Show();
        }

        private void RequestPermissions()
        {
            if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("requesting permissions");
                alert.SetMessage("requesting permissions");
                alert.SetPositiveButton("ok", (senderAlert, args) =>
                {
                    RequestPermissions(new string[]
                    { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage}, 0);

                });
                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Storage Permission Not Granted", ToastLength.Short);
                    System.Environment.Exit(0);
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }
    }
}
