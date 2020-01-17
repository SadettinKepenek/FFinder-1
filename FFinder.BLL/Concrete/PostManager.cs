using AutoMapper;
using FFinder.BLL.Abstract;
using FFinder.BLL.Validators.Post;
using FFinder.Core.DataTransferObjects.Post;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Concrete
{
    public class PostManager:IPostService
    {
        IPostRepository _postRepository;
        IMapper _mapper;
        public PostManager(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public void Add(PostAddDto model)
        {
            try
            {
                PostAddValidator validator = new PostAddValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new Exception("Validation hatası");
                }
                var mappedPost = _mapper.Map<Post>(model);
                _postRepository.Add(mappedPost);
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
                var mappedPost = _mapper.Map<Post>(id);
                _postRepository.Delete(mappedPost);
            }
            catch (Exception e)
            {

                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public List<PostListDto> GetAll()
        {
            try
            {            
                var posts = _postRepository.GetList();
                if (posts == null)
                {
                    throw new ArgumentNullException("Post Bulunamadı");
                }

                var mappedPosts = _mapper.Map<List<PostListDto>>(posts);
                return mappedPosts;
            }
            catch (Exception e)
            { 
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
            
        }

        public PostDetailDto GetById(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new NullReferenceException("id null olamaz");
                }
                var post = _postRepository.GetList(x => x.PostId == id);
                if (post == null)
                {
                    throw new ArgumentNullException("Post Bulunamadı");
                }

                var mappedPost = _mapper.Map<PostDetailDto>(post);
                return mappedPost;
            }
            catch (Exception e)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public void Update(PostUpdateDto model)
        {
            PostUpdateValidator validator = new PostUpdateValidator();
            var validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
            {
                throw new Exception("Validation hatası");
            }
            try
            {
                var mappedPost = _mapper.Map<Post>(model);
                _postRepository.Update(mappedPost);                      
            }
            catch (Exception e)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }
    }
}
