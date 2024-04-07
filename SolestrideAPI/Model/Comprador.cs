namespace SolestrideAPI.Model
{
    public class Comprador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ModTributario { get; set; }
        public string Tipo { get; set; }

        public List<Comprador> compradoresList()
        {
            List<Comprador> compradores = new List<Comprador>();

            Comprador comprador1 = new Comprador();
            comprador1.Id = 1;
            comprador1.Nome = "AmazingTI";
            comprador1.Cnpj = "1234567890/10-12";
            comprador1.Email = "amazingTi@gmail.com";
            comprador1.Senha = "1234";
            comprador1.ModTributario = "modeloTributario";
            comprador1.Tipo = "COMPRADOR";

            Comprador comprador2 = new Comprador();
            comprador2.Id = 2;
            comprador2.Nome = "Fiap";
            comprador2.Cnpj = "1234567890/11-30";
            comprador2.Email = "fiap@gmail.com";
            comprador2.Senha = "5678";
            comprador2.ModTributario = "modeloTributario";
            comprador2.Tipo = "COMPRADOR";

            Comprador comprador3 = new Comprador();
            comprador3.Id = 3;
            comprador3.Nome = "Munera";
            comprador3.Cnpj = "1234567890/33-09";
            comprador3.Email = "munera@gmail.com";
            comprador3.Senha = "9101";
            comprador3.ModTributario = "modeloTributario";
            comprador3.Tipo = "COMPRADOR";

            compradores.Add(comprador1);
            compradores.Add(comprador2);
            compradores.Add(comprador3);

            return compradores;
        }
    }
}
