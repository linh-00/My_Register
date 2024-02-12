using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Entities
{
    public class Empresas : BaseEntities
    {
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public string Dominio {  get; private set; }
        public string Contato { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }

    public Empresas(int id
        ,string nome
        , string CNPJ
        , string dominio
        , string contato
        , string email
        , string endereco
        ) : base(id)
        { 
            Nome = nome;
            this.CNPJ = CNPJ;
            Dominio = dominio;
            Contato = contato;
            Email = email;
        }
        public Empresas(
         string nome
        , string CNPJ
        , string dominio
        , string contato
        , string email
        , string endereco
        ) : base()
        {
            Nome = nome;
            this.CNPJ = CNPJ;
            Dominio = dominio;
            Contato = contato;
            Email = email;
        }
    }
}
