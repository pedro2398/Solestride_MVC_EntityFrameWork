namespace SolestrideAPI.Model
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ModTributario { get; set; }
        public string Tipo { get; set; }

        public List<Fornecedor> fornecedoresList()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            Fornecedor fornecedor1 = new Fornecedor();
            fornecedor1.Id = 1;
            fornecedor1.Nome = "SamuelDistribuidora";
            fornecedor1.Cnpj = "1234567890/10-12";
            fornecedor1.Email = "samuel_distribuidora@gmail.com";
            fornecedor1.Senha = "1234";
            fornecedor1.ModTributario = "modeloTributario";
            fornecedor1.Tipo = "FORNECEDOR";

            Fornecedor fornecedor2 = new Fornecedor();
            fornecedor2.Id = 2;
            fornecedor2.Nome = "GabrielDistribuidora";
            fornecedor2.Cnpj = "1234567890/10-12";
            fornecedor2.Email = "gabriel_distribuidora@gmail.com";
            fornecedor2.Senha = "1234";
            fornecedor2.ModTributario = "modeloTributario";
            fornecedor2.Tipo = "FORNECEDOR";

            Fornecedor fornecedor3 = new Fornecedor();
            fornecedor3.Id = 3;
            fornecedor3.Nome = "AnaDistribuidora";
            fornecedor3.Cnpj = "1234567890/10-12";
            fornecedor3.Email = "ana_distribuidora@gmail.com";
            fornecedor3.Senha = "1234";
            fornecedor3.ModTributario = "modeloTributario";
            fornecedor3.Tipo = "FORNECEDOR";

            fornecedores.Add(fornecedor1);
            fornecedores.Add(fornecedor2);
            fornecedores.Add(fornecedor3);

            return fornecedores;
        }
    }
}
