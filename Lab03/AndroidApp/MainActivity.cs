using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "Lab 03", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

            //var helper = new SharedProject.MySharedCode();
            //new AlertDialog.Builder(this)
            //    .SetMessage(helper.GetFilePath("demo.dat"))
            //    .Show();

            Validate();
        }

        private async void Validate()
        {
            var serviceClient = new SALLab03.ServiceClient();
            string email = "";
            string password = "";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId
                );
            var result = await serviceClient.ValidateAsync(email, password, myDevice);

            var dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetMessage($"{result.Status}\n{result.Fullname}\n{result.Token}");
            alert.SetButton("Ok", (s, ev) => { });
            alert.Show();
        }
    }
}

