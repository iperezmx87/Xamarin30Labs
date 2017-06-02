using Android.App;
using Android.Widget;
using Android.OS;
using SALLab10;
using Android.Content;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int counter = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            //var contentHeader = FindViewById<TextView>(Resource.Id.ContentHeader);
            //contentHeader.Text = GetText(Resource.String.ContentHeader);

            var clickMe = FindViewById<Button>(Resource.Id.ClickMe);
            //var clickCounter = FindViewById<TextView>(Resource.Id.ClickCounter);

            clickMe.Click += (s, e) =>
            {
                //counter++;
                //clickCounter.Text = Resources.GetQuantityString(Resource.Plurals.numberOfClicks, counter, counter);

                //var player = Android.Media.MediaPlayer.Create(this, Resource.Raw.sound);

                //player.Start();

                Intent intent = new Intent(this, typeof(ValidateActivity));
                StartActivity(intent);
            };

            //Android.Content.Res.AssetManager Manager = this.Assets;

            //using (var Reader = new System.IO.StreamReader(Manager.Open("Contenido.txt")))
            //{
            //    contentHeader.Text = $"\n\n{Reader.ReadToEnd()}";
            //}
        }
    }
}

