using System.Data;
using System.Numerics;

namespace SolestrideAPI.Model
{
    public class Requisicao
    {
        public int Id { get; set; }
        public string CodRequisicao { get; set; }
        public int Quantidade { get; set;}
        public Double TetoAutomatico { get; set; }
        public DateTime Data { get; set; }
        public Produto Produto { get; set; }

        public List<Requisicao> requisicaoesList()
        {
            List<Requisicao> requisicoes = new List<Requisicao>();
            List<Produto> produtos = new Produto().produtosList();

            Requisicao requisicao1 = new Requisicao();
            requisicao1.Id = 1;
            requisicao1.CodRequisicao = "WX2dsP";
            requisicao1.Quantidade = 3;
            requisicao1.TetoAutomatico = 3.99;
            requisicao1.Data = DateTime.Parse("06/04/2024");
            requisicao1.Produto = produtos[0];

            Requisicao requisicao2 = new Requisicao();
            requisicao2.Id = 2;
            requisicao2.CodRequisicao = "VASds8";
            requisicao2.Quantidade = 7;
            requisicao2.TetoAutomatico = 8.99;
            requisicao2.Data = DateTime.Parse("09/04/2024");
            requisicao2.Produto = produtos[1];

            Requisicao requisicao3 = new Requisicao();
            requisicao3.Id = 3;
            requisicao3.CodRequisicao = "BRAds7";
            requisicao3.Quantidade = 2;
            requisicao3.TetoAutomatico = 11.99;
            requisicao3.Data = DateTime.Parse("10/04/2024");
            requisicao3.Produto = produtos[2];

            requisicoes.Add(requisicao1);
            requisicoes.Add(requisicao2);
            requisicoes.Add(requisicao3);

            return requisicoes;
        }
    }
}
