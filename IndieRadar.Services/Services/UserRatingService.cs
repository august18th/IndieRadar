using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces;

namespace IndieRadar.Services.Services
{
    public class UserRatingService : IUserRatingService
    {
        private readonly IUserRatingRepository _userRatingRepository;
        private readonly IMapper _mapper;

        public UserRatingService(IUserRatingRepository userRatingRepository, IMapper mapper)
        {
            _userRatingRepository = userRatingRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<UserRatingDTO>> GetUserRatingsByUserAsync(String userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var userRatings = await _userRatingRepository.FindAllAsync(u => u.UserId == userId);

            if (userRatings == null)
            {
                throw new NullReferenceException("User ratings for this user does not exist");
            }

            return _mapper.Map<ICollection<UserRating>, ICollection<UserRatingDTO>>(userRatings);
        }

        public async Task<ICollection<UserRatingDTO>> GetUserRatingsByGameAsync(Int32 gameId)
        {
            var userRatings = await _userRatingRepository.FindAllAsync(u => u.GameId == gameId);

            if (userRatings == null)
            {
                throw new NullReferenceException("User ratings for this game does not exist");
            }

            return _mapper.Map<ICollection<UserRating>, ICollection<UserRatingDTO>>(userRatings);
        }

        public async Task<UserRatingDTO> CreateUserRatingAsync(UserRatingDTO userRating)
        {
            if (userRating == null)
            {
                throw new ArgumentNullException(nameof(userRating));
            }

            var createdUserRating = await _userRatingRepository
                .AddAsync(_mapper.Map<UserRatingDTO, UserRating>(userRating));

            if (createdUserRating == null)
            {
                throw new NullReferenceException("User rating was not added");
            }
            return _mapper.Map<UserRating, UserRatingDTO>(createdUserRating);
        }

        public async Task<UserRatingDTO> EditUserRatingAsync(UserRatingDTO userRating)
        {
            if (userRating == null)
            {
                throw new ArgumentNullException(nameof(userRating));
            }

            var createdUserRating = await _userRatingRepository
                .UpdateAsync(_mapper.Map<UserRatingDTO, UserRating>(userRating));

            if (createdUserRating == null)
            {
                throw new NullReferenceException("User rating was not updated");
            }
            return _mapper.Map<UserRating, UserRatingDTO>(createdUserRating);
        }
    }
}