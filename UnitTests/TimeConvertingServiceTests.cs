using System;
using FluentAssertions;
using Logic.Services;
using Xunit;

namespace UnitTests
{
    public class TimeConvertingServiceTests : TimeConvertingService
    {
        [Theory()]
        [InlineData("00:00")]
        [InlineData("23:59")]
        public void Validate_IfTimeArgumentIsCorrect_ShouldReturnTrue(string time)
        {
            // Arrange

            // Act
            var result = Validate(time);

            // Assert
            result.Success.Should().BeTrue();
        }

        [Theory()]
        [InlineData("25:00")]
        [InlineData("-1:00")]
        [InlineData("12:60")]
        [InlineData("asd")]
        [InlineData("12-12")]
        [InlineData("12:120")]
        public void Validate_IfTimeHasWrongFormat_ShouldReturnFalse(string time)
        {
            // Arrange

            // Act
            var result = Validate(time);

            // Assert
            result.Success.Should().BeFalse();
        }
    }
}
