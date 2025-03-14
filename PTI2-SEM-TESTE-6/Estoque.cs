using System;

namespace TAD
{
    public class Estoque {
       private Produto[] produtos;
       private int count;
        public Estoque(int capacidade){
           produtos = new Produto[capacidade];
           count = 0;
          }

        public bool AdicionarProduto(Produto produto) {
            if (count < produtos.Length) {
                produtos[count] = produto;
                count++;
                return true;
            }
            return false;
        }

        public bool RemoverProduto(string nome) {
            for (int i = 0; i < count; i++) {
                if (produtos[i].Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)){
                    for (int j = i; j < count - 1; j++){
                        produtos[j] = produtos[j + 1];
                    }
                    produtos[count - 1] = null;
                    count--;
                    return true;
                }
            }
            return false;
        }

        public Produto BuscarProduto(string nome){
            foreach (var produto in produtos) {
                if (produto != null && produto.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)){
                    return produto;
                }
            }
            return null;
        }

        public void ListarProdutos(){
            foreach (var produto in produtos)
            {
                if (produto != null) {
                    Console.WriteLine(produto);
                    Console.WriteLine();
                }
            }
        }
       public Produto[] Produtos => produtos;
      
       public bool RegistrarEntradadeEstoque(string nome, int quantidade){
        Produto produto = BuscarProduto(nome);
        if (produto != null){
            produto.QuantidadeEmEstoque += quantidade;
            return true;
        }
        return false;
    }
     public bool RegistrarSaidadeEstoque(string nome, int quantidade) {
        Produto produto = BuscarProduto(nome);
    if (produto != null && produto.QuantidadeEmEstoque >= quantidade){
            produto.QuantidadeEmEstoque -= quantidade;
            return true;
        }

        return false;
    }

   }
  }

