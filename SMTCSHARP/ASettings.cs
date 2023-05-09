using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace SMTCSHARP
{
    static class ASettings
    {
        const string myversion = "1.0.7.2";
        static string myuser;
        static string myuserfname;
        static string myuserid;
        static string mypw;
        static string mygroup;
        static string myconstr = "Server={0};Database={1};User Id={2};Password ={3};";

        static string mysserver;
        static string mysserver_api;
        static string mysuser;
        static string myspw;
        static string mysdb;
        static string myBusinessGroup;
        static bool runsess = false;

        public static string getVersion()
        {
            return myversion;
        }

        public static void setmyuserfname(string p1)
        {
            myuserfname = p1;
        }

        public static string getmyuserfname()
        {
            return myuserfname;
        }

        public static void setmyBusinessGroup(string p1)
        {
            myBusinessGroup = p1;
        }

        public static string getmyBusinessGroup()
        {

            return myBusinessGroup ?? "";
        }


        public static void setmyuserid(string puserid)
        {
            myuserid = puserid;
        }

        public static string getmyuserid()
        {
            return myuserid;
        }

        public static void setmyuser(string puser)
        {
            myuser = puser;
        }

        public static string getmyuser()
        {
            return myuser;
        }

        public static void setmypw(string ppw)
        {
            mypw = ppw;
        }

        public static string getmypw()
        {
            return mypw;
        }

        public static string getconstr()
        {
            return myconstr;
        }

        public static void setmygroup(string pgroup)
        {
            mygroup = pgroup;
        }

        public static string getmygroup()
        {
            return mygroup;
        }

        public static void setmys_server_api(string p1)
        {
            mysserver_api = p1;
        }

        public static string getmys_server_api()
        {
            return mysserver_api;
        }

        public static void setmys_server(string p1)
        {
            mysserver = p1;
        }

        public static string getmys_server()
        {
            return mysserver;
        }



        public static void setmys_user(string p1)
        {
            mysuser = p1;
        }

        public static string getmys_user()
        {
            return mysuser;
        }

        public static void setmys_db(string p1)
        {
            mysdb = p1;
        }

        public static string getmys_db()
        {
            return mysdb;
        }

        public static void setmys_pw(string p1)
        {
            myspw = p1;
        }

        public static string getmys_pw()
        {
            return myspw;
        }

        public static void setmyrunsess(bool p1)
        {
            runsess = p1;
        }

        public static bool getmyrunsess()
        {
            return runsess;
        }

        static string Encrypt(string string_to_encrypt)
        {
            try
            {
                string textToEncrypt = string_to_encrypt;
                string ToReturn = "";
                string publickey = "123SMT#";
                string secretkey = "123SMT+";
                byte[] secretkeyByte = { };
                secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

    }
}
