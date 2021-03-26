using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using WinFormsApp1ToDo.DTO;

namespace WinFormsApp1ToDo.ViewModels
{
    class TaskViewModel
    {
        private Task task;
        public TaskControl taskControl;
        public TaskViewModel(Task task)
        {
            this.task = task;
            taskControl = new TaskControl();
            taskControl.titleTBox.Text = task.title;
            taskControl.descTBox.Text = task.desc;
            taskControl.editBtn.Click += new EventHandler(Save);
            taskControl.deleteBtn.Click += new EventHandler(Delete);
        }

        private void Delete(object sender, EventArgs e)
        {
            ToDoAPI.DeleteTask(task);
            OnTaskDelete(this);
        }

        private void Save(object sender, EventArgs e)
        {
            task.title = taskControl.titleTBox.Text;
            task.desc = taskControl.descTBox.Text;
            try {
                task = ToDoAPI.SaveTask(task);
                taskControl.messageLbl.Text = "Salvestamine õnnestus";
                taskControl.messageLbl.ForeColor = Color.Green;
                //OnItemChange(new EventArgs());
            }
            catch(Exception error)
            {
                taskControl.messageLbl.Text = "Ebaõnnestus: " + error.Message;
                taskControl.messageLbl.ForeColor = Color.Red;
            }
            
        }

        public event EventHandler<TaskViewModel> TaskDelete;
        protected virtual void OnTaskDelete(TaskViewModel deletedTask)
        {
            EventHandler<TaskViewModel> handler = TaskDelete;
            handler?.Invoke(this, deletedTask);
        }
    }
}
