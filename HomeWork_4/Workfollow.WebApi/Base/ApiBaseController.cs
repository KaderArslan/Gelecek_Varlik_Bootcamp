using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Workfollow.Entity.Base;
using Workfollow.Entity.IBase;
using Workfollow.Interface;

namespace Workfollow.WebApi.Base
{
    //ortak olan metodlari buraya topluyoruz
    //erisirken www.abc.com/api/controller(yani ApiBase controller ismidir)
    //[Route("api/[controller]/[action]")] //bu sekilde de olabilir
    [Route("api/[controller]")]
    [ApiController]
    //TInterface mesela empolye geldigimizde depency injaction kullanacagiz ya hangi interface kullanacagini verecegiz
    //IGenericService GenericService kendi kendine calismaz T TDto ister

    //
    //api base aktif edecem ve heryerde bu kullanılacak
    //yani api baseden kalıtım alan her yer token karşılaştırmasını kullanabilecek
    //tek tek yapmak yerine böyle kullanacağız
    //apibase kullanan her yer token almadan işlem yapmasın bunuda aktif etmem gerekiyor
    //tokenla erişip erişmemeye şimdi ayar vereceğiz
    //
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    //yani token almayan login olmayan hiç kimse artık api baseden kalıtım alan
    //hiç bir yere erişemeyiz demektir 
    // 
    public class ApiBaseController<TService, T, TDto> : ControllerBase where TService : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        private readonly TService service;

        public ApiBaseController(TService service)
        {
            this.service = service;
        }
        //bundan sonrasi metod, metod tasarlicagiz
        //erisim protokolu, bunlar attiribute dir, url den erisim yapabillirim


        //api/employee/Find
        //api/employee/Getir eger yukarida action yazarsak Getirle Find islemimiz gelmez 
        //istedigimiz sekilde getirebilmek icin () paranterz acilir
        //erisirken bu sekilde erismen istenebilir Find ile calissin

        [HttpGet("Find")]

        //donus tipi IRespose TDto dondurecek
        public IResponse<TDto> Find(int id)
        {
            try
            {
                //ekrandaki veri formati Response.cs deki gibidir
                //Find IResponse TDto dondurur o yuzden format yok
                return service.Find(id);
            }
            catch (Exception ex)
            {
                //hata durumundaki format
                return new Response<TDto>
                {
                    StatusCode =  StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };    
            }    
        }
        //Find GetAll benzer

        [HttpGet("GetAll")]

        //donus tipi IRespose TDto dondurecek
        public IResponse<List<TDto>> GetAll()
        {
            try
            {
                return service.GetAll();
            }
            catch (Exception ex)
            {
                //hata durumundaki format
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPost("Add")] //HttpPost body ile data gonder diyoruz
        public IResponse<TDto> Add(TDto entity)
        {
            try
            {
                return service.Add(entity);//entityi kaydet
            }
            catch (Exception ex)
            {
                return new Response<TDto>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


        [HttpDelete("Delete")]
        public IResponse<bool> Delete(int id)//delete id alir, DeleteById bool dondurur
        {
            try
            {
                return service.DeleteById(id);
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = false //hata aninda false olur
                };
            }
        }

        [HttpPut("Update")]
        public IResponse<TDto> Update(TDto entity)
        {
            try
            {
                return service.Update(entity);
            }
            catch (Exception ex)
            {
                return new Response<TDto>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
