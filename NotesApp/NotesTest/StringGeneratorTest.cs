using System;
using Xunit;
using NotesApp.Tools;

namespace NotesTest
{
    public class StringGeneratorTest
    {
        [Fact]
        public void GenerateNumbersString_CheckIfItReturnsAnEmptyStringWithLengthZero_StringIsEmpty()
        {
            //Arrange&Act
            var testString = StringGenerator.GenerateNumbersString(0, false);
            //Assert
            Assert.True(String.IsNullOrEmpty(testString));
        }
        [Fact]
        public void GenerateNumbersString_CheckExceptionWhenLengthIsInCorrect_ExceptionWasThrown()
        {
            //Arrange&Act
            var exception = Record.Exception(() => StringGenerator.GenerateNumbersString(-5, true));
            //Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }
        [Fact]
        public void GenerateNumbersString_CheckForZeroAtTheBeginningOfString_ZeroWasDetected()
        {
            //Arrange&Act
            var actualString = StringGenerator.GenerateNumbersString(15, false);
            var expected = actualString[0] != 0;
            //Assert
            Assert.True(expected);
        }
        [Fact]
        public void GenerateNumbersString_CheckStringWithSpecifiedNumberOfCharacters_ExpectedNumberReceived()
        {
            //Arrange&Act
            var testString = StringGenerator.GenerateNumbersString(20, true);
            var expectedLength = testString.Length;
            //Assert
            Assert.Equal(20, expectedLength);
        }
        [Fact]
        public void GenerateNumbersString_CheckIfStringCanBeConvertedToNumericType_StringIsConvertedToNumber()
        {
            //Arrange&Act
            var testString = StringGenerator.GenerateNumbersString(14, true);
            //Assert
            Assert.True(long.TryParse(testString, out _));
        }
    }
}
