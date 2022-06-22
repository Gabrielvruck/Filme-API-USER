using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signManager, TokenService tokenService)
        {
            _signManager = signManager;
            _tokenService = tokenService;
        }
        private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
        {
            return _signManager.UserManager.Users
                 .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        public Result LogaUsuario(LoginRequest request)
        {

            var resultadoIdentity = _signManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.UserName.ToUpper());

                Token token = _tokenService.CreateToken(identityUser,
                    _signManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);
            if (identityUser != null)
            {
                string codigoDeRecuperacao = _signManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }
            return Result.Fail("Falha ao solicitar redefinição");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            //recupera o usuario 
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            //redefine a senha
            IdentityResult resultadodoIdentity = _signManager.UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (resultadodoIdentity.Succeeded)
            {
                return Result.Ok().WithSuccess("Senha redefinida com sucesso");
            }
            return Result.Fail("Houve um erro na operação");
        }
    }
}
