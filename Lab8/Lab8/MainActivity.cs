using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Lab8
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //var viewGroup = (Android.Views.ViewGroup)Window.DecorView.FindViewById(Android.Resource.Id.Content);

            //var MainLayout = viewGroup.GetChildAt(0) as LinearLayout;

            //var headerImage = new ImageView(this);

            //headerImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);

            //MainLayout.AddView(headerImage);

            //var userNameTextView = new TextView(this);

            //userNameTextView.Text = GetString(Resource.String.UserName);

            //MainLayout.AddView(userNameTextView);

            ValidarActividad();
        }

        private async void ValidarActividad()
        {
            try
            {
                SALLab08.ServiceClient client = new SALLab08.ServiceClient();

                SALLab08.ResultInfo result = await client.ValidateAsync("israel.perez@cencel.com.mx", "Isra-mx87",
                    Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId));

                RunOnUiThread(() =>
                {
                    FindViewById<TextView>(Resource.Id.UserNameValue).Text = result.Fullname;
                    FindViewById<TextView>(Resource.Id.StatusValue).Text = Enum.GetName(typeof(SALLab08.Status), result.Status);
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

