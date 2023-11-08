using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using Services.Repositories.Abstractions;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Интерфейс репозитория работы с курсами.
    /// </summary>
    public interface ICourseRepository: IRepository<Course, int>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список курсов. </returns>
        Task<List<Course>> GetPagedAsync(int page, int itemsPerPage);
    }
}
