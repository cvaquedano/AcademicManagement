using AcademicManagement.Application.DTOs;
using AcademicManagement.Application.Services.Students;
using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Repository;
using AcademicManagement.Host.Controllers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace AcademicManagementTest.Api
{
    [TestClass]
    public class StudentApiTest
    {

        private StudentController _controller;

        private Mock<IStudentAppService> _mockAppService;
        private Mock<IStudentRepository> _mockStudentRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;



        [TestInitialize]
        public void Initialize()
        {

            Student student = null; ;

            _mockAppService = new Mock<IStudentAppService>();
            
            _mockStudentRepository = new Mock<IStudentRepository>();

            _mockStudentRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(student);

            _mockStudentRepository.Setup(r => r.Delete(student));

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(u => u.Commit());

            _mockUnitOfWork.SetupGet(u => u.Students).Returns(_mockStudentRepository.Object);


           // _mockAppService.Setup(t => t.Delete(It.IsAny<int>())).Returns(dto);

           // _controller = new StudentController(_mockAppService.Object);
            _controller = new StudentController(new StudentAppService(_mockUnitOfWork.Object));

        }

       
        [TestMethod]
        public void Delete_NoExistentId_ShouldReturnAlgo()
        {
            OkNegotiatedContentResult<StudentDto> result = _controller.Delete(0) as OkNegotiatedContentResult<StudentDto>;

            StudentDto student = result.Content;

            student.Should().Be(null);

           // result.Should().BeOfType<NotFoundResult>();
        }
    }
}
