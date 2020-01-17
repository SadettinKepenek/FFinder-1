using System;
using System.Collections.Generic;
using AutoMapper;
using FFinder.BLL.Abstract;
using FFinder.BLL.Validators.Follower;
using FFinder.Core.DataTransferObjects.Follower;
using FFinder.Core.Exception;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;

namespace FFinder.BLL.Concrete
{
    public class FollowerManager : IFollowerService
    {
        private IFollowerRepository _followerRepository;
        private IMapper _mapper;

        public FollowerManager(IFollowerRepository followerRepository, IMapper mapper)
        {
            _followerRepository = followerRepository;
            _mapper = mapper;
        }

        public List<FollowerListDto> Get()
        {
            var entities = _followerRepository.GetList();
            return entities == null ? null : _mapper.Map<List<FollowerListDto>>(entities);
        }

        public FollowerDetailDto Get(string id)
        {
            var entity = _followerRepository.Get(x => x.FollowerId.Equals(id));
            return entity == null ? null : _mapper.Map<FollowerDetailDto>(entity);
        }

        public void Add(FollowerAddDto dto)
        {
            try
            {
                FollowerAddValidator validator = new FollowerAddValidator();
                var result = validator.Validate(dto);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.ToString());
                }

                var entity = _mapper.Map<Follower>(dto);
                _followerRepository.Add(entity);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Update(FollowerUpdateDto dto)
        {
            try
            {
                FollowerUpdateValidator validator = new FollowerUpdateValidator();
                var result = validator.Validate(dto);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.ToString());
                }

                var entity = _mapper.Map<Follower>(dto);
                _followerRepository.Update(entity);

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
                {
                    throw new ValidationException("Id boş geçilemez");
                }

                _followerRepository.Delete(new Follower { FollowerId = id });

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}