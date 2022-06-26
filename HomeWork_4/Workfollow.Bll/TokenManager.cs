using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Dto;

namespace Workfollow.Bll
{
    public class TokenManager
    {
        IConfiguration configuration;

        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //token uretecek
        public string CreateAccessToken(DtoLoginEmployee employee)
        {
            //token parçaları
            //1. claim id gibi, usercode gibi role gibi bilgileri claimlere gomeriz

            var claims = new[]
            {
                //Sub; usercode gibi kullanıcı kodu gibi subla donduruyoruz
                //new Claim(JwtRegisteredClaimNames.Sub, employee.UserCode)
                new Claim(JwtRegisteredClaimNames.Email, employee.EmployeeEmail),
                //jti de genelde id gonderiyoruz
                new Claim(JwtRegisteredClaimNames.Jti, employee.EmployeeId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            //2. claim roller admin rolü, yonetici rolu, personel rolü
            //rol keyleri
            var claimsRoleList = new List<Claim>
            {
                new Claim("role","Admin"),
                //new Claim("role2","Yönetici"),
                //new Claim("role3","Personel")
            };

            //3. security key, key ile sifreleme yapacagiz keyide appsettinden okucagiz configuration gibi
            //verdiğim değerin bytenı verecek
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //4. şifrelenmiş kimlik oluşturma , hangi şifreleme algoritması ile yapacaksın çektiğimiz keyi bununla şifreliceğiz
            //key ele gecirelemezse tokenı ele geçirsek dahi yeni bir token oluşturamayız
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //5. token ayarları, ne kadar süre devam etsin, hangi apilerden erişebilsin gibi ayarlar

            var token = new JwtSecurityToken//herşey burada
            (
                issuer : configuration["Tokens:Issuer"],//token dağıtıcı url,
                audience : configuration["Tokens:Issuer"],//erişilebilecek api'ler,
                //ömrü token alındıktan itibaren başlasın ve 1 gün süresini ayarladık
                expires : DateTime.Now.AddDays(1),
                //token aldıktan sonra ne zaman tokenın aktif olsun karşılaştımra yapsın oturum kontrolü yapsın
                //o süre boyunca aktif olmadığından işleme devam edilebilir
                notBefore : DateTime.Now,//token alındıktan hemen sonra aktif olsun
                signingCredentials : cred, //şifrelenmiş keyimizi verdik, kimlik verdik
                claims : claimsIdentity.Claims //claims'leri verdik

            );

            //6. token oluşturma sınıfı ile örnek alıp (intances aslında) üretmek burda token üretilir, üretip returnle dondureceğiz

            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;


        }
    }
}
