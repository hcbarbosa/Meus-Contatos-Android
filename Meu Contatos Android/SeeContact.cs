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

namespace Meu_Contatos_Android
{
    [Activity(Label = "@string/seeContact")]
    public class SeeContact : Activity
    {
        private EditText edtNome, edtEmail, edtFone;
        private Button btnVoltar;
        private ImageView imgContato;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view
            SetContentView(Resource.Layout.SeeContact);

            // conecta os elementos do layout com variaveis
            edtNome = (EditText)FindViewById(Resource.Id.editTextName);
            edtEmail = (EditText)FindViewById(Resource.Id.editTextEmail);
            edtFone = (EditText)FindViewById(Resource.Id.editTextPhone);
            btnVoltar = (Button)FindViewById(Resource.Id.buttonBack);
            imgContato = (ImageView)FindViewById(Resource.Id.imgContact);

            edtNome.Text = Intent.GetStringExtra("nome") ?? "dado não disponível";
            edtEmail.Text = Intent.GetStringExtra("email");
            edtFone.Text = Intent.GetStringExtra("Fone");

            btnVoltar.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }
    }
}