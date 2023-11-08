using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.EntityFramework;
using Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий работы с курсами.
    /// </summary>
    public class CourseRepository: Repository<Course, int>, ICourseRepository 
    {
        public CourseRepository(DatabaseContext context): base(context)
        {
        }
      
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список курсов. </returns>
        public async Task<List<Course>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll().Where(c => !c.Deleted);
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
    }
}
