﻿using System;
using BusinessLogic.Abstractions;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Contracts.Course;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Cервис работы с курсами.
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CourseService(
            IMapper mapper,
            ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        /// <summary>
        /// Получить список курсов.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Список курсов. </returns>
        public async Task<ICollection<CourseDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<Course> entities = await _courseRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Course>, ICollection<CourseDto>>(entities);
        }

        /// <summary>
        /// Получить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО курса. </returns>
        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        /// <summary>
        /// Создать курс.
        /// </summary>
        /// <param name="creatingCourseDto"> ДТО создаваемого курса. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> CreateAsync(CreatingCourseDto creatingCourseDto)
        {
            var course = _mapper.Map<CreatingCourseDto, Course>(creatingCourseDto);
            var createdCourse = await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();
            return createdCourse.Id;
        }

        /// <summary>
        /// Изменить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingCourseDto"> ДТО редактируемого курса. </param>
        public async Task UpdateAsync(int id, UpdatingCourseDto updatingCourseDto)
        {
            var course = await _courseRepository.GetAsync(id);
            if (course == null)
            {
                throw new Exception($"Курс с идентфикатором {id} не найден");
            }

            course.Name = updatingCourseDto.Name;
            course.Price = updatingCourseDto.Price;
            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить курс.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(int id)
        {
            var course = await _courseRepository.GetAsync(id);
            course.Deleted = true; 
            await _courseRepository.SaveChangesAsync();
        }
    }
}