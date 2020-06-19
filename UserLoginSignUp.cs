using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MathsApp
{
    public class UserLoginSignUp
    {
        [Serializable]
        public class User
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public User(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }
        }
        [Serializable]
        public class Users
        {
            public List<User> Accounts;
            public Users() => Accounts = new List<User>();

            public void SerializeAccountDetails(string filePath)
            {
                IFormatter bf = new BinaryFormatter();
                using (Stream fs = new FileStream(filePath, FileMode.Create))
                    bf.Serialize(fs, this);
            }

            public static Users DeserializeAccountDetails(string filePath)
            {
                IFormatter bf = new BinaryFormatter();
                using (Stream sr = new FileStream(filePath, FileMode.Open))
                    return bf.Deserialize(sr) as Users;
            }

            public bool ContainsUserName(string userName) =>
                Accounts.Any(x => x.UserName == userName);

            public bool ContainsAccount(string userName, string password) =>
                Accounts.Any(x => x.UserName == userName && x.Password == password);

            public bool AddAccountDetails(string userName, string password)
            {
                Accounts.Add(new User(userName, password));
                return true;
            }
        }
    }
}
