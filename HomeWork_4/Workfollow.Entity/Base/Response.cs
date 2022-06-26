using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.IBase;

namespace Workfollow.Entity.Base
{
    //response var Iresponse'tan kalitim alir
    public class Response : IResponse
    {
        //public string Message -> uye degisken
        //public string Message { get; set; } -> proporty
        //{ get; set; } bunlar ile kapsulleme teknigini yapabiliriz

        //response'um ne dondurebilir, mesaj, statuskod,
        public string Message { get; set; } 
        public int StatusCode { get; set; }

        //object yani data her sey olabilir
        public object Data { get; set; }
    }
    //IBase'de generic response de tanımladigimiz icin burada da tanimladik
    //verilen degere gore hangisinin calisacagini sistem kendisi belirliyor
    public class Response<T> : IResponse<T>
    {
        //ekrandaki veri formati
        public string Message { get; set; }
        public int StatusCode { get; set; }
        //Data'da generic olacak, personelistesi ya da sadece sayi gibi degerlerin hepsini kapsayabilir,
        //ya da merhaba degeri
        public T Data { get; set; }
    }
}
