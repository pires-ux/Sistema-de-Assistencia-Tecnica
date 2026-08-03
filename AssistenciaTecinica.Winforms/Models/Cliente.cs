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
        public string cpf { get; set; }
        public string endereco { get; set; }

        

        public Cliente(int Id, string Nome, string Telefone, string Cpf, string Endereco)
        {
            id = Id;
            nome = Nome;
            telefone = Telefone;
            cpf = Cpf;
            endereco = Endereco;
        }

        public override string ToString()
        {
            return $"Id: {id}, Nome: {nome}, Telefone: {telefone}, Cpf: {cpf}, Endereco: {endereco}";
        }
    }
}
