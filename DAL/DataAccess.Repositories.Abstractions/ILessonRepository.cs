using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using Services.Repositories.Abstractions;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Интерфейс репозитория работы с уроками.
    /// </summary>
    public interface ILessonRepository: IRepository<Lesson, int>
    {
        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список уроков. </returns>
        Task<List<Lesson>> GetPagedAsync(int page, int itemsPerPage);
    }
}
