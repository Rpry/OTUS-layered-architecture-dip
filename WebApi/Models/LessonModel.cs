namespace WebApi.Models
{
    /// <summary>
    /// Модель урока
    /// </summary>
    public class LessonModel
    {
        /// <summary>
        /// Идентификатор курса
        /// </summary>
        public int CourseId { get; set; }
        
        /// <summary>
        /// Тема
        /// </summary>
        public string Subject { get; set; }
    }
}