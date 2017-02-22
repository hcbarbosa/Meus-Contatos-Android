using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using SQLite;
using System.Collections.Generic;
using System;

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

            listViewcontatos.ItemClick += verContato_ItemClick;
        }

        private void verContato_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            ContatoList listContatos = new ContatoList();
            var contatos = listContatos.GetListContatos();

            Contato contato = contatos[e.Position];

            Intent intent = new Intent(this, typeof(SeeContact));
            intent.PutExtra("acao", "consultar");           
            intent.PutExtra("nome", contato.Nome);
            intent.PutExtra("email", contato.Email);
            intent.PutExtra("fone", contato.Fone);
            intent.PutExtra("id", contato.Id);
            StartActivity(intent);
            Finish();
        }
    }
}

