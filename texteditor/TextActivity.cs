using System;
using System.IO;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;
using static EncryptTextEditor.CommonMethods;

namespace EncryptTextEditor
{
    [Activity(Label = "EncryptTextEditor")]
    public class TextActivity : Activity
    {
        String SelectedFile;
        String DecryptedKey;
        //Button SaveButton;
        EditText Notepad;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainText);

            SelectedFile = Intent.GetStringExtra("SelectedFile");
            DecryptedKey= Intent.GetStringExtra("DecryptionKey");

            Notepad = FindViewById<EditText>(Resource.Id.Notepad);
            Notepad.RequestFocus();
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
            Notepad.Text = "";

           // SaveButton = FindViewById<Button>(Resource.Id.SaveButton);

           // SaveButton.Click += SaveButtonClick;

           
            if (SelectedFile.Length != 0 && DecryptedKey.Length != 0)
            { 
                Notepad.Text = DecryptPassword(GetDataFromFile(SelectedFile), DecryptedKey);
            }
            else if (SelectedFile.Length != 0 && DecryptedKey.Length == 0)
            {
                Notepad.Text = GetDataFromFile(SelectedFile);
            }
            else if(SelectedFile.Length == 0 && DecryptedKey.Length == 0)
            {
                Notepad.Text = "";
            }
        }

        private void SaveToFile()
        {
            Java.IO.File myFile;

            if (SelectedFile.Trim().Length == 0)
            {
                myFile = new Java.IO.File(Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "textediterdata" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".txt"));
            }
            else
            {
                myFile = new Java.IO.File(SelectedFile);
            }

            if (DecryptedKey.Length != 0)
            {
                File.WriteAllText(myFile.AbsolutePath, EncryptPassword(Notepad.Text, DecryptedKey));
                myFile.Dispose();
            }
            else
            {
                File.WriteAllText(myFile.AbsolutePath, EncryptPassword(Notepad.Text, "0000"));
                myFile.Dispose();
            }
        }

        public override void OnBackPressed()
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Save Changes");
            alert.SetMessage("do you want to save changes");
            alert.SetButton("Save", (c, ev) =>
            {
                SaveToFile();
                Finish();
            });
            alert.SetButton2("CANCEL", (c, ev) => {
                Finish();
            });
            alert.Show();
        }
    }
}