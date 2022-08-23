using System;

namespace QuickType
{

    public class GenericResponse
    {
        public User[] data { get; set; }
        public int statusCode { get; set; }
        public object errorMessage { get; set; }
    }

    public class User
    {
        public string cpf { get; set; }
        public char sexo { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public int id { get; set; }
        public DateTime dataCriacao { get; set; }
        public object dataAtualizacao { get; set; }
        public bool deletado { get; set; }
    }

}

