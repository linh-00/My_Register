namespace Inc.MyRegister.Domain.Entities
{
    public class RegistroPontos : BaseEntities
    {
        public string DT_Ponto { get; private set; }
        public string TP_Ponto { get; private set; }
        public Funcionarios Funcionarios { get; private set; }

        public RegistroPontos(int id
            , string DT_Ponto
            , string TP_Ponto
            , Funcionarios funcionarios
            ) : base(id)
        {
            this.DT_Ponto = DT_Ponto;
            this.TP_Ponto = TP_Ponto;
            Funcionarios = funcionarios;
        }
        public RegistroPontos(
            string DT_Ponto
           , string TP_Ponto
           ) : base()
        {
            this.DT_Ponto = DT_Ponto;
            this.TP_Ponto = TP_Ponto;
        }
    }
}
