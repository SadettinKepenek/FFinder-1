using AutoMapper;
using FFinder.BLL.Abstract;
using FFinder.BLL.Validators.CommentRate;
using FFinder.BLL.Validators.Post;
using FFinder.Core.DataTransferObjects.CommentRate;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Concrete
{
    public class CommentRateManager : ICommentRateService
    {
        IMapper _mapper;
        ICommentRateDal _commentRateDal;
        public CommentRateManager(IMapper mapper, ICommentRateDal commentRateDal)
        {
            _mapper = mapper;
            _commentRateDal = commentRateDal;
        }
        public void Add(CommentRateAddDto model)
        {
            try
            {
                AddCommentRateValidator validator = new AddCommentRateValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new Exception("Validation hatası");
                }
                var mappedPost = _mapper.Map<CommentRate>(model);
                _commentRateDal.Add(mappedPost);
            }
            catch (Exception e)
            {

                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public void Delete(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new NullReferenceException("id null olamaz");
                }
                _commentRateDal.Delete(new CommentRate {CommentRateId = id });
            }
            catch (Exception e)
            {

                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public List<CommentRateListDto> GetAll()
        {
            try
            {
                var posts = _commentRateDal.GetList();
                if (posts == null)
                {
                    throw new ArgumentNullException("Post Bulunamadı");
                }

                var mappedPosts = _mapper.Map<List<CommentRateListDto>>(posts);
                return mappedPosts;
            }
            catch (Exception e)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public CommentRateDetailDto GetById(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new NullReferenceException("id null olamaz");
                }
                var post = _commentRateDal.GetList(x => x.CommentRateId == id);
                if (post == null)
                {
                    throw new ArgumentNullException("Post Bulunamadı");
                }

                var mappedPost = _mapper.Map<CommentRateDetailDto>(post);
                return mappedPost;
            }
            catch (Exception e)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public void Update(CommentRateUpdateDto model)
        {
            try
            {
                UpdateCommentRateValidator validator = new UpdateCommentRateValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new Exception("Validation hatası");
                }
                var mappedPost = _mapper.Map<CommentRate>(model);
                _commentRateDal.Update(mappedPost);
            }
            catch (Exception e)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }
    }
}
