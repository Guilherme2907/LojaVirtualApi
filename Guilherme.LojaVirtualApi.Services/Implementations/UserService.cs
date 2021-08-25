using Guilherme.LojaVirtualApi.Models.Configurations;
using Guilherme.LojaVirtualApi.Models.DTOs;
using Guilherme.LojaVirtualApi.Models.DTOs.Requests;
using Guilherme.LojaVirtualApi.Models.Entities;
using Guilherme.LojaVirtualApi.Models.Exceptions;
using Guilherme.LojaVirtualApi.Repository.Interfaces;
using Guilherme.LojaVirtualApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        private readonly TokenConfiguration _tokenConfiguration;

        private readonly ITokenService _tokenService;
        private readonly ICryptographyService _cryptographyService;

        private readonly IUserRepository _userRepository;

        public UserService(TokenConfiguration tokenConfiguration, ITokenService tokenService, ICryptographyService cryptographyService, IUserRepository userRepository)
        {
            _tokenConfiguration = tokenConfiguration;
            _tokenService = tokenService;
            _cryptographyService = cryptographyService;
            _userRepository = userRepository;
        }

        public async Task<TokenDto> SignIn(UserDto userCredentials)
        {
            User user = await ValidateCredentialsAsync(userCredentials);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.Username)
            };

            var tokenDto = await GenerateTokenDto(claims,user);

            return tokenDto;
        }

        private async Task<TokenDto> GenerateTokenDto(IEnumerable<Claim> claims,User user)
        {
            var token = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireTime = DateTime.Now.AddDays(_tokenConfiguration.DaysToExpire);

            await _userRepository.Update(user);

            return new TokenDto(true, DateTime.Now.ToString(DATE_FORMAT), DateTime.Now.AddMinutes(_tokenConfiguration.Minutes).ToString(DATE_FORMAT), token, refreshToken);
        }

        private async Task<User> ValidateCredentialsAsync(UserDto userCredentials)
        {
            var encryptedPassword = _cryptographyService.EncryptPassword(userCredentials.Password);

            var user = await _userRepository.GetUserByCredentialsAsync(userCredentials.Username, encryptedPassword);

            if (user == null)
            {
                throw new BadRequestException("Invalid user");
            }

            return user;
        }

        public async Task<TokenDto> RefreshToken(TokenDto token)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token.AccessToken);

            var user = await _userRepository.FindByUsernameAsync(principal.Identity.Name);

            if(user == null)
            {
                throw new BadRequestException("Invalid user");
            }

            var tokenDto = await GenerateTokenDto(principal.Claims, user);

            return tokenDto;
        }
    }
}
