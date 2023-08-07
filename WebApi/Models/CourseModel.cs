﻿using System.Collections.Generic;
using BusinessLogic.Contracts;

namespace WebApi.Models
{
    /// <summary>
    /// Модель курса
    /// </summary>
    public class CourseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Уроки
        /// </summary>
        public List<LessonDto> Lessons { get; set; }
    }
}