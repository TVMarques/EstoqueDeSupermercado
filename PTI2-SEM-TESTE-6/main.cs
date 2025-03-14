using System;

namespace TAD {
    class Program {
        static void Main(string[]args){
            Estoque estoque = new Estoque(10);

            do {
                Console.WriteLine("CONTROLE DE ESTOQUE - SUPERMERCADO");
                Console.WriteLine("[1] Novo Produto       [4]Entrada de Estoque" );
                Console.WriteLine("[2] Listar Produtos    [5]Saída de Estoque");
                Console.WriteLine("[3] Remover Produto    [0] Sair ");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao){
                    case "1":
                        AdicionarProduto(estoque);
                        break;
                    case "2":
                       ListarProdutos(estoque);
                        break;
                    case "3":
                        RemoverProduto(estoque);
                        break;
                    case "4" :
                        RealizarEntradadeEstoque(estoque);
                        break;
                    case "5":
                       RealizarSaidaEstoque(estoque);
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (true);
        }
        private static void AdicionarProduto(Estoque estoque){
            Console.WriteLine("Informe os dados do produto.");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: ");
            decimal preco;
            while (!decimal.TryParse(Console.ReadLine(), out preco) || preco < 0) {
                Console.Write("Preço inválido. Informe um valor válido: ");
            }

            Console.Write("Quantidade inicial de Estoque: ");
            int quantidadeEmEstoque;
            while (!int.TryParse(Console.ReadLine(), out quantidadeEmEstoque) || quantidadeEmEstoque < 0)
            {
                Console.Write("Quantidade inválida. Informe um valor válido: ");
            }

          Console.Write("Fabricante: ");
          string fabricante = Console.ReadLine();
      
            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            Console.Write("Data de Fabricação (dd/mm/yyyy): ");
            DateTime dataFabricacao;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataFabricacao))
            {
                Console.Write("Data inválida. Informe uma data válida (dd/mm/yyyy): ");
            }

            Produto novoProduto = new Produto {
                Nome = nome,
                Preco = preco,
                QuantidadeEmEstoque = quantidadeEmEstoque,
                Fabricante = fabricante,
                Categoria = categoria,
                DataFabricacao = dataFabricacao
            };
            if (estoque.AdicionarProduto(novoProduto)){
                Console.WriteLine("Produto adicionado com sucesso!");
            }
            else{
                Console.WriteLine("Não foi possível adicionar o produto. Estoque cheio.");
            }
        }
        private static void ListarProdutos(Estoque estoque) {
            Console.WriteLine("\nLista de Produtos:");
 bool encontrouProdutos = false;

    foreach (var produto in estoque.Produtos) {
        if (produto != null) {
            Console.WriteLine(produto);
            Console.WriteLine();
            encontrouProdutos = true;
        }
    }
    if (!encontrouProdutos) {
        Console.WriteLine("Não há produtos em estoque.");
    }
}
       private static void RealizarEntradadeEstoque(Estoque estoque){
         Console.Write("Digite o nome do produto para entrada de estoque: ");
         string nome = Console.ReadLine();

         Console.Write("Quantidade de entrada: ");
          int quantidadeEntrada;
    while (!int.TryParse(Console.ReadLine(), out quantidadeEntrada) || quantidadeEntrada < 0) {
        Console.Write("Quantidade inválida. Informe um valor válido: ");
      }

    if (estoque.RegistrarEntradadeEstoque(nome, quantidadeEntrada)) {
        Console.WriteLine($"Entrada de {quantidadeEntrada} unidades de '{nome}' realizada com sucesso.");
    }
    else{
        Console.WriteLine($"Produto '{nome}' não encontrado no estoque.");
    }
}
      
     private static void RealizarSaidaEstoque(Estoque estoque){
        Console.Write("Digite o nome do produto para saída de estoque: ");
        string nome = Console.ReadLine();

Console.Write("Quantidade de saída: ");
          int quantidadeSaida;
    while (!int.TryParse(Console.ReadLine(), out quantidadeSaida) || quantidadeSaida < 0) {
        Console.Write("Quantidade inválida. Informe um valor válido: ");
       }

    if (estoque.RegistrarSaidadeEstoque(nome, quantidadeSaida)){
        Console.WriteLine($"Saída de {quantidadeSaida} unidades de '{nome}' realizada com sucesso.");
      }
    else {
        Console.WriteLine($"Produto '{nome}' não encontrado no estoque ou quantidade insuficiente.");
    }
  }


        private static void RemoverProduto(Estoque estoque){
            Console.Write("Digite o nome do produto que deseja remover: ");
            string nome = Console.ReadLine();

            if (estoque.RemoverProduto(nome)) {
                Console.WriteLine($"Produto '{nome}' removido com sucesso.");
            }
            else{
                Console.WriteLine($"Produto '{nome}' não encontrado no estoque.");
            }
        }
    }
}
