using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Contracts.Course;

namespace BusinessLogic.Abstractions
{
    /// <summary>
    /// Cервис работы с курсами (интерфейс).
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Получить список курсов.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Список курсов. </returns>
        Task<ICollection<CourseDto>> GetPagedAsync(int page, int pageSize);

        /// <summary>
        /// Получить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО курса. </returns>
        Task<CourseDto> GetByIdAsync(int id);

        /// <summary>
        /// Создать курс.
        /// </summary>
        /// <param name="creatingCourseDto"> ДТО создаваемого курса. </param>
        Task<int> CreateAsync(CreatingCourseDto creatingCourseDto);

        /// <summary>
        /// Изменить курс.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="updatingCourseDto"> ДТО редактируемого курса. </param>
        Task UpdateAsync(int id, UpdatingCourseDto updatingCourseDto);

        /// <summary>
        /// Удалить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(int id);
    }
}