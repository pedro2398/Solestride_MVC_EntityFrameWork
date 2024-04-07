namespace SolestrideAPI.Model
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ModTributario { get; set; }
        public string Tipo { get; set; }

        public List<Fabricante> fabricantesList()
        {
            List<Fabricante> fabricantes = new List<Fabricante>();

            Fabricante fabricante1 = new Fabricante();
            fabricante1.Id = 1;
            fabricante1.Nome = "FaberCastell";
            fabricante1.Cnpj = "1234567890/10-12";
            fabricante1.Email = "faber_castel@gmail.com";
            fabricante1.Senha = "1234";
            fabricante1.ModTributario = "modeloTributario";
            fabricante1.Tipo = "FABRICANTE";

            Fabricante fabricante2 = new Fabricante();
            fabricante2.Id = 2;
            fabricante2.Nome = "BIC";
            fabricante2.Cnpj = "1234567890/11-30";
            fabricante2.Email = "bic@gmail.com";
            fabricante2.Senha = "5678";
            fabricante2.ModTributario = "modeloTributario";
            fabricante2.Tipo = "FABRICANTE";

            Fabricante fabricante3 = new Fabricante();
            fabricante3.Id = 3;
            fabricante3.Nome = "Munera";
            fabricante3.Cnpj = "1234567890/33-09";
            fabricante3.Email = "munera@gmail.com";
            fabricante3.Senha = "9101";
            fabricante3.ModTributario = "modeloTributario";
            fabricante3.Tipo = "COMPRADOR";

            fabricantes.Add(fabricante1);
            fabricantes.Add(fabricante2);
            fabricantes.Add(fabricante3);

            return fabricantes;
        }
    }
}
