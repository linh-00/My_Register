namespace Inc.MyRegister.Domain.Entities
{
    public class RegistroPontos : BaseEntities
    {
        public DateTime DT_PONTO { get; private set; }
        public string TP_Ponto { get; private set; }
        public Funcionarios Funcionarios { get; private set; }
        public Empresas Empresas { get; private set; }

        public RegistroPontos(int id
            , DateTime DT_Ponto
            , string TP_Ponto
            , Funcionarios funcionarios
            , Empresas empresas

            ) : base(id)
        {
            this.DT_PONTO = DT_Ponto;
            this.TP_Ponto = TP_Ponto;
            Funcionarios = funcionarios;
            Empresas = empresas;
        }
        public RegistroPontos(
            DateTime DT_Ponto
           , string TP_Ponto
           ) : base()
        {
            this.DT_PONTO = DT_Ponto;
            this.TP_Ponto = TP_Ponto;
        }
    }
}
