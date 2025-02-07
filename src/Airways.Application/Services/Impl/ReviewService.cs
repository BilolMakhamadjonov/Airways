using Airways.Application.Models;
using Airways.Application.Models.Review;
using Airways.Core.Entities;
using Airways.DataAccess.Repository;
using AutoMapper;

namespace Airways.Application.Services.Impl
{
    public class ReviewService : IReviewservice
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;


        public ReviewService(IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ReviewResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _reviewRepository.GetAllAsync();

            var mapper = _mapper.Map<List<ReviewResponceModel>>(result);
            return mapper;
        }

        public async Task<IEnumerable<ReviewResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _reviewRepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<ReviewResponceModel>>(todoItems);
        }

        public async Task<CreateReviewResponceModel> CreateAsync(ReviewCreateModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Review>(createTodoItemModel);


            return new CreateReviewResponceModel
            {
                Id = (await _reviewRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateReviewResponceModel> UpdateAsync(Guid id, ReviewUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _reviewRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateReviewResponceModel
            {
                Id = (await _reviewRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _reviewRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _reviewRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
