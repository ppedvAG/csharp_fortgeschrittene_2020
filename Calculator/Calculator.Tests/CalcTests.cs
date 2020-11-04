using System;
using System.Security.AccessControl;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_3_and_6_results_9()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(3, 6);

            //Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(7, 2, 9)]
        [DataRow(0, 0, 0)]
        [DataRow(-5, 12, 7)]
        [DataRow(5, -10, -5)]
        public void Calc_Sum(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(exp, result);
        }


        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }

        [TestMethod]
        public void Calc_IsWeekend()
        {
            Calc calc = new Calc();


            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimStreamReader.AllInstances.ReadLine = sr => "Hallo Welt";

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 11, 2);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 11, 3);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 11, 4);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 11, 5);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 11, 6);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 11, 7);
                Assert.IsTrue(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 11, 8);
                Assert.IsTrue(calc.IsWeekend());
            }

        }
    }
}
