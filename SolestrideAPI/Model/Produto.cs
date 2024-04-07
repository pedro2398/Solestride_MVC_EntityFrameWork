namespace SolestrideAPI.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodProduto { get; set; }
        public string Descricao { get; set; }
        public string Modelo { get; set; }
        public Fabricante Fabricante { get; set; }
        public List<Fornecedor> Fornecedores { get; set; }

        public List<Produto> produtosList() 
        {
            List<Produto> produtos = new List<Produto>();
            List<Fabricante> fabricantes = new Fabricante().fabricantesList();
            List<Fornecedor> fornecedores = new Fornecedor().fornecedoresList();

            Produto produto1 = new Produto();
            produto1.Id = 1;
            produto1.Nome = "Caneta";
            produto1.CodProduto = "cde4xei3";
            produto1.Descricao = "Caneta Preta";
            produto1.Modelo = "Esferográfica";
            produto1.Fabricante = fabricantes[1];
            produto1.Fornecedores = fornecedores;

            Produto produto2 = new Produto();
            produto2.Id = 2;
            produto2.Nome = "Lápis";
            produto2.CodProduto = "fdj5xwi3";
            produto2.Descricao = "Lápis Preto";
            produto2.Modelo = "Grafite";
            produto2.Fabricante = fabricantes[0];
            produto2.Fornecedores = fornecedores;

            Produto produto3 = new Produto();
            produto3.Id = 3;
            produto3.Nome = "Solestride IPO";
            produto3.CodProduto = "sol4est3";
            produto3.Descricao = "Ação Solestride";
            produto3.Modelo = "Ação";
            produto3.Fabricante = fabricantes[2];
            produto3.Fornecedores = fornecedores;

            produtos.Add(produto1);
            produtos.Add(produto2); 
            produtos.Add(produto3);

            return produtos;
        }
    }
}
