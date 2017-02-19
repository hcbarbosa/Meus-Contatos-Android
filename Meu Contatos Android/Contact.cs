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
    public class Contact : Activity
    {
        private EditText edtNome, edtEmail, edtFone;
        private Button btnSalvar;
        private ImageView imgContato;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view
            SetContentView(Resource.Layout.Contact);

            // conecta os elementos do layout com variaveis
            edtNome = (EditText)FindViewById(Resource.Id.editTextName);
            edtEmail = (EditText)FindViewById(Resource.Id.editTextEmail);
            edtFone = (EditText)FindViewById(Resource.Id.editTextPhone);
            btnSalvar = (Button)FindViewById(Resource.Id.buttonSave);
            imgContato = (ImageView)FindViewById(Resource.Id.imgContact);

            //verifica se esta editando um contato ou eh um novo
            var acao = Intent.GetStringExtra("acao");

            if (acao != null && acao.Equals("editar"))
            {
                //editar contato
                this.SetTitle(Resource.String.editContact);
            }
            else if (acao != null && acao.Equals("incluir"))
            {
                //novo contato
                this.SetTitle(Resource.String.newContact);
            }

            btnSalvar.Click += salvar;
        }

        private void salvar(object sender, EventArgs ea)
        {
            var isValidoNome = verificaNome();
            var isValidoEmail = verificaEmail();
            var isValidoFone = verificaFone();

            if (isValidoEmail == "" && isValidoFone == "" && isValidoNome == "")
            {
                Intent intent = new Intent(this, typeof(SeeContact));
                intent.PutExtra("nome",edtNome.Text);
                intent.PutExtra("email",edtEmail.Text);
                intent.PutExtra("fone", edtFone.Text);
                intent.PutExtra("acao", "confirmacao");
                StartActivity(intent);
                Finish();
            }else
            {
                Toast.MakeText(this, isValidoNome + " " + isValidoEmail + " " + isValidoFone, ToastLength.Short).Show();
            }
        }

        private String verificaNome()
        {
            var isValido = true;
            isValido = (!edtNome.Text.Equals(""));

            if (!isValido)
            {
                return "Nome obrigatório";
            }
            return "";
        }

        private String verificaFone()
        {
            var isValido = true;
            isValido = Android.Util.Patterns.Phone.Matcher(edtFone.Text).Matches();

            if (!isValido)
            {
                return "Celular inválido";
            }
            return "";
        }

        private String verificaEmail()
        {
            var isValido = true;
            isValido =  Android.Util.Patterns.EmailAddress.Matcher(edtEmail.Text).Matches();

            if (!isValido)
            {
               return "E-mail inválido";
            }
            return "";
        }
    }
}