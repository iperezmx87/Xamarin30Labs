using Android.App;
using Android.OS;
using Android.Widget;
using SALLab10;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName")]
    public class ValidateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Validate);

            Button btnValidar = FindViewById<Button>(Resource.Id.ValidarButton);
            EditText correoText = FindViewById<EditText>(Resource.Id.CorreoEditText);
            EditText passwordText = FindViewById<EditText>(Resource.Id.PasswordEditText);

            btnValidar.Click += async (sender, e) =>
            {
                try
                {
                    ServiceClient service = new ServiceClient();

                    ResultInfo result = await service.ValidateAsync(correoText.Text, passwordText.Text,
                        Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId));

                    RunOnUiThread(() =>
                    {
                        FindViewById<TextView>(Resource.Id.EvidenciaTextView1).Text = $"{result.Status}\n{result.Fullname}\n{result.Token}";
                    });
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, $"Error: {ex.Message}", ToastLength.Long).Show();
                }
            };
        }
    }
}