using Models;
using Newtonsoft.Json;
using QuickType;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirAPI
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient() {BaseAddress = new Uri("https://localhost:44337/") };
            var response = await client.GetAsync("Person/2077");
            var content = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(content);
            Console.WriteLine("================");

            //var data = JsonConvert.DeserializeObject<Dictionary<U, object>
            //var users = JsonConvert.DeserializeObject<User[]>(content);
            var user = JsonConvert.DeserializeObject<User>(content);

            //foreach (var user in users)
            //{
            //    Console.WriteLine("Nome do usuario: "+user.nome+"CPF: "+user.cpf);
            //    Console.WriteLine("====");
            //}

            //Console.WriteLine(user.nome);

            UserPost userPost = new UserPost();

            userPost.Cpf = user.cpf;
            userPost.Gender = user.sexo;
            userPost.Name = user.nome;
            userPost.BirthDate = user.dataNascimento;


            Console.WriteLine(userPost.Name);

            var userSerialized = JsonConvert.SerializeObject(userPost);
            var payload = new StringContent(userSerialized, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(client.BaseAddress + "Person/create", payload).Result.Content.ReadAsStringAsync();

        }
    }
}

