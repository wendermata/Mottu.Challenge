﻿using Domain.Entities;
using Domain.Enums;

namespace UnitTests.Domain.Entity
{
    public class DeliveryManTests
    {
        private readonly IFixture _fixture;

        public DeliveryManTests()
        {
            _fixture = new Fixture();
        }

        [Fact(DisplayName = nameof(ShouldInstantiate))]
        [Trait("Domain", "Category - Aggregates")]
        public void ShouldInstantiate()
        {
            //arrange
            var id = Guid.NewGuid();
            var name = _fixture.Create<string>();
            var document = _fixture.Create<string>();
            var licenseNumber = _fixture.Create<string>();
            var birthDate = _fixture.Create<DateTime>();
            var licenseType = _fixture.Create<LicenseType>();

            //act
            var deliveryMan = new DeliveryMan(id, name, document, birthDate, licenseNumber, licenseType);

            //arrange
            deliveryMan.Id.Should().Be(id);
            deliveryMan.Name.Should().Be(name);
            deliveryMan.Document.Should().Be(document);
            deliveryMan.BirthDate.Should().Be(birthDate);
            deliveryMan.LicenseNumber.Should().Be(licenseNumber);
            deliveryMan.LicenseType.Should().Be(licenseType);
            deliveryMan.CreatedAt.Date.Should().Be(DateTime.Now.Date);

            deliveryMan.LicenseImageUrl.Should().BeNull();
            deliveryMan.UpdatedAt.Should().BeNull();
        }

        [Fact(DisplayName = nameof(ShouldCanRentalReturnsFalse))]
        [Trait("Domain", "Category - Aggregates")]
        public void ShouldCanRentalReturnsFalse()
        {
            //arrange
            var id = Guid.NewGuid();
            var name = _fixture.Create<string>();
            var document = _fixture.Create<string>();
            var licenseNumber = _fixture.Create<string>();
            var birthDate = _fixture.Create<DateTime>();
            var licenseType = LicenseType.B;
            var deliveryMan = new DeliveryMan(id, name, document, birthDate, licenseNumber, licenseType);

            //act
            var result = deliveryMan.CanRental();

            //arrange
            result.Should().BeFalse();
        }

        [Theory(DisplayName = nameof(ShouldCanRentalReturnsTrue))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData(LicenseType.A)]
        [InlineData(LicenseType.AB)]
        public void ShouldCanRentalReturnsTrue(LicenseType licenseType)
        {
            //arrange
            var id = Guid.NewGuid();
            var name = _fixture.Create<string>();
            var document = _fixture.Create<string>();
            var licenseNumber = _fixture.Create<string>();
            var birthDate = _fixture.Create<DateTime>();
            var deliveryMan = new DeliveryMan(id, name, document, birthDate, licenseNumber, licenseType);

            //act
            var result = deliveryMan.CanRental();

            //arrange
            result.Should().BeTrue();
        }
    }
}
