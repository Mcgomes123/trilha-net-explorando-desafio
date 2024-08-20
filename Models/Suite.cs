namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Id = id;
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public int Id { get; set; }
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public string GerarDescricaoSuite()
        {
            return &@"Suite nº{Id}: {TipoSuite}
            Valor da Diaria: {ValorDiaria:C}
            Capaciade: {capaciades}";
        }
        public static Suite CadastrarSuite()
        {
            int id;
            string tipoSuite;
            int capacidade;
            decimal valorDiaria;

            Console.Write("Digitar o ID da suite: ");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID invalido. Por favor, digite um numero inteiro positivo.");
                Console.Write("Digite ID da suite:");
            }

            Console.Write("Digite o tipo da suite:");
            tipoSuite = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(tipoSuite))
            {
                Console.WriteLine("Tipo da suite nao pode ser vazio.");
                Console.Write("Digite o tipo da suite: ");
                tipoSuite = Console.ReadLine();
            }

            Console.Write("Digite a capacidade da suite: ");
            while (!int.TryParse(Console.ReadLine(), out capacidade) || capacidade <= 0)
            {
                Console.WriteLine("Capacidade invalida. Por favor, digite um numero inteiro positivo.");
                Console.Write("Digite a capacidade da suite: ");
            }

            Console.Write("Digite o valor da diaria: ");
            while (!decimal.TryParse(Console.ReadLine(), out valorDiaria) || valorDiaria <= 0)
            {
                Console.WriteLine("Valor invalido. Por favor, digite um numero decimal positivo.");
                Console.Write("Digite o valor da diaria");
            }
            return new Suite(id, tipoSuite, capacidade, valorDiaria);
        }
    
    }    
        
}