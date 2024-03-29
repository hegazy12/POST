﻿using ProjectEweis.Healper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestApiJWT.Models;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.AspNet.SignalR.Infrastructure;
using ProjectEweis.Hubs;
using Microsoft.AspNetCore.SignalR;
using ProjectEweis.ModelView.POSTVM;
using Mashrok.Domain;
using System.Net.Mail;
using System.Web;

using System.Net.Mail;
using System.Web;

using System.Net;

namespace ProjectEweis.Services
{


    public class LoginSystem : ILoginSystem
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly IConfiguration _configuration;


        public LoginSystem(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _configuration = configuration;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email is already registered!" };



            var user = new ApplicationUser
            {

                UserName = new MailAddress(model.Email).User,
                Email = model.Email,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            string errors = "";
            if (result.Succeeded)
            {
                errors = string.Empty;

                var userfromdb = await _userManager.FindByNameAsync(user.UserName);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(userfromdb);

                var uriBuilder = new UriBuilder(_configuration["ReturnPaths:ConfirmEmail"]);

                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["token"] = token;
                query["userid"] = userfromdb.Id;
                uriBuilder.Query = query.ToString();
                var urlString = uriBuilder.ToString();

                MailService mailService = new MailService(new MailAddress(user.Email.Trim()));

                var subject = "Confirmation Email";
                mailService?.SendMail(urlString, subject);




                await _userManager.AddToRoleAsync(user, "User");

                var jwtSecurityToken = await CreateJwtToken(user);

                return new AuthModel
                {
                    UserId = user.Id,
                    Message = "تم الاشتراك بنجاح",
                    Email = user.Email,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    Roles = new List<string> { "User" },
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),

                };



            }
            foreach (var error in result.Errors)
                errors += $"{error.Description},";

            return new AuthModel { Message = errors };


        }

        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();
            authModel.UserId = user.Id;
            return authModel;
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Sonething went wrong";
        }
        public async Task<string> UpdateUser(UpdateUser model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
                user.Name = model.Name;
                user.PhoneNumber = model.PhoneNumber;
              var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? string.Empty : "Sonething went wrong";





        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();


            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
               // new Claim(JwtRegisteredClaimNames.UniqueName, user.Id),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(issuer: _jwt.Issuer,
                                                        audience: _jwt.Audience,
                                                        claims: claims,
                                                        expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                                                        signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
