using AutoMapper;
using FFinder.BLL.Abstract;
using FFinder.BLL.Validators.Comment;
using FFinder.BLL.Validators.Post;
using FFinder.Core.DataTransferObjects.Comment;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        IMapper _mapper;
        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }
        public void Add(CommentAddDto model)
        {
            try
            {
                AddCommentValidator validator = new AddCommentValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new Exception("Validation hatası");
                }
                var mappedPost = _mapper.Map<Comment>(model);
                _commentDal.Add(mappedPost);
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
                
                _commentDal.Delete(new Comment { CommentId = id});
            }
            catch (Exception e)
            {

                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public List<CommentListDto> GetAll()
        {
            try
            {
                var posts = _commentDal.GetList();
                if (posts == null)
                {
                    throw new ArgumentNullException("Post Bulunamadı");
                }

                var mappedPosts = _mapper.Map<List<CommentListDto>>(posts);
                return mappedPosts;
            }
            catch (Exception e)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public CommentDetailDto GetById(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new NullReferenceException("id null olamaz");
                }
                var post = _commentDal.GetList(x => x.CommentId == id);
                if (post == null)
                {
                    throw new ArgumentNullException("Post Bulunamadı");
                }

                var mappedPost = _mapper.Map<CommentDetailDto>(post);
                return mappedPost;
            }
            catch (Exception e)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public void Update(CommentUpdateDto model)
        {
            try
            {
                UpdateCommentValidator validator = new UpdateCommentValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new Exception("Validation hatası");
                }
                var mappedPost = _mapper.Map<Comment>(model);
                _commentDal.Update(mappedPost);
            }
            catch (Exception e)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }
    }
}
