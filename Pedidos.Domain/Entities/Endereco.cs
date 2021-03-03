
namespace Pedidos.Domain
{
    public class Endereco : BaseDomain
    {
        public tipoEnum tipo { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public int cidadeid { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
