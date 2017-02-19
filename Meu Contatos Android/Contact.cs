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
        private Button btnEditar, btnExcluir, btnSalvar;
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
            btnEditar = (Button)FindViewById(Resource.Id.buttonEdit);
            btnExcluir = (Button)FindViewById(Resource.Id.buttonRemove);
            btnSalvar = (Button)FindViewById(Resource.Id.buttonSave);
            imgContato = (ImageView)FindViewById(Resource.Id.imgContact);
            
            //verifica se esta consultando um contato ou eh um novo
            if(bundle != null)
            {
                //consultando contato
                this.SetTitle(Resource.String.seeContact);
                edtEmail.InputType = 0;
                edtFone.InputType = 0;
                edtNome.InputType = 0;
                btnSalvar.Visibility = ViewStates.Invisible;


            }else
            {
                //novo contato
                this.SetTitle(Resource.String.newContact);
                btnEditar.Visibility = ViewStates.Invisible;
                btnExcluir.Visibility = ViewStates.Invisible;
            }

            btnSalvar.Click += salvar;
        }

        private void salvar(object sender, EventArgs ea)
        {
            var isValidoNome = verificaNome();
            var isValidoEmail = verificaEmail();
            var isValidoFone = verificaFone();

            if (isValidoEmail && isValidoFone && isValidoNome)
            {
                Intent intent = new Intent(this, typeof(SeeContact));
                intent.PutExtra("nome",edtNome.Text);
                intent.PutExtra("email",edtEmail.Text);
                intent.PutExtra("fone", edtFone.Text);

                StartActivity(intent);
            }
        }

        private Boolean verificaNome()
        {
            var isValido = true;
            isValido = (!edtNome.Text.Equals(""));

            if (!isValido)
            {
                Toast.MakeText(this, "Nome obrigatório", ToastLength.Short).Show();
            }
            return isValido;
        }

        private Boolean verificaFone()
        {
            var isValido = true;
            isValido = Android.Util.Patterns.Phone.Matcher(edtFone.Text).Matches();

            if (!isValido)
            {
                Toast.MakeText(this, "Celular inválido", ToastLength.Short).Show();
            }
            return isValido;
        }

        private Boolean verificaEmail()
        {
            var isValido = true;
            isValido =  Android.Util.Patterns.EmailAddress.Matcher(edtEmail.Text).Matches();

            if (!isValido)
            {
                Toast.MakeText(this, "E-mail inválido", ToastLength.Short).Show();
            }
            return isValido;
        }
    }
}