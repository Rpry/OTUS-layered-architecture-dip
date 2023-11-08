using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Contracts.Lesson;

namespace BusinessLogic.Abstractions
{
    /// <summary>
    /// Сервис работы с уроками (интерфейс).
    /// </summary>
    public interface ILessonService
    {
        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Список уроков. </returns>
        Task<ICollection<LessonDto>> GetPagedAsync(int page, int pageSize);

        /// <summary>
        /// Получить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО урока. </returns>
        Task<LessonDto> GetByIdAsync(int id);

        /// <summary>
        /// Создать урок.
        /// </summary>
        /// <param name="creatingLessonDto"> ДТО урока. </param>
        /// <returns> Идентификатор. </returns>
        Task<int> CreateAsync(CreatingLessonDto creatingLessonDto);

        /// <summary>
        /// Изменить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingLessonDto"> ДТО урока. </param>
        Task UpdateAsync(int id, UpdatingLessonDto updatingLessonDto);

        /// <summary>
        /// Удалить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(int id);
    }
}