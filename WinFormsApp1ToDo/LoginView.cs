using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1ToDo.DTO;

namespace WinFormsApp1ToDo
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            User user = ToDoAPI.Login(usernameInput.Text, passwordInput.Text);
            if (user.access_token != null && user.message == null)
            {
                Program.currentUser = user;
                //Close();
                var taskView = new TaskListView();
                taskView.Show();
            }
            else
            {
                errorLabel.Text = user.message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                User user = ToDoAPI.Register(usernameInput.Text, passwordInput.Text);
            } catch(Exception errors)
            {
                label3.Text = errors.Message;
                Console.WriteLine(errors.Message);
            }
        }
    }
}
