using Airways.Application.Models;
using Airways.Application.Models.Aircraft;
using Airways.Application.Models.Airline;
using Airways.Application.Models.Clas;
using Airways.Application.Services.Impl;
using Airways.Core.Entities;
using Airways.DataAccess.Repository;
using AutoMapper;
using Moq;
using System.Linq.Expressions;

namespace TestProject1
{
    public class AirwaysTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IAirlineRepository> _airlineRepositoryMock;
        private readonly AirlineService _airlineService;

        private readonly Mock<IClassRepository> _classRepositoryMock;
        private readonly ClasService _clasServiceMock;

        private readonly Mock<IAircraftRepository> _aircraftRepositoryMock;
        private readonly AircraftService _aircraftServiceMock;

        public AirwaysTest()
        {
            _mapperMock = new Mock<IMapper>();
            _airlineRepositoryMock = new Mock<IAirlineRepository>();
            _airlineService = new AirlineService(_airlineRepositoryMock.Object, _mapperMock.Object);

            _classRepositoryMock = new Mock<IClassRepository>();
            _clasServiceMock = new ClasService(_classRepositoryMock.Object, _mapperMock.Object);

            _aircraftRepositoryMock = new Mock<IAircraftRepository>();
            _aircraftServiceMock = new AircraftService(_aircraftRepositoryMock.Object, _mapperMock.Object);
        }




