using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using TaskManageH.Aplicacao_.DTO;
using TaskManageH.Aplicacao_.Interface;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Enum;
using WebAPI.Token;
using WebService.Token;

namespace TaskManageH.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioControle : ControllerBase
    {
        private readonly IAplicacaoUsuario _aplicacaoUsuario;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioControle(IAplicacaoUsuario aplicacaoUsuario,
                               UserManager<Usuario> userManager,
                               SignInManager<Usuario> signInManager)
        {
            _aplicacaoUsuario = aplicacaoUsuario;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/tarefas/TokenKey")]
        public async Task<IActionResult> CriarTokenIdentity([FromBody] LoginDTO loginDTO)
        {
            if (string.IsNullOrWhiteSpace(loginDTO.email) || string.IsNullOrWhiteSpace(loginDTO.senha))
                return Unauthorized();

            var resultado = await
                _signInManager.PasswordSignInAsync(loginDTO.email, loginDTO.senha, false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                var token = new TokenJWTBuilder()
                     .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                 .AddSubject("Empresa - Canal Dev Net Core")
                 .AddIssuer("Teste.Securiry.Bearer")
                 .AddAudience("Teste.Securiry.Bearer")
                 .AddClaim("UsuarioAPINumero", "1")
                 .AddExpiry(5)
                 .Builder();

                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/tarefas/AdicionaUsuarioIdentity")]
        public async Task<IActionResult> AdicionaUsuarioIdentity([FromBody] LoginDTO loginDTO)
        {
            if (string.IsNullOrWhiteSpace(loginDTO.email) || string.IsNullOrWhiteSpace(loginDTO.senha))
                return Ok("Falta alguns dados");

            var usuario = new Usuario
            {
                UserName = loginDTO.email,
                Email = loginDTO.email,
                Celular = loginDTO.celular,
                Tipo = TipoUsuario.Colaborador
            };
            var resultado = await _userManager.CreateAsync(usuario, loginDTO.senha);

            if (resultado.Errors.Any())
            {
                return Ok(resultado.Errors);
            }

            // Geração de Confirmação caso precise
            var userId = await _userManager.GetUserIdAsync(usuario);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // retorno email 
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultado2 = await _userManager.ConfirmEmailAsync(usuario, code);

            if (resultado2.Succeeded)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return Ok("Erro ao confirmar usuários");

        }


    }
}
