﻿using Common.DateTimeProvider;
using Common.JwtTokenGenerator;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Core.Authentication;

public class JwtTokenGenerator(IOptions<JwtSettings> jwtSettings) : IJwtTokenGenerator
{
    string IJwtTokenGenerator.GenerateToken(long userId, string firstName, string lastName)
    {
        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        Claim[] claims =
        [
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

        ];

        JwtSecurityToken securityToken = new(
            issuer: jwtSettings.Value.Issuer,
            audience: jwtSettings.Value.Audience,
            expires: DateTimeProvider.ApplicationDate.AddMinutes(jwtSettings.Value.ExpiryMinutes),
            claims: claims, signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
