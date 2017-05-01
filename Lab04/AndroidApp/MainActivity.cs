using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "Lab04", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

            var validator = new PCLProject.AppValidator(new AndroidDialog(this));

            validator.device = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId
                );
            validator.email = "israel.perez@cencel.com.mx";
            validator.password = "Isra-mx87";

            validator.Validate();
        }
    }
}

