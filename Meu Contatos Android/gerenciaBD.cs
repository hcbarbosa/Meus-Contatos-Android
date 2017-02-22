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
using System.IO;

namespace Meu_Contatos_Android
{
    public class gerenciaBD
    {
        public static SQLiteConnection conexao()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "BancoContatos.db3");
            var conn = new SQLiteConnection(path);
            conn.CreateTable<Contato>();
            return conn;
        }


        public static Contato insereOuAtualiza(Contato data)
        {
            var db = conexao();
            try
            {                
                if (data.Id != 0)
                {
                    db.Update(data);
                }else
                {
                    db.Insert(data);
                }
                return data;
            }
            catch (SQLiteException ex)
            {
                return null;
            }
            finally
            {
                db.Close();
            }
        }

        public static void remove(Contato data)
        {
            var db = conexao();
            try
            {
                db.Delete(data);
            }
            catch (SQLiteException ex)
            {
                
            }
            finally
            {
                db.Close();
            }
        }

        public static Contato[] consultaContatos()
        {
            var db = conexao();

            try
            {
                var lista = db.Table<Contato>();
                return lista.ToArray();
            }
            catch (SQLiteException ex)
            {
                return new Contato[0];
            }
            finally
            {
                db.Close();                
            }
        }

        public static Contato getContato(int id)
        {
            var db = conexao();

            try
            {
                var contato = db.Get<Contato>(id);
                return contato;
            }
            catch (SQLiteException ex)
            {
                return null;
            }
            finally
            {
                db.Close();
            }
        }
    }
}