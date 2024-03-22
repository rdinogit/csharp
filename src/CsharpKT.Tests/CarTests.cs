using CsharpKT.UnitTestsModels;
using FluentAssertions;
using FluentAssertions.Extensions;
using NSubstitute;

namespace CsharpKT.Tests
{
    public class CarTests
    {
        [Fact]
        public void CreateNewCar_GivenANonEmptyEngineTypeAndColorRed_CarShouldBeCreatedWithProvidedColorRedAndEngineType()
        {
            // Arrange
            var color = CarColor.Red;
            var engineType = "V6";

            // Act
            var result = Car.CreateNewCar(color, engineType, 1.January(2000));

            // Assert
            result.EngineType.Should().Be(engineType);
            result.Color.Should().Be(color);
            result.Passengers.Should().BeEmpty();
        }

        [Fact]
        public void AddPassenger_GivenANewPassenger_PassengerShouldBeAdded()
        {
            // Arrange
            var passenger = "Ruben";
            var car = Car.CreateNewCar(CarColor.Red, "undefined", 1.January(2000));

            // Act
            car.AddPassenger(passenger);

            // Assert
            car.Passengers.Should().Contain(passenger);
        }

        [Fact]
        public void AddPassenger_GivenAInvalidPassenger_ThrowsArgumentNullException()
        {
            // Arrange
            var passenger = "";
            var car = Car.CreateNewCar(CarColor.Red, "undefined", 1.January(2000));

            // Act
            var act = () => car.AddPassenger(passenger);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("V8")]
        [InlineData("V12")]
        [InlineData("anything")]
        public void CreateNewCar_GivenANonEmptyEngine_CarShouldBeCreatedWithProvidedEngineType(string engineType)
        {
            // Act
            var result = Car.CreateNewCar(CarColor.Red, engineType, 1.January(2000));

            // Assert
            result.EngineType.Should().Be(engineType);
            result.Passengers.Should().BeEmpty();
        }

        [Fact]
        public void CreateNewCar_GivenValidInputs_ProductionDateShouldBeAssigned()
        {
            // Arrange
            var productionDate = 1.January(2000);
            // Act
            var result = Car.CreateNewCar(CarColor.Red, "irrelevant", productionDate);
            // Assert
            result.ProductionDate.Should().Be(productionDate);
        }

        [Fact]
        public void CreateNewCar_GivenValidInputsAndDateTimeProvider_ProductionDateShouldBeAssigned()
        {
            // Arrange
            var productionDate = 1.January(2000);

            var dateTimeProvider = Substitute.For<IDateTimeProvider>();
            dateTimeProvider.Now.Returns(productionDate);

            // Act
            var result = Car.CreateNewCar(CarColor.Red, "irrelevant", dateTimeProvider);

            // Assert
            result.ProductionDate.Should().Be(productionDate);
        }
    }
}