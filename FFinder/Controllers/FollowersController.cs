using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFinder.BLL.Abstract;
using FFinder.Core.DataTransferObjects.Follower;
using FFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        IFollowerService _followerService;

        public FollowersController(IFollowerService followerService)
        {
            _followerService = followerService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _followerService.Get();
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<List<FollowerListDto>> responseModelWithData = new HttpResponseModelData<List<FollowerListDto>>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromBody] string id)
        {
            var entities = _followerService.Get(id);
            if (entities == null)
            {
                return NotFound(new HttpResponseModelSimple
                {
                    StatusCode = 404,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            HttpResponseModelData<FollowerDetailDto> responseModelWithData = new HttpResponseModelData<FollowerDetailDto>();
            responseModelWithData.StatusCode = 200;
            responseModelWithData.Message = "Kayıt başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] FollowerAddDto model)
        {
            try
            {
                _followerService.Add(model);
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
        public async Task<IActionResult> Update([FromBody] FollowerUpdateDto model)
        {
            try
            {
                _followerService.Update(model);
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
                _followerService.Delete(id);
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