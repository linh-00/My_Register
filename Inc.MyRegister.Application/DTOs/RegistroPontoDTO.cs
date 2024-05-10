using Inc.MyRegister.Domain.Entities;

namespace Inc.MyRegister.Application.DTOs
{
    public class RegistroPontoDTO
    {
        public int Id { get; set; }
        public DateTime DT_PONTO { get; set; }
        public string TP_Ponto { get; set; }

        public RegistroPontos toEntity()
        {
            return new RegistroPontos(DT_PONTO, TP_Ponto);
        }
    }
}