        //--1
        [Fact]
        public async Task airlineDeleteAsync_Test()
        {

            var id = Guid.NewGuid();
            var airline = new Airline { Id = id };
            var responseModel = new BaseResponceModel { Id = id };

            _airlineRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Airline, bool>>>()))
                .ReturnsAsync(airline);

            _airlineRepositoryMock
                .Setup(repo => repo.DeleteAsync(It.IsAny<Airline>()))
                .ReturnsAsync(airline);


            var result = await _airlineService.DeleteAsync(id);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        //--2
        [Fact]
        public async Task airlineUpdateAsync_Test()
        {

            var id = Guid.NewGuid();
            var airline = new Airline { Id = id };
            var responseModel = new BaseResponceModel { Id = id };
            string name = "name";
            var code = Guid.NewGuid();
            string country = "country";
            var airlineUpdateModel = new AirlineUpdateModel { Name = name, Code = code, Country = country };

            _airlineRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Airline, bool>>>()))
                .ReturnsAsync(airline);

            _airlineRepositoryMock
                .Setup(repo => repo.UpdateAsync(It.IsAny<Airline>()))
                .ReturnsAsync(airline);


            var result = await _airlineService.UpdateAsync(id, airlineUpdateModel);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        //--3
        [Fact]
        public async Task airlineAddAsync_Test()
        {

            var id = Guid.NewGuid();
            var airline = new Airline { Id = id };
            string name = "name";
            var code = Guid.NewGuid();
            string country = "country";
            var airlineCreateModel = new AirlineCreateModel { Name = name, Code = code, Country = country };

            _airlineRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Airline, bool>>>()))
                .ReturnsAsync(airline);

            _airlineRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Airline>()))
                .ReturnsAsync(airline);


            var result = await _airlineService.CreateAsync(airlineCreateModel);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        //--4
        [Fact]
        public async Task airlineGetAllAsync_Test()
        {
            var airlineEntities = new List<Airline>
            {
                new Airline { Id = Guid.NewGuid(), Name = "Airline A" },
                new Airline { Id = Guid.NewGuid(), Name = "Airline B" },

            };

            _airlineRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(airlineEntities);


            Assert.NotNull(airlineEntities);

        }

        //--5
        [Fact]
        public async Task classDeleteAsync_Test()
        {

            var id = Guid.NewGuid();
            var clas = new Class { Id = id };
            var responseModel = new BaseResponceModel { Id = id };

            _classRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Class, bool>>>()))
                .ReturnsAsync(clas);

            _classRepositoryMock
                .Setup(repo => repo.DeleteAsync(It.IsAny<Class>()))
                .ReturnsAsync(clas);


            var result = await _clasServiceMock.DeleteAsync(id);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        //--6
        [Fact]
        public async Task classUpdateAsync_Test()
        {

            var id = Guid.NewGuid();
            var clas = new Class { Id = id };
            var responseModel = new BaseResponceModel { Id = id };
            var className = ClassType.Economy;
            string description = "country";
            var classUpdateModel = new ClassUpdateModel { className = className, description = description };

            _classRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Class, bool>>>()))
                .ReturnsAsync(clas);

            _classRepositoryMock
                .Setup(repo => repo.UpdateAsync(It.IsAny<Class>()))
                .ReturnsAsync(clas);


            var result = await _clasServiceMock.UpdateAsync(id, classUpdateModel);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        //--7
        [Fact]
        public async Task classAddAsync_Test()
        {

            var id = Guid.NewGuid();
            var clas = new Class { Id = id };
            var responseModel = new BaseResponceModel { Id = id };
            var className = ClassType.Economy;
            string description = "country";
            var classCreateModel = new ClassCreateModel { className = className, description = description };

            _classRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Class, bool>>>()))
                .ReturnsAsync(clas);

            _classRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Class>()))
                .ReturnsAsync(clas);


            var result = await _clasServiceMock.CreateAsync(classCreateModel);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        //--8
        [Fact]
        public async Task classGetAllAsync_Test()
        {
            var clas = new List<Class>
            {
                new Class { description = "Airline A" },
                new Class { description = "Airline B" }

            };

            _classRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(clas);


            Assert.NotNull(clas);

        }

        //--9
        [Fact]
        public async Task aircraftGetAllAsync_Test()
        {
            var aircraft = new List<Aircraft>
            {
                new Aircraft { Name = "name"}
            };

            _aircraftRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(aircraft);


            Assert.NotNull(aircraft);

        }

        //--10
        [Fact]
        public async Task aircraftDeleteAsync_Test()
        {

            var id = Guid.NewGuid();
            var aircraft = new Aircraft { Id = id };
            var responseModel = new BaseResponceModel { Id = id };

            _aircraftRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Aircraft, bool>>>()))
                .ReturnsAsync(aircraft);

            _aircraftRepositoryMock
                .Setup(repo => repo.DeleteAsync(It.IsAny<Aircraft>()))
                .ReturnsAsync(aircraft);


            var result = await _aircraftServiceMock.DeleteAsync(id);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        //--11
        [Fact]
        public async Task aircraftAddAsync_Test()
        {

            var id = Guid.NewGuid();
            var aircraft = new Aircraft { Id = id };
            var responseModel = new BaseResponceModel { Id = id };
            var name = "name";
            var aircraftCreateModel = new AircraftCreateModel { Name = name };

            _aircraftRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Aircraft, bool>>>()))
                .ReturnsAsync(aircraft);

            _aircraftRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Aircraft>()))
                .ReturnsAsync(aircraft);


            var result = await _aircraftServiceMock.CreateAsync(aircraftCreateModel);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        //--12
        [Fact]
        public async Task aircraftUpdateAsync_Test()
        {

            var id = Guid.NewGuid();
            var aircraft = new Aircraft { Id = id };
            var responseModel = new BaseResponceModel { Id = id };
            var name = "name";
            var aircraftUpdateModel = new AircraftUpdateModel { Name = name };

            _aircraftRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Aircraft, bool>>>()))
                .ReturnsAsync(aircraft);

            _aircraftRepositoryMock
                .Setup(repo => repo.UpdateAsync(It.IsAny<Aircraft>()))
                .ReturnsAsync(aircraft);


            var result = await _aircraftServiceMock.UpdateAsync(id, aircraftUpdateModel);


            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }


        public void Test1()
        {

        }
    }
}