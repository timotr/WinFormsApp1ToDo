using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using WinFormsApp1ToDo.DTO;

namespace WinFormsApp1ToDo.ViewModels
{
    class TaskViewModel
    {
        public event EventHandler TaskChanged;
        protected virtual void OnItemChange(EventArgs e)
        {
            EventHandler handler = TaskChanged;
            handler?.Invoke(this, e);
        }

        private Task task;
        private TaskListView taskListView;
        public TaskControl taskControl;
        public TaskViewModel(Task task, TaskListView taskListView)
        {
            this.task = task;
            this.taskListView = taskListView;
            taskControl = new TaskControl();
            taskControl.titleTBox.Text = task.title;
            taskControl.descTBox.Text = task.desc;
            taskControl.editBtn.Click += new EventHandler(Save);
            taskControl.deleteBtn.Click += new EventHandler(Delete);
        }

        private void Delete(object sender, EventArgs e)
        {
            ToDoAPI.DeleteTask(task);
            taskListView.ReLoad();
        }

        private void Save(object sender, EventArgs e)
        {
            task.title = taskControl.titleTBox.Text;
            task.desc = taskControl.descTBox.Text;
            try {
                task = ToDoAPI.SaveTask(task);
                taskControl.messageLbl.Text = "Salvestamine õnnestus";
                taskControl.messageLbl.ForeColor = Color.Green;
            }
            catch(Exception error)
            {
                taskControl.messageLbl.Text = "Ebaõnnestus: " + error.Message;
                taskControl.messageLbl.ForeColor = Color.Red;
            }
            
        }
    }
}
