using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using static texteditor.CommonMethods;

namespace texteditor
{
    [Activity(Label = "texteditor", MainLauncher = true)]
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

            //editText = FindViewById<EditText>(Resource.Id.Notepad);
            //editText.RequestFocus();
            //InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            //imm.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
            //editText.Text = "Apple to have own-brand, high-end over-ear headphones with all-new design; to be as convenient as AirPods with better sound quality; shipments to begin 4Q18F at earliest; Primax & SZS will be the key suppliers & will benefit from high ASPs. We believe that after AirPods and HomePod, Apple’s next addition will be high-end over-ear headphones, making its acoustic accessory lineup more complete. Existing suppliers Primax and SZS will be Apple’s partners on this new product. Primax will receive assembly orders on its familiarity with the acoustic business, and SZS is likely to use MIM technology advantages as leverage to become the exclusive or main MIM part supplier. The new headphones will be priced higher than AirPods and should help boost the business momentum of Primax as the assembly provider. Apple to have own-brand, high-end over-ear headphones with all-new design; to be as convenient as AirPods with better sound quality; shipments to begin 4Q18F at earliest; Primax & SZS will be the key suppliers & will benefit from high ASPs. We believe that after AirPods and HomePod, Apple’s next addition will be high-end over-ear headphones, making its acoustic accessory lineup more complete. Existing suppliers Primax and SZS will be Apple’s partners on this new product. Primax will receive assembly orders on its familiarity with the acoustic business, and SZS is likely to use MIM technology advantages as leverage to become the exclusive or main MIM part supplier. The new headphones will be priced higher than AirPods and should help boost the business momentum of Primax as the assembly provider.Apple to have own-brand, high-end over-ear headphones with all-new design; to be as convenient as AirPods with better sound quality; shipments to begin 4Q18F at earliest; Primax & SZS will be the key suppliers & will benefit from high ASPs. We believe that after AirPods and HomePod, Apple’s next addition will be high-end over-ear headphones, making its acoustic accessory lineup more complete. Existing suppliers Primax and SZS will be Apple’s partners on this new product. Primax will receive assembly orders on its familiarity with the acoustic business, and SZS is likely to use MIM technology advantages as leverage to become the exclusive or main MIM part supplier. The new headphones will be priced higher than AirPods and should help boost the business momentum of Primax as the assembly provider.Apple to have own-brand, high-end over-ear headphones with all-new design; to be as convenient as AirPods with better sound quality; shipments to begin 4Q18F at earliest; Primax & SZS will be the key suppliers & will benefit from high ASPs. We believe that after AirPods and HomePod, Apple’s next addition will be high-end over-ear headphones, making its acoustic accessory lineup more complete. Existing suppliers Primax and SZS will be Apple’s partners on this new product. Primax will receive assembly orders on its familiarity with the acoustic business, and SZS is likely to use MIM technology advantages as leverage to become the exclusive or main MIM part supplier. The new headphones will be priced higher than AirPods and should help boost the business momentum of Primax as the assembly provider.Apple to have own-brand, high-end over-ear headphones with all-new design; to be as convenient as AirPods with better sound quality; shipments to begin 4Q18F at earliest; Primax & SZS will be the key suppliers & will benefit from high ASPs. We believe that after AirPods and HomePod, Apple’s next addition will be high-end over-ear headphones, making its acoustic accessory lineup more complete. Existing suppliers Primax and SZS will be Apple’s partners on this new product. Primax will receive assembly orders on its familiarity with the acoustic business, and SZS is likely to use MIM technology advantages as leverage to become the exclusive or main MIM part supplier. The new headphones will be priced higher than AirPods and should help boost the business momentum of Primax as the assembly provider.Apple to have own-brand, high-end over-ear headphones with all-new design; to be as convenient as AirPods with better sound quality; shipments to begin 4Q18F at earliest; Primax & SZS will be the key suppliers & will benefit from high ASPs. We believe that after AirPods and HomePod, Apple’s next addition will be high-end over-ear headphones, making its acoustic accessory lineup more complete. Existing suppliers Primax and SZS will be Apple’s partners on this new product. Primax will receive assembly orders on its familiarity with the acoustic business, and SZS is likely to use MIM technology advantages as leverage to become the exclusive or main MIM part supplier. The new headphones will be priced higher than AirPods and should help boost the business momentum of Primax as the assembly provider.Apple to have own-brand, high-end over-ear headphones with all-new design; to be as convenient as AirPods with better sound quality; shipments to begin 4Q18F at earliest; Primax & SZS will be the key suppliers & will benefit from high ASPs. We believe that after AirPods and HomePod, Apple’s next addition will be high-end over-ear headphones, making its acoustic accessory lineup more complete. Existing suppliers Primax and SZS will be Apple’s partners on this new product. Primax will receive assembly orders on its familiarity with the acoustic business, and SZS is likely to use MIM technology advantages as leverage to become the exclusive or main MIM part supplier. The new headphones will be priced higher than AirPods and should help boost the business momentum of Primax as the assembly provider.";
        }
    }
}
