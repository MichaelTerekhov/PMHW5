using System;
using Xunit;
using NotesApp.Tools;

namespace NotesTest
{
    public class ShortGuidTest
    {
        [Fact]
        public void ToShortIdFromShortId_CheckTheCorrectnessOfTheGuidConversion_ConversionIsCorrect()
        {
            //Arrange&Act
            var testGuidExpected = Guid.NewGuid();

            var shortGuid = testGuidExpected.ToShortId();

            var testGuidActual = shortGuid.FromShortId();
            //Assert
            Assert.Equal(testGuidExpected, testGuidActual);
        }
        [Fact]
        public void ToShortIdFromShortId_CheckTheCorrectnessOfTheGuidFromShordIdParsing_ParsingIsCorrect()
        {
            //Arrange&Act
            var testGuidExpected = Guid.NewGuid();

            var shortGuid = testGuidExpected.ToShortId() + "==";

            var testGuidActual = shortGuid.FromShortId();
            //Assert
            Assert.Equal(testGuidExpected, testGuidActual);
        }
        [Fact]
        public void FromShortId_CheckStringRepresentationGuidToRealGuidConversion_ConversiontoGuidTypeIsCorrect()
        {
            //Arrange&Act
            var expetedGuid = Guid.NewGuid();
            
            var stringGuid = expetedGuid.ToString();

            var actualGuid = stringGuid.FromShortId();
            //Assert
            Assert.Equal(expetedGuid, actualGuid);
        }
        [Fact]
        public void FromShortId_CheckExceptionWhenGuidIsInCorrect_ExceptionWasThrown()
        {
            //Arrange&Act
            var testStringGuid = Guid.NewGuid().ToString() + "qwerty1337";

            var exception = Record.Exception(() => testStringGuid.FromShortId());
            //Assert
            Assert.IsType<FormatException>(exception);
        }
        [Fact]
        public void FromShortId_CheckForNullIfNullArgumentIsPassedNull_ReturnedNull()
        {
            //Arrange&Act
            string expectedGuid = null;
            //Assert
            Assert.Null(expectedGuid.FromShortId());
        }
    }
}
