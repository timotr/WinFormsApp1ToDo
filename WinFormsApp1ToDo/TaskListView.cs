using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1ToDo.DTO;
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
            var tasks = ToDoAPI.GetTasks();
            foreach (var task in tasks)
            {
                var taskView = new TaskViewModel(task);
                taskView.TaskDelete += OnTaskDelete;
                flowLayoutPanel1.Controls.Add(taskView.taskControl);
            }
        }


        private void TaskListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var taskView = new TaskViewModel(new DTO.Task());
            taskView.TaskDelete += OnTaskDelete;
            flowLayoutPanel1.Controls.Add(taskView.taskControl);
        }

        private void OnTaskDelete(object sender, TaskViewModel deletedTask)
        {
            flowLayoutPanel1.Controls.Remove(deletedTask.taskControl);
        }

        public void ReLoad()
        {
            var oldScrollPosition = flowLayoutPanel1.VerticalScroll.Value;

            var tasks = ToDoAPI.GetTasks();
            flowLayoutPanel1.Controls.Clear();
            foreach (var task in tasks)
            {
                var taskView = new TaskViewModel(task);
                taskView.TaskDelete += OnTaskDelete;
                flowLayoutPanel1.Controls.Add(taskView.taskControl);
            }

            flowLayoutPanel1.VerticalScroll.Value = oldScrollPosition;
        }
    }
}
