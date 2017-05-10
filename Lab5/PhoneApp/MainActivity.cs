using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

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

            var PhoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var CallButton = FindViewById<Button>(Resource.Id.CallButton);

            CallButton.Enabled = false;
            var TranslatedNumber = string.Empty;

            TranslateButton.Click += (object sender, EventArgs e) =>
            {
                var Translator = new PhoneTranslator();
                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    CallButton.Text = "Llamar";
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.Text = $"Llamar al {TranslatedNumber}";
                    CallButton.Enabled = true;
                }
            };

            CallButton.Click += (object sender, EventArgs e) =>
            {
                var CallDialog = new AlertDialog.Builder(this);
                CallDialog.SetMessage($"Llamar al número {TranslatedNumber}");
                CallDialog.SetNeutralButton("Llamar", delegate
                {
                    var CallIntent = new Intent(Intent.ActionCall);
                    CallIntent.SetData(Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));
                    StartActivity(CallIntent);
                });

                CallDialog.SetNegativeButton("Cancelar", delegate { });

                CallDialog.Show();
            };
            Validate();
        }

        private async void Validate()
        {
            // enviando evidencia
            var serviceClient = new SALLab05.ServiceClient();
            string email = "israel.perez@cencel.com.mx";
            string password = "Isra-mx87";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId
                );
            var result = await serviceClient.ValidateAsync(email, password, myDevice);

            RunOnUiThread(() =>
            {
                FindViewById<TextView>(Resource.Id.EvidenciaTextView).Text = $"{result.Status}\n{result.Fullname}\n{result.Token}";
            });
        }
    }
}

