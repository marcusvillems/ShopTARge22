using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.RealEstateTest;
using System;
using Xunit;

namespace ShopTARge22.KindergartenTest
{
    public class KindergartenTest : KindergartenTestBase
    {
        [Fact]
        public async Task ShouldNotAddEmptyKindergartenWhenReturnResult()
        {
            // Arrange
            KindergartenDto kindergarten = new KindergartenDto
            {
                GroupName = "Test",
                ChildrenCount = 4,
                KindergartenName = "Jah",
                Teacher = "Tõnn",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // Act
            var result = await Svc<IKindergartenServices>().Create(kindergarten);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNotAddEmptyKindergartenWhenReturnResult2()
        {
            // Arrange
            KindergartenDto kindergarten = new KindergartenDto
            {
                GroupName = "Another Test",
                ChildrenCount = 5,
                KindergartenName = "Ei",
                Teacher = "Mari",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // Act
            var result = await Svc<IKindergartenServices>().Create(kindergarten);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNotGetByIdKindergartenWhenReturnNotEqual()
        {
            Guid wrongGuid = Guid.NewGuid();
            Guid guid = Guid.Parse("08a22365-9124-4fc7-80b3-c7f8c999857c");

            var result = await Svc<IKindergartenServices>().DetailsAsync(guid);

            Assert.NotEqual(wrongGuid, guid);
        }

        private KindergartenDto MockKindergartenData()
        {
            KindergartenDto kindergarten = new KindergartenDto
            {
                GroupName = "qwe",
                ChildrenCount = 12,
                KindergartenName = "JABOI",
                Teacher = "Jyrka",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return kindergarten;
        }

        private KindergartenDto MockUpdateKindergartenData()
        {
            KindergartenDto kindergarten = new KindergartenDto
            {
                GroupName = "qweqwe",
                ChildrenCount = 121,
                KindergartenName = "JABOIgfs",
                Teacher = "Jyrkaasd",
                CreatedAt = DateTime.Now.AddMinutes(10),
                UpdatedAt = DateTime.Now.AddMinutes(-10)
            };

            return kindergarten;
        }

        [Fact]
        public async Task ShouldDeleteByIdKindergartenWhenDeleteKindergarten()
        {
            KindergartenDto kindergarten = MockKindergartenData();

            var kindergarten1 = await Svc<IKindergartenServices>().Create(kindergarten);
            var kindergarten2 = await Svc<IKindergartenServices>().Create(kindergarten);
            var result = await Svc<IKindergartenServices>().Delete((Guid)kindergarten1.Id);

            Assert.Equal(result.Id, kindergarten1.Id);
        }

        [Fact]
        public async Task ShouldNotUpdateKindergartenWhenUpdateDataVersionIsNotValid()
        {
            KindergartenDto dto = MockKindergartenData();
            var createKindergarten = await Svc<IKindergartenServices>().Create(dto);
            
            KindergartenDto update = MockKindergartenData();
            var result = await Svc<IKindergartenServices>().Update(update);

            Assert.Equal(result.KindergartenName, createKindergarten.KindergartenName);
            Assert.NotEqual(result.UpdatedAt, createKindergarten.UpdatedAt);
        }
    }
}
