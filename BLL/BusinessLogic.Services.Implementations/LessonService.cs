using System;
using BusinessLogic.Abstractions;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Contracts.Lesson;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Сервис работы с уроками (интерфейс).
    /// </summary>
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;

        public LessonService(
            IMapper mapper,
            ILessonRepository lessonRepository)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
        }

        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Список уроков. </returns>
        public async Task<ICollection<LessonDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<Lesson> entities = await _lessonRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Lesson>, ICollection<LessonDto>>(entities);
        }

        /// <summary>
        /// Получить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО урока. </returns>
        public async Task<LessonDto> GetByIdAsync(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            return _mapper.Map<LessonDto>(lesson);
        }

        /// <summary>
        /// Создать урок.
        /// </summary>
        /// <param name="creatingLessonDto"> ДТО урока. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> CreateAsync(CreatingLessonDto creatingLessonDto)
        {
            var lesson = _mapper.Map<CreatingLessonDto, Lesson>(creatingLessonDto);
            lesson.CourseId = creatingLessonDto.CourseId;
            var createdLesson = await _lessonRepository.AddAsync(lesson);
            await _lessonRepository.SaveChangesAsync();
            return createdLesson.Id;
        }

        /// <summary>
        /// Изменить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingLessonDto"> ДТО урока. </param>
        public async Task UpdateAsync(int id, UpdatingLessonDto updatingLessonDto)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            if (lesson == null)
            {
                throw new Exception($"Урок с id = {id} не найден");
            }

            lesson.Subject = updatingLessonDto.Subject;
            _lessonRepository.Update(lesson);
            await _lessonRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            lesson.Deleted = true; 
            await _lessonRepository.SaveChangesAsync();
        }
    }
}