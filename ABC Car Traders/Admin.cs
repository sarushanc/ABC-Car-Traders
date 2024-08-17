using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders
{
    internal class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Login(string username, string password)
        {
            // Implement login logic here (e.g., compare with stored admin credentials)
            return this.Username == username && this.Password == password;
        }
    }
}
