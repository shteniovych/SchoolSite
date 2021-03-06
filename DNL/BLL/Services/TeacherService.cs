﻿using BLL.AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class TeacherService : Service<Teacher, TeacherViewModel>, ITeacherService
    {
        public TeacherService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Teachers)
        {
            
        }

        public void AddTeacher(string userId, TeacherViewModel model)
        {
            var teacher = Database.Teachers.Add(new Teacher {
                UserId = userId,
                Category = model.Category,
                MethodicalAssociationId = Convert.ToInt32(model.MethodicalAssociation),
                Rank = model.Rank,
                IsManager = model.IsManager,
                AdminPosition = model.AdminPosition
            });
            foreach(var item in model.Subjects)
            {
                var subjectDb = Database.Subjects.GetAll().Where(subject => subject.Name == item).First();
                Database.TeacherSubjects.Add(new TeacherSubject { TeacherId = teacher.Id, SubjectId = subjectDb.Id });
            }
            Database.Save();
        }

        public void UpdateTeacher(TeacherViewModel model)
        {
            var teacher = Database.Teachers.GetAll().First(t => t.UserId == model.UserId);

            teacher.RankId = (int)model.Rank;
            teacher.CategoryId = (int)model.Category;
            teacher.MethodicalAssociationId = model.MethodicalAssociationId;

            //Subjects
            //delete 
            foreach (var item in Database.TeacherSubjects.GetAll())
            {
                if (item.TeacherId == teacher.Id)
                    Database.TeacherSubjects.Delete(item);
            }
            Database.Save();
            //update teacher's subjects
            foreach (var item in model.Subjects)
            {
                var subjectId = Database.Subjects.GetAll().First(s => s.Name == item).Id;
                Database.TeacherSubjects.Add(new TeacherSubject { TeacherId = teacher.Id, SubjectId = subjectId });
            }

            Database.Save();
        }

        public void AddAssociation(MethodicalAssociationViewModel model)
        {
            Database.MethodicalAssociations.Add(new MethodicalAssociation { Name = model.Name, Presentation = model.Presentation });
            Database.Save();
        }       

        public string GetAssociationNameById(int id)
        {
            return Database.MethodicalAssociations.Get(id).Name;
        }

        public MethodicalAssociationViewModel GetAssociationById(int id)
        {
            var result = Database.MethodicalAssociations.Get(id);
            return Mapping.Map<MethodicalAssociation, MethodicalAssociationViewModel>(result);
        }

        public void UpdateAssociation(MethodicalAssociationViewModel model)
        {
            var result = Mapping.Map<MethodicalAssociationViewModel, MethodicalAssociation>(model);
            Database.MethodicalAssociations.Update(result);
            Database.Save();
        }

        public void DeleteAssociation(int id)
        {
            Database.MethodicalAssociations.Delete(id);
            Database.Save();
        }

        public IEnumerable<TeacherViewModel> GetAdministration()
        {
            var result = Database.Teachers.GetAll().Include(teacher => teacher.AppUser).Include(teacher => teacher.TeacherSubjects).ThenInclude(teacherSubject => teacherSubject.Subject).Where(teacher => teacher.IsManager == true);
            return Mapping.Map<IEnumerable<Teacher>, IEnumerable<TeacherViewModel>>(result);
        }

        public TeacherViewModel GetTeacherByUserId(string userId)
        {
            var result = Database.Teachers.GetAll().Include(teacher => teacher.AppUser).Include(teacher => teacher.TeacherSubjects).ThenInclude(teacherSubject => teacherSubject.Subject).Where(teacher => teacher.AppUser.Id == userId).First();
            return Mapping.Map<Teacher, TeacherViewModel>(result);
        }

        public IEnumerable<MethodicalAssociationViewModel> GetMethodicalAssociations()
        {
            var result = Database.MethodicalAssociations.GetAll();
            return Mapping.Map<IEnumerable<MethodicalAssociation>, IEnumerable<MethodicalAssociationViewModel>>(result);
        }

        public IEnumerable<TeacherViewModel> GetTeachersByAssociationId(int id)
        {
            var result = Database.Teachers.GetAll().Include(teacher => teacher.AppUser).Include(teacher => teacher.TeacherSubjects).ThenInclude(teacher => teacher.Subject).Where(teacher => teacher.MethodicalAssociationId == id);
            return Mapping.Map<IEnumerable<Teacher>, IEnumerable<TeacherViewModel>>(result);
        }
    }
}
