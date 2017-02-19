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

    public class Contato
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }


        private string nome;
        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }


        private string fone;
        public string Fone
        {
            get
            {
                return fone;
            }

            set
            {
                fone = value;
            }
        }

        public Contato(int id, string nome, string email, string fone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Fone = fone;

        }
    }

    public class ContatoList
    {
        public Contato[] GetListContatos()
        {
            Contato[] contatos = new Contato[3];
            Contato contato1 = new Contato(1, "hanna", "hcb@hcb.com", "17981562565");
            Contato contato2 = new Contato(2, "mary", "mary@hcb.com", "17981562565");
            Contato contato3 = new Contato(3, "jess", "jess@hcb.com", "17981562565");
            contatos[0] = contato1;
            contatos[1] = contato2;
            contatos[2] = contato3;
            return contatos;
        }
    }
}