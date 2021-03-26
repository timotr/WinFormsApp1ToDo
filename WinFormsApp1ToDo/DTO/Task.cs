using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1ToDo.DTO
{
    class Task
    {
        public int? id { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public bool marked_as_done { get; set; }
        public DateTime created_at { get; set; }

        // Tuleb errori korral
        public string message { get; set; }
    }
}
