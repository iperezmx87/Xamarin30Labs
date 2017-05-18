using Android.App;
using Android.OS;
using Android.Widget;
using SALLab07;

namespace PhoneApp
{
    [Activity(Label = "Phone App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btnValidarActividad = FindViewById<Button>(Resource.Id.ValidarButton);
            EditText correoText = FindViewById<EditText>(Resource.Id.CorreoEditText);
            EditText passwordText = FindViewById<EditText>(Resource.Id.PasswordEditText);

            btnValidarActividad.Click += async (sender, e) =>
            {
                ServiceClient service = new ServiceClient();

                ResultInfo result = await service.ValidateAsync(correoText.Text, passwordText.Text,
                    Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId));

                // detectando version de android
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    var notifBuilder = new Notification.Builder(this);

                    notifBuilder.SetContentTitle("Phone App");
                    notifBuilder.SetContentText($"{result.Status}\n{result.Fullname}\n{result.Token}");
                    notifBuilder.SetSmallIcon(Resource.Drawable.Icon);

                    notifBuilder.SetCategory(Notification.CategoryMessage);

                    var ObjectNotif = notifBuilder.Build();

                    var Manager = GetSystemService(NotificationService) as NotificationManager;

                    Manager.Notify(0, ObjectNotif);
                }
                else
                {
                    // version menor a lollipop
                    RunOnUiThread(() =>
                    {
                        FindViewById<TextView>(Resource.Id.EvidenciaTextView1).Text = $"{result.Status}\n{result.Fullname}\n{result.Token}";
                    });
                }
            };

        }
    }
}