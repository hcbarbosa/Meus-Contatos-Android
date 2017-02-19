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
        private ListView listViewcontatos;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            btnAdd = (Button)FindViewById(Resource.Id.buttonAddContact);
            btnAdd.Click += delegate
            {
               Intent intent = new Intent(this, typeof(Contact));
               intent.PutExtra("acao","incluir");
               StartActivity(intent);
               Finish();
            };


            ContatoList listContatos = new ContatoList();
            var contatos = listContatos.GetListContatos();

            listViewcontatos = (ListView)FindViewById(Resource.Id.listViewContacts);
            ContatoAdapter adapter = new ContatoAdapter(contatos);
            listViewcontatos.Adapter = adapter;
        }
    }
}

