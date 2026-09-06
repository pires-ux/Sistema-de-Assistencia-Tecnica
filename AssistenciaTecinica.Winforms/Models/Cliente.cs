using System;

namespace ex04
{
    public class Cliente
    {

        public Cliente()
        {

        }
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }

        

        public Cliente(int Id, string Nome, string Telefone, string Email, string Endereco)
        {
            id = Id;
            nome = Nome;
            telefone = Telefone;
            email = Email;
            endereco = Endereco;
        }

        public override string ToString()
        {
            return $"Id: {id}, Nome: {nome}, Telefone: {telefone}, Email: {email}, Endereco: {endereco}";
        }
    }
}
