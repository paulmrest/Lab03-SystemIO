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

        //Challenge 4
        [Fact]
        public void AllValuesInArraySame()
        {
            //Arrange
            int[] input = new int[] { 3, 3, 3, 3, 3, 3 };
            //Act
            int result = FindMostCommon(input);
            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void NoDuplicatesInArray()
        {
            //Arrange
            int[] input = new int[] { 1, 3, 5, 7, 9 };
            //Act
            int result = FindMostCommon(input);
            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void MultipleValuesWithSameFrequency()
        {
            //Arrange
            int[] input = new int[] { 5, 7, 5, 1, 2, 7 };
            //Act
            int result = FindMostCommon(input);
            //Assert
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(new int[] { 5, 12, 6, 12, 5, 7, 14, 9, 5}, 5)]
        [InlineData(new int[] { 43, 3, 19, 4, 19 }, 19)]
        [InlineData(new int[] { 6, 5, 9, 5, 9, 4, 6, 23, 9, 7, 9 }, 9)]
        public void FindMostCommonTest(int[] input, int expected)
        {
            int result = FindMostCommon(input);
            Assert.Equal(expected, result);
        }
    }
}
