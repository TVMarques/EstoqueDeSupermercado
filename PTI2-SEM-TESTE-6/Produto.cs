using System;

namespace TAD
{
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string Fabricante { get; set; }
        public string Categoria { get; set; }
        public DateTime DataFabricacao { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome}\nPreço: {Preco:C2}\nQuantidade em Estoque: {QuantidadeEmEstoque}\nFabricante: {Fabricante}\nCategoria: {Categoria}\nData de Fabricação: {DataFabricacao:d}";
        }
    }
}
