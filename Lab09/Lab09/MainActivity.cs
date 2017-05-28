using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Lab09
{
    [Activity(Label = "Lab09", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ValidarActividad();
        }

        private async void ValidarActividad()
        {
            try
            {
                SALLab09.ServiceClient client = new SALLab09.ServiceClient();

                SALLab09.ResultInfo result = await client.ValidateAsync("israel.perez@cencel.com.mx", "Isra-mx87",
                    Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId));

                RunOnUiThread(() =>
                {
                    FindViewById<TextView>(Resource.Id.UserNameValue).Text = result.Fullname;
                    FindViewById<TextView>(Resource.Id.StatusValue).Text = Enum.GetName(typeof(SALLab09.Status), result.Status);
                    FindViewById<TextView>(Resource.Id.TokenValue).Text = result.Token;
                });
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Error: {ex.Message}", ToastLength.Long).Show();
            }
        }
    }
}

