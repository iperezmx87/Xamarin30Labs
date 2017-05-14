using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhoneApp
{
    [Activity(Label = "@string/validarActividad")]
    public class ValidateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Validate);

            Button btnValidar = FindViewById<Button>(Resource.Id.ValidarButton);
            EditText correoText = FindViewById<EditText>(Resource.Id.CorreoEditText);
            EditText passwordText = FindViewById<EditText>(Resource.Id.PasswordEditText);

            btnValidar.Click += async (sender, e) =>
            {
                var serviceClient = new SALLab06.ServiceClient();
                string email = correoText.Text;
                string password = passwordText.Text;
                string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver,
                    Android.Provider.Settings.Secure.AndroidId
                    );
                var result = await serviceClient.ValidateAsync(email, password, myDevice);

                RunOnUiThread(() =>
                {
                    FindViewById<TextView>(Resource.Id.EvidenciaTextView1).Text = $"{result.Status}\n{result.Fullname}\n{result.Token}";
                });
            };
        }
    }
}