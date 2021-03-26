using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1ToDo.DTO
{
    class User
    {
        public int? id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string newPassword { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string access_token { get; set; }
        public DateTime created_at { get; set; }

        // Tuleb errori korral
        public string message { get; set; }
    }
}
