﻿using System;
using System.Collections.Generic;
using System.Linq;
using AcademicManagement.Application.DTOs;
using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Entities;
using AcademicManagement.Persistence;
using AutoMapper;

namespace AcademicManagement.Application.Services.Asignatures
{
    public class AsignatureAppService : IAsignatureAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AsignatureAppService()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public AsignatureDto Create(AsignatureDto item)
        {
            var newAsignature = new Asignature
            {              
                Name = item.Name,
                Description = item.Description            

            };
            _unitOfWork.Asignatures.Add(newAsignature);

            item.AsignatureId = newAsignature.AsignatureId;

            _unitOfWork.Commit();
            return item;
        }

        public AsignatureDto Delete(int id)
        {
            var asignature = _unitOfWork.Asignatures.GetById(id);
            var asignaturDto = new AsignatureDto();

            if (asignature == null)
            {
                //studentDto.ErrorMessage = "Student not found";
                return asignaturDto;
            }
            _unitOfWork.Asignatures.Delete(asignature);
            _unitOfWork.Commit();
            return asignaturDto;
        }

        public List<AsignatureDto> Find(string query)
        {
            var asignatures = _unitOfWork.Asignatures.Find(query).ToList();
            return Mapper.Map<List<Asignature>, List<AsignatureDto>>(asignatures);
        }

        public List<AsignatureDto> GetAll()
        {
            var asignatures = _unitOfWork.Asignatures.GetAll().ToList();
            return Mapper.Map<List<Asignature>, List<AsignatureDto>>(asignatures);
        }

        public AsignatureDto GetById(int id)
        {
            var asignature = _unitOfWork.Asignatures.GetById(id);
            var asignatureDto = new AsignatureDto();
            if (asignature == null)
            {
                //studentDto.ErrorMessage = "Student not Found";
                return asignatureDto;
            }

            return Mapper.Map<Asignature, AsignatureDto>(asignature);
        }

        public AsignatureDto Update(int id, AsignatureDto item)
        {
            var asignatureOnDB = _unitOfWork.Asignatures.GetById(id);

            if (asignatureOnDB == null)
            {
                //item.ErrorMessage = "StudentNotFound";
                return item;
            }
            asignatureOnDB.Name = item.Name;
            asignatureOnDB.Description = item.Description;

            _unitOfWork.Commit();

            return item;
        }
    }
}
