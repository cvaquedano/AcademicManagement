using System.Collections.Generic;
using System.Linq;
using AcademicManagement.Application.DTOs.AcademicPeriod;
using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Entities.AcademicPeriods;

namespace AcademicManagement.Application.Services.AcademicPeriod
{
    public class AcademicPeriodAppService : IAcademicPeriodAppService
    {

        private readonly IUnitOfWork _unitOfWork;
     


        public AcademicPeriodAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         
        }
        public AcademicPeriodDto Create(AcademicPeriodDto item)
        {
            var newAcademicPeriodDetail = new List<AcademicPeriodDetail>();

            if (item.AcademicPeriodDetailDto != null)
            {
                foreach (var detail in item.AcademicPeriodDetailDto)
                {
                    var course = _unitOfWork.Courses.GetById(detail.CourseId);
                    if (course!=null)
                    {
                        newAcademicPeriodDetail.Add(new AcademicPeriodDetail(detail.Section,course));
                    }

                }

                //var periodDetail = from detail in item.AcademicPeriodDetailDto
                //select new AcademicPeriodDetail {
                //    AcademicPeriodId =detail.AcademicPeriodId,
                //    CourseId=detail.CourseId,
                //    CourseName=detail.CourseName,
                //    Section=detail.Section
                    
                //};
                //newAcademicPeriodDetail.AddRange(periodDetail);
            }

            var newAcademicPeriod = new Domain.Entities.AcademicPeriods.AcademicPeriod()
            {
                Description=item.Description,
                Name=item.Name,
                StartDate=item.StartDate,
                EndDate=item.EndDate,
                Status=item.Status,
                AcademicPeriodDetail = newAcademicPeriodDetail
            };

            _unitOfWork.AcademicPeriod.Add(newAcademicPeriod);

            _unitOfWork.Commit();

            item.AcademicPeriodId = newAcademicPeriod.AcademicPeriodId;
            return item;
        }

        public AcademicPeriodDto Delete(int id)
        {
            var AcademicPeriod = _unitOfWork.AcademicPeriod.GetById(id);
            var AcademicPeriodDto = new AcademicPeriodDto();

            if (AcademicPeriod == null)
            {
                AcademicPeriodDto.ErrorMessage = "Period not found";
                return AcademicPeriodDto;
            }

            AcademicPeriod.Delete();
          
            _unitOfWork.Commit();
            return AcademicPeriodDto;
        }

        public List<AcademicPeriodDto> Find(string query)
        {
            var academicPeriods = _unitOfWork.AcademicPeriod.Find(query);

            if (academicPeriods == null)
            {
                return null;
            }

            return MapAcademicPeriodEntitiveToDto(academicPeriods);

        }

     
        public List<AcademicPeriodDto> GetAll()
        {
            var academicPeriods = _unitOfWork.AcademicPeriod.GetAll();

            return MapAcademicPeriodEntitiveToDto(academicPeriods);
        }

        public AcademicPeriodDto GetById(int id)
        {
            var academicPeriods = _unitOfWork.AcademicPeriod.GetById(id);

            return MapAcademicPeriodEntitiveToDto(academicPeriods);
        }

        public AcademicPeriodDto Update(int id, AcademicPeriodDto item)
        {
            var AcademicPeriodOnDB = _unitOfWork.AcademicPeriod.GetById(id);

            if (AcademicPeriodOnDB == null)
            {
                item.ErrorMessage = "AcademicPeriod NotFound";
                return item;
            }
            AcademicPeriodOnDB.UpdateAcademicPeriod(item.Name, item.Description,item.StartDate,item.EndDate,item.Status);
            AddAcademicPeriodDetail(AcademicPeriodOnDB, item.AcademicPeriodDetailDto);
            RemoveAcademicPeriodDetail(AcademicPeriodOnDB, item.AcademicPeriodDetailDto);
            _unitOfWork.Commit();

            return item;
        }

        private void RemoveAcademicPeriodDetail(Domain.Entities.AcademicPeriods.AcademicPeriod academicPeriodOnDB, List<AcademicPeriodDetailDto> academicPeriodDetailDto)
        {
            var itemToRemove = academicPeriodOnDB.AcademicPeriodDetail
                .Where(bd => !academicPeriodDetailDto.Any(dto => dto.CourseId == bd.CourseId && dto.Section==bd.Section)).ToList();

            foreach (var item in itemToRemove)
            {
                _unitOfWork.AcademicPeriodDetail.Delete(item);              
            }
        }

        private void AddAcademicPeriodDetail(Domain.Entities.AcademicPeriods.AcademicPeriod academicPeriodOnDB, List<AcademicPeriodDetailDto> academicPeriodDetailDto)
        {
            foreach (var itemDto in academicPeriodDetailDto)
            {
                var course = _unitOfWork.Courses.GetById(itemDto.CourseId);
                if (course != null)
                {
                    var newItemBD = academicPeriodOnDB.AcademicPeriodDetail.FirstOrDefault(t => t.CourseId == itemDto.CourseId && t.Section == itemDto.Section);
                    if (newItemBD == null)
                    {
                        newItemBD = new AcademicPeriodDetail(itemDto.Section, course);
                        academicPeriodOnDB.AcademicPeriodDetail.Add(newItemBD);
                    }
                }               
            }
        }

        private static List<AcademicPeriodDto> MapAcademicPeriodEntitiveToDto(IEnumerable<Domain.Entities.AcademicPeriods.AcademicPeriod> academicPeriods)
        {
            List<AcademicPeriodDto> result = new List<AcademicPeriodDto>();

            foreach (var item in academicPeriods)
            {
                var newItem = new AcademicPeriodDto(item.Name, item.Description, item.StartDate, item.EndDate, item.Status);

                foreach (var detail in item.AcademicPeriodDetail)
                {
                    var newDetail = new AcademicPeriodDetailDto(detail.Section, detail.CourseId, detail.CourseName);
                    newItem.AcademicPeriodDetailDto.Add(newDetail);
                }
                result.Add(newItem);
            }
            return result;
        }

        private static AcademicPeriodDto MapAcademicPeriodEntitiveToDto(Domain.Entities.AcademicPeriods.AcademicPeriod academicPeriods)
        {
            AcademicPeriodDto result = new AcademicPeriodDto();
           
            var newItem = new AcademicPeriodDto(academicPeriods.Name, academicPeriods.Description, academicPeriods.StartDate, academicPeriods.EndDate, academicPeriods.Status);

            foreach (var detail in academicPeriods.AcademicPeriodDetail)
            {
                var newDetail = new AcademicPeriodDetailDto(detail.Section, detail.CourseId, detail.CourseName);
                newItem.AcademicPeriodDetailDto.Add(newDetail);
            }         
          
            return result;
        }

    }
}
