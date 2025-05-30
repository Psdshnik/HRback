using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using HRBackend.Application.Interface;
using HRBackend.Domain.Entities;
using HRBackend.Domain.Repositories;
using HRBackend.Domain.Enums;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace HRBackend.Application.Services
{
public class CandidateService(IUserReposiotry userReposiotry,
      ICandidateRepository candidateRepository,
      IUnitOfWork unitOfWork,
      IHttpContextAccessor httpContextAccessor) : ICandidateService
  {
        // Метод создания кандидата
        public async Task<CandidateDTO> CreateCandidateAsync(CandidateCreateRequest request, CancellationToken cancellationToken)
        {
            // Получаем userId из токена
            var userId = int.Parse(httpContextAccessor.HttpContext!.User
                .FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var user = await userReposiotry.GetById(userId);
            if (user == null)
                throw new Exception("Пользователь не найден");


            var newCandidate = new Candidate
            {
                UserId = userId,
                WorkSchedule = request.WorkSchedule,
                Status = request.StatusCandidataId,
                DateUp = DateTime.UtcNow,
                PersonalInfo = new PersonalInfo
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Middlename = request.Middlename,
                    Email = request.Email,
                    Phone = request.Phone,
                    NameSocail = request.NameSocail,
                    CountryId = request.CountryId,
                    DateAdd = request.BirthDate
                }
            };


            candidateRepository.Add(newCandidate);
            unitOfWork.SaveAsync(cancellationToken);

            // Возвращаем DTO с данными кандидата
            return new CandidateDTO(newCandidate);
        }


        // Метод редактирования кандидата
        public async Task<CandidateDTO> UpdateCandidateAsync(CandidateUpdateRequest request,CancellationToken cancellationToken)
        {
            // 1. Проверка входных данных
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            // Получаем userId из токена
            var userId = int.Parse(httpContextAccessor.HttpContext!.User
                .FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var user = await userReposiotry.GetById(userId);
            if (user == null)
                throw new Exception("Пользователь не найден");

            // 3. Получаем кандидата из БД
            var candidate = await candidateRepository.GetById(request.Id);
            if (candidate == null)
                throw new KeyNotFoundException("Кандидат не найден");


            var updatedCandidate = new Candidate
            {
                Id = candidate.Id,
                WorkSchedule = request.WorkSchedule ?? candidate.WorkSchedule,
                Status = request.StatusCandidataId ?? candidate.Status,//Status = request.StatusCandidataId ?? candidate.Status,
                UserId = candidate.UserId, // Сохраняем оригинального пользователя
                PersonalInfo = new PersonalInfo
                {
                    Name = request.Name ?? candidate.PersonalInfo.Name,
                    Surname = request.Surname ?? candidate.PersonalInfo.Surname,
                    Middlename = request.Middlename ?? candidate.PersonalInfo.Middlename,
                    Email = request.Email ?? candidate.PersonalInfo.Email,
                    Phone = request.Phone ?? candidate.PersonalInfo.Phone,
                    NameSocail = request.NameSocail ?? candidate.PersonalInfo.NameSocail,
                    CountryId = request.CountryId ?? candidate.PersonalInfo.CountryId,
                    DateAdd = DateTime.UtcNow
                }
            };

            

            await candidateRepository.Update(updatedCandidate);
            await unitOfWork.SaveAsync(cancellationToken);

            return new CandidateDTO(candidate);
        }
    }
}

//candidate = updatedCandidate;