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
        private Button btnEditar, btnExcluir, btnVoltar;
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
            btnEditar = (Button)FindViewById(Resource.Id.buttonEdit);
            btnExcluir = (Button)FindViewById(Resource.Id.buttonRemove);
            btnVoltar = (Button)FindViewById(Resource.Id.buttonBack);
            imgContato = (ImageView)FindViewById(Resource.Id.imgContact);

            try
            {
                edtNome.Text = Intent.GetStringExtra("nome") ?? "dado não disponível";
                edtEmail.Text = Intent.GetStringExtra("email");
                edtFone.Text = Intent.GetStringExtra("fone");

                var acao = Intent.GetStringExtra("acao");

                if (acao != null && acao.Equals("consultar"))
                {

                }
                else if (acao != null && acao.Equals("confirmacao"))
                {
                    btnEditar.Visibility = ViewStates.Invisible;
                    btnExcluir.Visibility = ViewStates.Invisible;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Erro: "+ex.Message, ToastLength.Long).Show();
            }   

            btnVoltar.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Finish();
            };

            btnEditar.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Contact));
                intent.PutExtra("acao", "editar");
                intent.PutExtra("nome", edtNome.Text);
                intent.PutExtra("email", edtEmail.Text);
                intent.PutExtra("fone", edtFone.Text);
                var id = Intent.GetIntExtra("id",0);
                intent.PutExtra("id", id);

                StartActivity(intent);
                Finish();
            };

            btnExcluir.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));

                var id = Intent.GetIntExtra("id", 0);
                Contato contato = gerenciaBD.getContato(id);
                gerenciaBD.remove(contato);
                Toast.MakeText(this, "Ação realizada com sucesso", ToastLength.Short).Show();

                StartActivity(intent);
                Finish();
            };
        }
    }
}