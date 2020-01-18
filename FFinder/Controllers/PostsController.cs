using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FFinder.BLL.Abstract;
using FFinder.Core.DataTransferObjects.Post;
using FFinder.Extensions;
using FFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postService.GetAll();
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<List<PostListDto>> responseModelWithData = new HttpResponseModelData<List<PostListDto>>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromBody] string id)
        {
            var entities = _postService.GetById(id);
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<PostDetailDto> responseModelWithData = new HttpResponseModelData<PostDetailDto>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıt başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostAddDto model)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!model.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _postService.Add(model);
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
        public async Task<IActionResult> Update([FromBody] PostUpdateDto model)
        {
            try
            {
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!model.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _postService.Update(model);
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
                var entity = _postService.GetById(id);
                string nameIdentifier = HttpContext.GetNameIdentifier();
                if (!entity.OwnerId.Equals(nameIdentifier))
                {
                    return Unauthorized("Erişim kısıtlandırıldı.");
                }
                _postService.Delete(id);
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