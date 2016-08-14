using System;
using SalesForceWeb.Domain.ValuesObject;
using SalesForceWeb.Helper;

namespace SalesForceWeb.Domain.Entities
{
    public  class Usuario:Base.EntidadeBase
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Sexo { get; set; }
        public string Idade { get; set; }
        public Email Email { get; set; }
        public string Login { get; set; }
      
        public string Senha  { get; private set; }
        public string Hora { get; set; }
        public string TokenAlteracaoDeSenha { get; private set; }

        protected Usuario() { }

        
        public Usuario(string nome,string email,string login) {
            SetLogin(login);
            Email.SetEmail(email);
            SetNome(nome);
            Hora = DateTime.Now.ToShortTimeString();
        }

        public void SetNome(string nome)
        {
            Validador.ForNullOrEmptyDefaultMessage(nome,"Nome");
            Nome = nome;
        }

        public void SetLogin(string login)
        {
            Validador.ForNullOrEmptyDefaultMessage(login, "Login");
            Login = login;
        }

        
        public void SetSenha(string senha, string senhaConfirmacao)
        {
         
            Senha = CriptografiaHelper.CriptografarSenha(senha);
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmacaoDeSenha)
        {
            ValidarSenha(senhaAtual);
            SetSenha(novaSenha, confirmacaoDeSenha);
        }

        public void ValidarSenha(string senha)
        {
         
        }

        public string GerarNovoTokenAlterarSenha()
        {
            var TokenAlteracaoDeSenha = Guid.NewGuid();
            return TokenAlteracaoDeSenha.ToString();
        }

        public void AlterarSenha(Guid token, string novaSenha, string confirmacaoDeSenha)
        {
            if (!TokenAlteracaoDeSenha.Equals(token))
                throw new Exception("token para alteração de senha inválido!");
            SetSenha(novaSenha, confirmacaoDeSenha);
            GerarNovoTokenAlterarSenha();
        }

    }
}
