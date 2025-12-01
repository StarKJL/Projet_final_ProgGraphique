using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Classes
{
    internal class admin
    {
        int id;
        string username;
        string password;
        bool actif;
        const String cle = "qwertyasdfgzxcvb";

        public admin(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = crypter(password,cle);
            this.actif = false;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => decrypter(password,cle);
             set{
                crypter(password, cle);
                } 
        }
        public bool Actif { get => actif; set => actif = value; }

        public string crypter(string texte, string cle)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(cle);
                aes.IV = iv;

                ICryptoTransform chiffreur = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, chiffreur, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(texte);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        public string decrypter(string texteCrypte, string cle)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(texteCrypte);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(cle);
                aes.IV = iv;
                ICryptoTransform dechiffreur = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, dechiffreur, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }



    }
}
