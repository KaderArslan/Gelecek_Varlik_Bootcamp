using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Dal.Abstract;
using Workfollow.Entity.Base;
using Workfollow.Entity.IBase;
using Workfollow.Interface;


namespace Workfollow.Bll
{
    //artik somutlastirma yaptigimizdan entitybase ve dtobase olur
    //depency injection ile erismek istedigimizden public, depeny imjection da Apinin startupinda olacak
    public class GenericManager<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        //Dal'la haberlesebilmesi icin bazi senaryolar
        //1. UnitOfWork
        //2. ServiceProvider
        //3. GenericRepository Yonetimi
        //4. constructor

        #region Variables
        private readonly IUnitofWork unitofWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository; //generic oldugu icin ve Dal katmanş ile baglicagimizdan T
        #endregion

        #region Constructor
        public GenericManager(IServiceProvider service)//generic'in tipi service
        {
            //unitofWork, service ve repositoryi aktif edecegiz
            this.service = service; //service startup'tan gelecek
            unitofWork = service.GetService<IUnitofWork>(); 
            repository = unitofWork.GetRepository<T>();
        }
        #endregion

        #region Methods


        //generic kontrol varsa kontrol yapar yoksa Dal'a baglanir
        //bir listelemeyi dusunelim, talepte bulundu herhangi bir kontrol yoksa Dal'a gider listeleme yapar getirir
        public IResponse<TDto> Add(TDto item, bool saveChanges = true) //true geldiyse transectionu onayla yapilacak
        {
            //amac hep response donmek
            //try catch olarak kaydetme yaparken TDto ya geliyor ama ben TDto kaydememem ben bir T yani model kaydederim
            //o yuzden burda bir donusum yapacagiz manuel degil mapperla dondurecegiz
            try
            {
                //dto tipi model(T) tipine donusturuluyor
                //sebebi: dal T ile calisir
                var model = ObjectMapper.Mapper.Map<T>(item);//gelen veriyide al tipinide al(modelle) T ye donurtur
                //resolvesResult donusturulmus sonu
                //gelen data da ilgili kritere gore birlestirme yapmak istersek, string.join bu
                //var resolvesResult = String.Join(',',model.GetType().GetProperties().Select(x=> $" - {x.Name} : {x.GetValue(model) ?? ""} - ")); //nokto virgul gibi seyleri ayirt etmek icin kullaniliyor
                //var result = repository.Add(); //repository Generic kullaniyoruz yani interface metodu bunlar

                //var result = repository.Add(ObjectMapper.Mapper.Map<T>(item)) //neye donusturecem T ye, neyi donusturecem itemi

                var result = repository.Add(model); //donustu kaydetme yapacagiz artik

                if (saveChanges)
                    Save(); //kaydetme islemi oldugundan transactionu commitliyoruz yani onayliyoruz

                //artik somutlastirma zamani, nesne dondurecegiz
                //donus tipini ayarliyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message =  "Success",
                    Data = ObjectMapper.Mapper.Map<T,TDto>(result)//T tipinde result
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda donecek veri seti
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null//gelse zaten hata vermez
                };
            }
        }

        public async Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<T>(item);

                var result = await repository.AddAsync(model); //cevap gelirken beklemesi lazim

                if (saveChanges)
                    Save(); 

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }

        //bu bool donuyor   
        public IResponse<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);//id istiyor, burada hata varsa asagiya inmez
                if (saveChanges)
                    Save();

                return new Response<bool> //ne istiyorsa onu dondurur
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",  //"Error"+ex.Message
                    Data = false
                };
            }
        }

        public Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Find(int id)
        {
            //Find a gelen T olur TDto ya donusur
            try
            {
                var entity = ObjectMapper.Mapper.Map<T,TDto>(repository.Find(id));
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll()
        {
            try
            {
                var list = repository.GetAll();
                //liste cekmek bu sekilde, digerleri nesneydi
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                var list = repository.GetAll(expression);
                //liste cekmek bu sekilde, digerleri nesneydi
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<IQueryable<TDto>> GetQueryable()
        {
            try
            {
                var list = repository.GetQueryable();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x));
                //bir datayı cektigimde ve select uyguladigimda zaten queryable olarak gelir
                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<TDto> Update(TDto item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<T>(item);

                var result = repository.Update(model);

                if (saveChanges)
                    Save(); 

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }

        public Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            unitofWork.SaveChanges();
        }


        #endregion
    }
}
