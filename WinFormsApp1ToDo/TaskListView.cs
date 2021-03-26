using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1ToDo.ViewModels;

namespace WinFormsApp1ToDo
{
    public partial class TaskListView : Form
    {
        

        public TaskListView()
        {
            InitializeComponent();
        }

        private void TaskListView_Load(object sender, EventArgs e)
        {
            ReLoad();
        }


        private void TaskListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var taskView = new TaskViewModel(new DTO.Task(), this);
            flowLayoutPanel1.Controls.Add(taskView.taskControl);
        }

        public void ReLoad()
        {
            flowLayoutPanel1.Controls.Clear();
            var tasks = ToDoAPI.GetTasks();
            foreach (var task in tasks)
            {
                var taskView = new TaskViewModel(task, this);
                flowLayoutPanel1.Controls.Add(taskView.taskControl);
            }
        }
    }
}
