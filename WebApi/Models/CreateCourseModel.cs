namespace WebApi.Models
{
    /// <summary>
    /// Курс
    /// </summary>
    public class CreateCourseModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }
    }
}