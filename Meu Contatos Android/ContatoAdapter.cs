using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Linq;

namespace Meu_Contatos_Android
{ 
    public class ContatoAdapter : BaseAdapter<Contato>
    {
        Contato[] data;

        public ContatoAdapter(Contato[] data)
        {
            this.data = data;
        }

        public override Contato this[int position]
        {
            get
            {
                return data[position];
            }
        }

        public override int Count
        {
            get
            {
                return data.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return data[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.ContatoItem, parent, false);

            var txtNome = view.FindViewById<TextView>(Resource.Id.contatoNameItem);
            var txtFone = view.FindViewById<TextView>(Resource.Id.contatoFoneItem);

            txtNome.Text = data[position].Nome;
            txtFone.Text = data[position].Fone;

            return view;
        }
    }
}