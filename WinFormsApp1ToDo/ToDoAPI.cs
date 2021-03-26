using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1ToDo.DTO;

namespace WinFormsApp1ToDo
{
    class ToDoAPI
    {
        public static RestClient client = new RestClient("http://demo2.z-bit.ee");

        public static List<Task> GetTasks()
        {
            if (Program.currentUser == null)
                throw new Exception("Not logged in");

            var request = new RestRequest("/tasks", Method.GET);
            request.AddHeader("Authorization", "Bearer "+ Program.currentUser.access_token);
            var response = client.Execute<List<Task>>(request);
            return response.Data;
        }

        internal static Task SaveTask(Task task)
        {
            if (Program.currentUser == null)
                throw new Exception("Not logged in");

            RestRequest request;
            if (task.id == null) { 
                request = new RestRequest("/tasks", Method.POST);
            }
            else
            {
                request = new RestRequest("/tasks/"+task.id, Method.PUT);
            }

            request.AddHeader("Authorization", "Bearer " + Program.currentUser.access_token);
            request.AddJsonBody(task);
            var response = ToDoAPI.client.Execute<Task>(request);
            
            if (response.Data == null)
            {
                var deserial = new JsonDeserializer();
                dynamic errors = deserial.Deserialize<dynamic>(response);
                string errorMessages = "";
                foreach (var error in errors)
                {
                    errorMessages += error["message"] + "\n";
                }
                throw new Exception("Salvestamisel tekkis viga: " + errorMessages);
            }

            return response.Data;
        }

        internal static void DeleteTask(Task task)
        {
            if (Program.currentUser == null)
                throw new Exception("Not logged in");

            RestRequest request = new RestRequest("/tasks/"+task.id, Method.DELETE);

            request.AddHeader("Authorization", "Bearer " + Program.currentUser.access_token);
            ToDoAPI.client.Execute(request);
        }

        public static Task GetTask(int id)
        {
            if (Program.currentUser == null)
                throw new Exception("Not logged in");

            var request = new RestRequest("/tasks/"+id, Method.GET);
            request.AddHeader("Authorization", "Bearer " + Program.currentUser.access_token);
            var response = client.Execute<Task>(request);
            return response.Data;
        }

        public static User Login(string user, string pw)
        {
            var request = new RestRequest("/users/get-token", Method.POST);
            request.AddJsonBody(new { username = user, password = pw });
            var response = ToDoAPI.client.Execute<User>(request);
            return response.Data;
        }

        public static User Register(string user, string pw)
        {
            var request = new RestRequest("/users", Method.POST);
            request.AddJsonBody(new { username = user, newPassword = pw });
            var response = ToDoAPI.client.Execute<User>(request);

            if (response.Data == null)
            {
                var deserial = new JsonDeserializer();
                dynamic errors = deserial.Deserialize<dynamic>(response);
                if (errors is List<object>) {
                    string errorMessages = "";
                    foreach (var error in errors)
                    {
                        errorMessages += error["message"] + "\n";
                    }
                    throw new Exception("Salvestamisel tekkis viga: " + errorMessages);
                } else
                {
                    throw new Exception("Salvestamisel tekkis viga: " + errors["message"]);
                }
            }

            return response.Data;
        }
    }
}
