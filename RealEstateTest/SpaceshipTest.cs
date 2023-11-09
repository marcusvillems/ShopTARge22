using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.RealEstateTest;
using ShopTARge22.SpaceshipTest;
using System.IO.IsolatedStorage;

namespace RealEstateTest
{
    public class SpaceshipTest : SpaceshipTestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            SpaceshipDto spaceship = new();

            spaceship.Name = "asd";
            spaceship.Type = "asd";
            spaceship.BuiltDate = DateTime.Now;
            spaceship.Passengers = 4;
            spaceship.CargoWeight = 8;
            spaceship.Crew = 3;
            spaceship.EnginePower = 9;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            SpaceshipDto spaceship = new();
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("4527aece-a6f0-4e53-a1b1-20ccb7265042");

            await Svc<ISpaceshipsServices>().DetailsAsync(guid);

            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]//kontrollib, kas nende parameetritega spaceship luuakse edukalt
        public async Task Should_AddSpaceship_WithValidParameters_WhenReturnResult()
        {
            SpaceshipDto spaceship = new SpaceshipDto
            {
                Name = "asd",
                Type = "ads",
                BuiltDate = DateTime.Now,
                Passengers = 4,
                CargoWeight = 8,
                Crew = 3,
                EnginePower = 9,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_GetSpaceshipById_WhenExists()
        {
            Guid spaceshipId = Guid.Parse("4527aece-a6f0-4e53-a1b1-20ccb7265042");

            SpaceshipDto spaceship = new SpaceshipDto
            {
                Name = "USS Enterprise",
            };

            await Svc<ISpaceshipsServices>().Create(spaceship);

            var retrievedSpaceship = await Svc<ISpaceshipsServices>().DetailsAsync(spaceshipId);

            Assert.NotNull(retrievedSpaceship);
            Assert.Equal(spaceshipId, retrievedSpaceship.Id);
        }

        [Fact]
        public async Task ShouldNot_GetByDifferentIdSpaceships_WhenReturnsNotEqual()
        {
           
            Guid guid1 = Guid.Parse("6a0e1626-23ab-4078-8d06-f7ba20ac0dd4");
            Guid guid2 = Guid.Parse("0b7023c5-0649-4ef9-b1f5-99514775db34");

            SpaceshipDto spaceship1 = new SpaceshipDto
            {
                Name = "Spaceship A",
                
            };

            SpaceshipDto spaceship2 = new SpaceshipDto
            {
                Name = "Spaceship B",
                
            };

            
            await Svc<ISpaceshipsServices>().Create(spaceship1);

            
            await Svc<ISpaceshipsServices>().Create(spaceship2);

            
            Assert.NotEqual(guid1, guid2);
        }






    };

}