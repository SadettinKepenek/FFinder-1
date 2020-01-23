using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFinder.BLL.Abstract;
using FFinder.Core.DataTransferObjects.PostRate;
using FFinder.Extensions;
using FFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostRatesController : ControllerBase
    {
        IPostRateService _postRateService;
        public PostRatesController(IPostRateService postRateService)
        {
            _postRateService = postRateService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postRateService.Get();
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<List<PostRateListDto>> responseModelWithData = new HttpResponseModelData<List<PostRateListDto>>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromBody] string id)
        {
            var entities = _postRateService.Get(id);
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<PostRateDetailDto> responseModelWithData = new HttpResponseModelData<PostRateDetailDto>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıt başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostRateAddDto model)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!model.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _postRateService.Add(model);
                return Ok(new HttpResponseModelSimple
                {
                    StatusCode = 200,
                    Message = "Kayıt başarıyla eklendi"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseModelSimple
                {
                    StatusCode = 400,
                    Message = "Kayıt eklenirken bir hata oluştu"
                });
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PostRateUpdateDto model)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!model.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _postRateService.Update(model);
                return Ok(new HttpResponseModelSimple
                {
                    StatusCode = 200,
                    Message = "Kayıt başarıyla güncellendi"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseModelSimple
                {
                    StatusCode = 400,
                    Message = "Kayıt güncellenirken bir hata oluştu"
                });
            }
        }
        [HttpDelete("Delete/{id}/{ownerId}")]
        public async Task<IActionResult> Delete([FromBody] string id,[FromBody] string ownerId)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                var entity = _postRateService.Get(id);
                if (!entity.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _postRateService.Delete(ownerId,id);
                return Ok(new HttpResponseModelSimple
                {
                    StatusCode = 200,
                    Message = "Kayıt başarıyla silindi"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseModelSimple
                {
                    StatusCode = 400,
                    Message = "Kayıt silinirken bir hata oluştu"
                });
            }
        }
    }
}