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
using SQLite;

namespace Meu_Contatos_Android
{
    [Table("Contatos")]
        public class Contato
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Fone { get; set; }
      
       
        public override string ToString()
        {
            return string.Format("[Contato: ID={0}, Nome={1}, Email={2}, Fone={3}]", Id, Nome, Email, Fone);
        }
    }

    public class ContatoList
    {
        public Contato[] GetListContatos()
        {
            var lista = gerenciaBD.consultaContatos();
            return lista;
        }
    }
}