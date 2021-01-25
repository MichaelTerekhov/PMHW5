using System;
using Xunit;
using NotesApp.Tools;

namespace NotesTest
{
    public class NumberGeneratorTest
    {
        [Fact]
        public void GeneratePositiveLong_CheckExceptionWhenLengthIsInCorrect_ExceptionWasThrown()
        {
            //Arrange&Act
            var exception = Record.Exception(() => NumberGenerator.GeneratePositiveLong(228));
            //Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }
        [Fact]
        public void GeneratePositiveLong_CheckNumberWithSpecifiedNumberOfCharacters_ExpectedNumberReceived()
        {
            //Arrange&Act
            int expected = 7;
            var num = NumberGenerator.GeneratePositiveLong(expected);
            int actual = (int)Math.Log10(num) + 1;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
