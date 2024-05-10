using Inc.MyRegister.Domain.Entities;

namespace Inc.MyRegister.Application.DTOs
{
    public class SetorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool FL_Status { get; set; }
        public Setores ToEntity()
        {
            return new Setores(Nome, FL_Status);
        }
    }
}
