using Inc.MyRegister.Domain.Entities;

namespace Inc.MyRegister.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Usuarios ToEntity()
        {
            return new Usuarios(Nome, Cargo, Email, Senha);
        }
    }
}
