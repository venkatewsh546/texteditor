using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using static EncryptTextEditor.CommonMethods;

namespace EncryptTextEditor
{
    [Activity(Label = "EncryptTextEditor", MainLauncher = true)]
    public class MainActivity : Activity, IChangeViewvalues
    {
        EditText selectFileEditText;
        EditText decryptKeyeditText;

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
            decryptKeyeditText = FindViewById<EditText>(Resource.Id.DecryptKeyeditText);


            selectFileEditText.SetRawInputType(Android.Text.InputTypes.Null);
            selectFileEditText.SetCursorVisible(true);
            selectFileEditText.Click += DisplayFilesAndFolders;
           
            Button button = FindViewById<Button>(Resource.Id.ShowFileDataButton);
            button.Click += delegate
            {
                Intent intent = new Intent(this, typeof(TextActivity));
                intent.PutExtra("SelectedFile", selectFileEditText.Text);
                intent.PutExtra("DecryptionKey", decryptKeyeditText.Text);
                StartActivity(intent);
              
            };

      }
    }
}
