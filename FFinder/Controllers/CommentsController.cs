using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFinder.BLL.Abstract;
using FFinder.Core.DataTransferObjects.Comment;
using FFinder.Extensions;
using FFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _commentService.GetAll();
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<List<CommentListDto>> responseModelWithData = new HttpResponseModelData<List<CommentListDto>>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromBody] string id)
        {
            var entities = _commentService.GetById(id);
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<CommentDetailDto> responseModelWithData = new HttpResponseModelData<CommentDetailDto>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıt başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CommentAddDto model)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!model.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                var id = _commentService.Add(model);
                return Ok(new HttpResponseModelSimple
                {
                    StatusCode = 200,
                    Message = id
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
        public async Task<IActionResult> Update([FromBody] CommentUpdateDto model)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!model.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _commentService.Update(model);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                var entity = _commentService.GetById(id);
                if (!entity.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _commentService.Delete(id);
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