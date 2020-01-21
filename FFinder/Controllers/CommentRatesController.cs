using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFinder.BLL.Abstract;
using FFinder.Core.DataTransferObjects.CommentRate;
using FFinder.Entity.Concrete;
using FFinder.Extensions;
using FFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentRatesController : ControllerBase
    {
        ICommentRateService _commentRateService;
        public CommentRatesController(ICommentRateService commentRateService)
        {
            _commentRateService = commentRateService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _commentRateService.GetAll();
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<List<CommentRateListDto>> responseModelWithData = new HttpResponseModelData<List<CommentRateListDto>>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromBody] string id)
        {
            var entities = _commentRateService.GetById(id);
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<CommentRateDetailDto> responseModelWithData = new HttpResponseModelData<CommentRateDetailDto>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıt başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CommentRateAddDto model)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!model.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _commentRateService.Add(model);
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
        public async Task<IActionResult> Update([FromBody] CommentRateUpdateDto model)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!model.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _commentRateService.Update(model);
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
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                var entity = _commentRateService.GetById(id);
                if (!entity.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _commentRateService.Delete(id);
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