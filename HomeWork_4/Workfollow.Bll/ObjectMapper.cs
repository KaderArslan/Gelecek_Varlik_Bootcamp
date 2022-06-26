using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Mapper;

namespace Workfollow.Bll
{
    //sadece Bll de calisacak
    //turetme yapacagiz kalitim vermicegiz o yuzden internal
    //kalitim protected
    //nesne turetme yontemi ile internal
    //biz her bir classa tek tek kalitim vermemek icin turetme yontemi ile yapiyoruz
    internal class ObjectMapper
    {
        //profile gec olustursun anlaminda birbirine donusturmeyi sonradan olusturur
        //readonly sonradan müdehale edilemesin
        //tasarim yaptim ama projede kullanilmayacaksa olusmasin, sonradan olusan
        //new turetme yapildigi anlamina gelir
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            //profilemizi gec olusturmasini istiyoruz
            var config = new MapperConfiguration(cfg=>
            {
                //Profile Mapperdaki mappingprofiledir
                //mappingleride bolebiliriz fatura,stok,irsaliye ayri ayri yapilabilir
                //AddProfile generic
                cfg.AddProfile<MappingProfile>();
                //baska bir mapping profile olursa burada ekleriz
                //cfg.AddProfile<MappingProfilex>(); gibi
            });
            //createmapperi dondurur
            //sen bir mapper olustur ve createmapper olusur
            return config.CreateMapper();
        }
        );

        //bana hep mapper dondur
        //lazy value dondur
        //static yaptik ki direkt erisebilelim, profillerimi kullanabilmek icin static yaptik
        //profillerimizi kullanabilmek icin static yaptik
        public static IMapper Mapper => lazy.Value;
        
        
    }
}
