using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ASEUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Test to see if the system correctly set string to lowercase
        [TestMethod]
        public void TestLowerCase()
        {

        }

        //Test to see if the system correctly set string to lowercase *suppose to fail*
        [TestMethod]
        public void TestUpperCase()
        {

        }

        //Test to see if the system correctly removes the spaces from a string
        [TestMethod]
        public void TestRemovedSpaces()
        {

        }

        //Test to see if the system correctly splits the string
        [TestMethod]
        public void TestSplitter()
        {

        }

        //Test to see if the system correctly converts string to int
        [TestMethod]
        public void TestInt()
        {

        }

        int testRadiusInput1 = 0;
        int testRadiusInput2 = 0;
        int testRadiusOutput1 = 0;
        public void TestRadiusAddition()
        {
            testRadiusInput1 = 2;
            testRadiusInput2 = 3;
            testRadiusOutput1 = 5;

            if ((testRadiusInput1 * testRadiusInput2).Equals(testRadiusOutput1))
                return "Pass";
            else
                return "Failed";
        }

        public void TestRadiusSubtraction()
        {
            testRadiusInput1 = 2;
            testRadiusInput2 = 3;
            testRadiusOutput1 = 1;

            if ((testRadiusInput2 * testRadiusInput1).Equals(testRadiusOutput1))
                return "Pass";
            else
                return "Failed";
        }

        public void TestRadiusMultiplication()
        {
            testRadiusInput1 = 2;
            testRadiusInput2 = 3;
            testRadiusOutput1 = 6;

            if ((testRadiusInput1 * testRadiusInput2).Equals(testRadiusOutput1))
                return "Pass";
            else
                return "Failed";
        }

        int testWidthInput1 = 0;
        int testWidthInput2 = 0;
        int testWidthOutput1 = 0;
        public void TestWidthAddition()
        {
            testWidthInput1 = 2;
            testWidthInput2 = 3;
            testWidthOutput1 = 5;

            if ((testWidthInput1 * testWidthInput2).Equals(testWidthOutput1))
                return "Pass";
            else
                return "Failed";
        }

        public void TestWidthSubtraction()
        {
            testWidthInput1 = 2;
            testWidthInput2 = 3;
            testWidthOutput1 = 1;

            if ((testWidthInput2 * testWidthInput1).Equals(testWidthOutput))
                return "Pass";
            else
                return "Failed";
        }

        public void TestWidthMultiplication()
        {
            testWidthInput1 = 2;
            testWidthInput2 = 3;
            testWidthOutput = 6;

            if ((testWidthInput1 * testWidthInput2).Equals(testWidthOutput))
                return "Pass";
            else
                return "Failed";
        }

        int testHeightInput1 = 0;
        int testHeightInput2 = 0;
        int testHeightOutput1 = 0;
        public void TestHeightAddition()
        {
            testHeightInput1 = 2;
            testHeightInput2 = 3;
            testHeightOutput1 = 5;

            if ((testHeightInput1 * testHeightInput2).Equals(testHeightOutput1))
                return "Pass";
            else
                return "Failed";
        }

        public void TestHeightSubtraction()
        {
            testHeightInput1 = 2;
            testHeightInput2 = 3;
            testHeightOutput1 = 1;

            if ((testHeightInput2 * testHeightInput1).Equals(testHeightOutput1))
                return "Pass";
            else
                return "Failed";
        }

        public void TestHeightMultiplication()
        {
            testHeightInput1 = 2;
            testHeightInput2 = 3;
            testHeightOutput1 = 6;

            if ((testHeightInput1 * testHeightInput2).Equals(testHeightOutput1))
                return "Pass";
            else
                return "Failed";
        }
    }
}
