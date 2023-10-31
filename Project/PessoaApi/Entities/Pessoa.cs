using System;
namespace PessoaApi.Entities
{
	public class Pessoa
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Idade { get; set; }
				

		public List<Pessoa> CriarPessoas()
		{
			var names = new string[] { "Bianor", "Ricardo", "Joao" };

            List<Pessoa> pessoaList = new List<Pessoa>();


            for (int i = 1; i <= names.Length; i++)
			{
                pessoaList.Add(new Pessoa() {
                    Id = i,
                    Nome = names[i-1],
                    Idade = Random.Shared.Next(20, 60)
                });
            }

            return pessoaList;
		}
	}
}

