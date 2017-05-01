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
using PCLProject;

namespace AndroidApp
{
    public class AndroidDialog : IDialog
    {
        Context AppContext;

        // $"{result.Status}\n{result.Fullname}\n{result.Token}"

        public AndroidDialog(Context context)
        {
            AppContext = context;

        }

        public void Show(string message)
        {
            var dialog = new AlertDialog.Builder(AppContext);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetMessage(message);
            alert.SetButton("Ok", (s, ev) => { });
            alert.Show();
        }
    }
}