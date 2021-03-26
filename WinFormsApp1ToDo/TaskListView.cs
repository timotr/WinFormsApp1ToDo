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
            var taskView = new TaskViewModel(new DTO.Task());
            taskView.TaskDelete += new EventHandler(OnTaskDelete);
            flowLayoutPanel1.Controls.Add(taskView.taskControl);
        }

        private void OnTaskDelete(object sender, EventArgs e)
        {
            ReLoad();
        }

        public void ReLoad()
        {
            //var oldScrollPosition = flowLayoutPanel1.   scroll position
            var tasks = ToDoAPI.GetTasks();
            flowLayoutPanel1.Controls.Clear();
            foreach (var task in tasks)
            {
                var taskView = new TaskViewModel(task);
                taskView.TaskDelete += new EventHandler(OnTaskDelete);
                flowLayoutPanel1.Controls.Add(taskView.taskControl);
            }
            // flowLayoutPanel1. scroll Position = oldScrollPosition
        }
    }
}
