using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Meu_Contatos_Android
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button btnAdd;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            btnAdd = (Button)FindViewById(Resource.Id.buttonAddContact);
            btnAdd.Click += delegate
            {
               Intent intent = new Intent(this, typeof(Contact));
               StartActivity(intent);
            };
        }
    }
}

