using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace SMTCSHARP
{
    static class ASettings
    {
        const string myversion = "2.2.6";
        static string myuser;
        static string myuserfname;
        static string myuserid;
        static string mypw;
        static string mygroup;
        static string myconstr = "Server={0};Database={1};User Id={2};Password ={3};";
        static string myconstrX = "Server={0};Database={1};User={2};Password={3};";

        static string mysserver_api;
        static string mysserver;
        static string mysuser;
        static string myspw;
        static string mysdb;

        static string mysserverX;
        static string mysuserX;
        static string myspwX;
        static string mysdbX;

        static string myBusinessGroup;
        static bool runsess = false;
        static char myflag;
        static char myContext;

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
        
        public static string getconstrX()
        {
            return myconstrX;
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

        public static void setmyflag(char p1)
        {
            myflag = p1;
        }

        public static char getmyflag()
        {
            return myflag;
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

        public static void setmyContext(char p1)
        {
            myContext = p1;
        }

        public static char getmyContext()
        {
            return myContext;
        }

        public static string getMysserverX()
        {
            return mysserverX;
        }

        public static void setMysserverX(string p1)
        {
            mysserverX = p1;
        }

        public static string getMysuserX()
        {
            return mysuserX;
        }

        public static void setMysuserX(string p1)
        {
            mysuserX = p1;
        }

        public static string getMyspwX()
        {
            return myspwX;
        }

        public static void setMyspwX(string p1)
        {
            myspwX = p1;
        }

        public static string getMysdbX()
        {
            return mysdbX;
        }

        public static void setMysdbX(string p1)
        {
            mysdbX = p1;
        }

    }
}
