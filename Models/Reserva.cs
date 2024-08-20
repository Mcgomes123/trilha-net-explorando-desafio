using DesafioProjetoHospedagem.Exception;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public List<Pessoa> CadastrarHospedes(List<Pessoa> hospedes)
        {
            Console.Write("Quantos hospedes para esssa reserva: ");
            try
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (!int.TryParse(quantidadeHospedes, out int i))
            {
                Console.WriteLine("Qauntidade invalida");
                return null;
            }
            hospedes = MenuInformacoesCadastrais(Hospedes,i);

            if (Suite.Capacidade >= hospedes.Count)            
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new CapacidadeInvalidaException("Capacidade da suite deve ser menor ou igual ao nuero de hospedes!");
            }

            catch (ArgumentOutOfRangeException)
            {
                throw new CapacidadeInvalidaException("Argumento Invalido!");
            }
            return hospedes;
        }

        public int CadastrarSuite(Suite suite)
        {
            Suite = suite;
            return suite.Id;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes.Any() ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = 0;

            valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor *= 0.9M;
            }

            return valor;
        }
        public static List<Pessoa> MenuInformacoesCadastrais(List<Pessoa> hospedes, int quantidadeHospedes)
        {
            int contador;
            Console.WriteLine("\n--------Cadastro de Hospede--------\n");
            for (contador = 1; contador <= quantidadeHospedes; contador++)
            {
                Console.WriteLine($"{contador}º Hospede");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Sobrenome: ");
                string sobrenome = Console.ReadLine();

                Pessoa hospede = Pessoa.CriarPessoa(nome, sobrenome);
                hospedes.Add(hospede);

                Console.WriteLine();
            }
            return hospedes;            
        }
        public static Reserva CriarReserva(int diasReservados)
        {
            return new Reserva(diasReservados);
        }

        public string GerarComprovanteReserva()
        {
            string hospedesInfo = Hospedes != null && Hospedes.Count > 0
                ? string.Join("\n". PadRight(19), hospedes.ConvertAll(h => h.NomeCompletoFormatado()))
                : "Nenhum hospede registrado";
            string suiteInfo = Suite != null
                ? Suite.GerarDescricaoSuite()
                :"Nenhum suite selecionada";

            return $@
        ------Descrição da Reserva-----
        -------------------------------
         Hospedes: {hospedesInfo}
         {suiteInfo}
         Dias Reservados : {DiasReservados} 
         Valor Total: {CalcularValorDiaria():C};     
        }
        

        
    }
}