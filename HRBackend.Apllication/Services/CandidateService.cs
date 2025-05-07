using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using HRBackend.Application.Interface;
using HRBackend.Domain.Entities;
using HRBackend.Domain.Repositories;

namespace HRBackend.Application.Services
{
    public class CandidateService(IUserReposiotry userReposiotry, 
        ICandidateRepository candidateRepository,
        IUnitOfWork unitOfWork) : ICandidateService
    {

        // Метод создания кандидата
        public async Task<CandidateDTO> CreateCandidateAsync(CandidateCreateRequest request, CancellationToken cancellationToken)
        {
            // Получаем необходимые зависимости (WorkSchedule, WorkingGroup, StatusCandidata) по ID
            var user = userReposiotry.GetById(request.UserId);//тут у тебя уже внутри есть и WorkSchedule и WorkingGroup
            if (user == null)
                throw new Exception("");
           //статусы не нужно держать в базе, достаточно создать Enum и проверять что значение в контроллер пришедшее является этим Enum

          
            // Создаем нового кандидата
            var newCandidate = new Candidate
            {
                
                //WorkSchedule = workSchedule,
                //WorkingGroup = workingGroup,
                //StatusCandidataId = statusCandidata,
                //PersonalInfo = personalInfo,
                DateUp = DateTime.UtcNow
            };

            // Добавляем кандидата в базу данных
            candidateRepository.Add(newCandidate);


            await unitOfWork.SaveAsync();
            // Возвращаем DTO с данными кандидата, получая их из связанного объекта PersonalInfo
            return new CandidateDTO(newCandidate);
        }

        // Метод редактирования кандидата
        public async Task<CandidateDTO> UpdateCandidateAsync(CandidateUpdateRequest request, CancellationToken cancellationToken)
        {
            var workSchedule = await _context.WorkSchedules
                .FirstOrDefaultAsync(ws => ws.Id == request.WorkScheduleId, cancellationToken);

            var workingGroup = await _context.WorkGroups
                .FirstOrDefaultAsync(wg => wg.Id == request.WorkingGroupId, cancellationToken);

            var statusCandidata = await _context.DictStatusCandidata
                .FirstOrDefaultAsync(sc => sc.Id == request.StatusCandidataId, cancellationToken);

            var personalInfo = await _context.PersonalInfo
                .FirstOrDefaultAsync(pi => pi.Id == request.PersonalInfoId, cancellationToken);

            if (workSchedule == null || workingGroup == null || statusCandidata == null || personalInfo == null)
            {
                throw new Exception("WorkSchedule, WorkingGroup, StatusCandidata или PersonalInfo не найдены.");
            }

            // Получаем кандидата по ID
            var candidate = await _context.Candidates
                .Include(c => c.PersonalInfo)  // Подключаем PersonalInfo для редактирования
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (candidate == null)
            {
                throw new Exception("Кандидат не найден.");
            }

            // Обновляем данные кандидата
            candidate.WorkSchedule = workSchedule;
            candidate.WorkingGroup = workingGroup;
            candidate.StatusCandidataId = statusCandidata;
            candidate.PersonalInfo = personalInfo;

            // Обновляем данные в PersonalInfo
            candidate.PersonalInfo.Name = request.Name ?? candidate.PersonalInfo.Name;
            candidate.PersonalInfo.Surname = request.Surname ?? candidate.PersonalInfo.Surname;
            candidate.PersonalInfo.Middlename = request.Middlename ?? candidate.PersonalInfo.Middlename;
            candidate.PersonalInfo.Email = request.Email ?? candidate.PersonalInfo.Email;
            candidate.PersonalInfo.Phone = request.Phone ?? candidate.PersonalInfo.Phone;
            candidate.PersonalInfo.NameSocail = request.SocialMedia ?? candidate.PersonalInfo.NameSocail;

            // Дата последнего обновления остается текущей
            candidate.DateUp = DateTime.UtcNow;

            // Сохраняем изменения в базе данных
            await _context.SaveChangesAsync(cancellationToken);

            // Возвращаем DTO с обновленными данными кандидата
            return new CandidateDTO
            {
                Id = candidate.Id,
                Name = candidate.PersonalInfo.Name,
                Surname = candidate.PersonalInfo.Surname,
                Middlename = candidate.PersonalInfo.Middlename,
                Email = candidate.PersonalInfo.Email,
                Phone = candidate.PersonalInfo.Phone,
                SocialMedia = candidate.PersonalInfo.NameSocail,
                Country = request.Country,  // Используем данные из запроса
                BirthDate = request.BirthDate,  // Используем данные из запроса
                WorkSchedule = candidate.WorkSchedule.Name,
                WorkingGroup = candidate.WorkingGroup.Name,
                Status = candidate.StatusCandidataId.Name,
                //DateUp = candidate.DateUp
            };
        }
    }
}
