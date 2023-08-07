using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Интерфейс репозитория работы с уроками
    /// </summary>
    public interface ILessonRepository: IRepository<Lesson, int>
    {
        Task<List<Lesson>> GetPagedAsync(int page, int itemsPerPage);
    }
}
