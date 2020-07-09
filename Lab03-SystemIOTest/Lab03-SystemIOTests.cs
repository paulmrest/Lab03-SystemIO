using System;
using Xunit;
using static Lab03_SystemIO.Program;

namespace Lab03_SystemIOTest
{
    public class UnitTest1
    {
        //Challenge 1
        [Fact]
        public void ForStringOfLessThanThreeWordsReturnsZero()
        {
            //Arrange
            string input = "heavy book";
            //Act
            int result = ThreeNumbersProduct(input);
            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ForStringOfThreeNonNumbersReturnsOne()
        {
            //Arrange
            string input = "heavy book on the shelf";
            //Act
            int result = ThreeNumbersProduct(input);
            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void ForStringOfMoreThanThreeNumbersReturnsProductOfFirstThree()
        {
            //Arrange
            string input = "4 3 6 7 5";
            //Act
            int result = ThreeNumbersProduct(input);
            //Assert
            Assert.Equal(72, result);
        }

        [Fact]
        public void CanHandleMultipleSpacesBetweenNumbers()
        {
            //Arrange
            string input = "4             3  6     7        5";
            //Act
            int result = ThreeNumbersProduct(input);
            //Assert
            Assert.Equal(72, result);
        }

        [Theory]
        [InlineData("-6 -4 -3", -72)]
        [InlineData("nope 4 maybe 5", 4)]
        [InlineData("4 3 swish", 12)]
        public void ThreeNumbersProductTest(string input, int expected)
        {
            int result = ThreeNumbersProduct(input);
            Assert.Equal(expected, result);
        }

        //Challenge 2
        [Theory]
        [InlineData(new int[] { 2, 6, 7 }, 5)]
        [InlineData(new int[] { 12, 9, 1, 4, 25, 8, 16}, 10)]
        public void TestAverageArray(int[] input, int expected)
        {
            int result = AverageArray(input);
            Assert.Equal(expected, result);
        }
    }
}
