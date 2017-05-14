using Android.App;
using Android.Widget;
using Android.OS;
using SALLab02;

namespace AndroidApp
{
    [Activity(Label = "Xam Lab 2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            Validate();
        }

        private async void Validate()
        {
            ServiceClient serviceClient = new ServiceClient();
            string studentEmail = "";
            string password = "";

            string myDevice = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab02.ResultInfo result = await serviceClient.ValidateAsync(studentEmail, password, myDevice);

            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            AlertDialog alert = builder.Create();
            alert.SetTitle("Resultado de la verificacion");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage($"{result.Status}\n{result.Fullname}\n{result.Token}");
            alert.SetButton("Ok", (s, ev) => { });
            alert.Show();
        }
    }
}

