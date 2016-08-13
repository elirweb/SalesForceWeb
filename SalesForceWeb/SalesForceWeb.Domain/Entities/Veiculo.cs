namespace SalesForceWeb.Domain.Entities
{
    public  class Veiculo:Base.EntidadeBase
    {
        public string Nome { get; set; }
        public int CodigoModelo { get; set; }

        public virtual Modelo ModeloModel { get; set; } 
        public string Ano { get; set; }
        public string Cor { get; set; }
        public virtual Tipo TipoModel { get; set; }
        public int CodigoTipo { get; set; }

        public string Renavam { get; set; }
        public string Placa { get; set; }  
    }
}
