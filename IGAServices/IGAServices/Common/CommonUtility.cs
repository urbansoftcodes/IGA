using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IGA.Common
{
    public static class CommonUtility
    {
        public static string EGovUrl = ConfigurationManager.AppSettings["IGAUrl"].ToString();
        //public static string PNAppKey = ConfigurationManager.AppSettings["PushnotificationOnesignalAppKey"].ToString();
        //public static string PNUserAuth = ConfigurationManager.AppSettings["PushnotificationUserkey"].ToString();
        //public static string PicturePath = ConfigurationManager.AppSettings["ProfilePicturePath"].ToString();
        //public static string APIURL = ConfigurationManager.AppSettings["APIURL"].ToString();

        public const string myPassKeyW = "wix";
        public const string myPassKeyVisitor = "isonVisir";
        private const string initVector = "tu56geji340t89u2";

        private const int keysize = 256;
        public static string Encrypt(this string plainText)
        {
            if (!string.IsNullOrEmpty(plainText))
            {
                byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(myPassKeyVisitor, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                return Convert.ToBase64String(cipherTextBytes);
            }
            else
            {
                return "";
            }
        }


        public static string DecryptString(this string cipherText)
        {
            if (!string.IsNullOrEmpty(cipherText))
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(myPassKeyVisitor, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
            else
            {
                return "";
            }
        }

        public static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }


        public static List<T> BindList<T>(this DataTable dt)
        {
            List<T> lst = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();

                try
                {
                    foreach (DataColumn column in dr.Table.Columns)
                    {
                        foreach (PropertyInfo pro in temp.GetProperties())
                        {
                            if (pro.Name == column.ColumnName)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(dr[column.ColumnName])))
                                    pro.SetValue(obj, dr[column.ColumnName], null);
                            }
                            else
                                continue;
                        }
                    }
                }
                catch (Exception exc)
                {

                }

                lst.Add(obj);
            }


            return lst;
        }

    }
}
