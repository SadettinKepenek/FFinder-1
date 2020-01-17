using System;
using System.Collections.Generic;
using AutoMapper;
using FFinder.BLL.Abstract;
using FFinder.BLL.Validators.PostRate;
using FFinder.Core.DataTransferObjects.PostRate;
using FFinder.Core.Exception;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;

namespace FFinder.BLL.Concrete
{
    public class PostRateManager : IPostRateService
    {
        private IMapper _mapper;
        private IPostRateRepository _postRateRepository;

        public PostRateManager(IMapper mapper, IPostRateRepository postRateRepository)
        {
            _mapper = mapper;
            _postRateRepository = postRateRepository;
        }


        public List<PostRateListDto> Get()
        {
            var entities = _postRateRepository.GetList();
            return entities == null ? null : _mapper.Map<List<PostRateListDto>>(entities);
        }

        public PostRateDetailDto Get(string id)
        {
            var entities = _postRateRepository.Get();
            return entities == null ? null : _mapper.Map<PostRateDetailDto>(entities);
        }

        public void Add(PostRateAddDto dto)
        {
            try
            {
                var validator = new PostRateAddValidator();
                var result = validator.Validate(dto);
                if (!result.IsValid)
                    throw new ValidationException(result.ToString());
                var entity = _mapper.Map<PostRate>(dto);
                _postRateRepository.Add(entity);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Update(PostRateUpdateDto dto)
        {
            try
            {
                var validator = new PostRateUpdateValidator();
                var result = validator.Validate(dto);
                if (!result.IsValid)
                    throw new ValidationException(result.ToString());
                var entity = _mapper.Map<PostRate>(dto);
                _postRateRepository.Update(entity);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                    throw new ValidationException("Id boş geçilemez");
                _postRateRepository.Delete(new PostRate
                {
                    PostRateId = id
                });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}