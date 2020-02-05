using System;
using NUnit.Framework;
using Jenkins;

namespace NUnitTestProject
{
    [TestFixture]
        public class UnitTestCalculatorMethods
        {
            private CalculatorMethods uut;

            [SetUp]
            public void Setup()
            {
                uut = new CalculatorMethods();
            }

            [TestCase(3.75, 4.26, 8.01)]
            [TestCase(3.75, -3.75, 0)]
            [TestCase(-3.75, -4.26, -8.01)]
            public void UnitTestAdd(double a, double b, double result)
            {
                Assert.AreEqual(uut.Add(a, b), result, 0.0001);
                // AreEqual er en classic assert model, hvorimod That.(uut.Add(a,b) == result) er constraint-based model
                // Assert.That(uut.Add(a, b), Is.EqualTo(result).Within(0.0001));
                // Løst med en constraint-based model
            }

            [TestCase(3.75, 4.26, -0.51)]
            [TestCase(3.75, -3.75, 7.50)]
            [TestCase(-3.75, -4.26, 0.51)]
            public void UnitTestSubtract(double a, double b, double result)
            {
                Assert.AreEqual(uut.Subtract(a, b), result, 0.0001);
            }

            [TestCase(3.75, 4.26, 15.975)]
            [TestCase(3.75, -3.75, -14.0625)]
            [TestCase(-3.75, -4.26, 15.975)]
            public void UnitTestMultiply(double a, double b, double result)
            {
                Assert.AreEqual(uut.Multiply(a, b), result, 0.0001);
            }

            [TestCase(3.75, 4, 197.7539)]
            [TestCase(3.75, -4, 0.00506)]
            [TestCase(-3.75, -4, 0.00506)]
            public void UnitTestPower(double a, int exp, double result)
            {
                Assert.AreEqual(uut.Power(a, exp), result, 0.0001);
            }

            [TestCase(1.75, 2.25, 0.7777)]
            [TestCase(-2, 4, -0.5)]
            [TestCase(6285, 326, 19.2791)]
            [TestCase(0, 2, 0.0)]
            [TestCase(2, 0, 0.0)]
            public void UnitTestDivide(double a, double b, double result)
            {
                Assert.AreEqual(uut.Divide(a, b), result, 0.0001);
            }

            [Test]
            public void UnitTestAccumulatorProperty_IsEmpty()
            {
                Assert.That(uut.Accumulator == 0);
            }

            [TestCase(1, 2, 3)]
            public void UnitTestAccumulator_Add(double a, double b, double result)
            {
                uut.Add(a, b);
                Assert.AreEqual((uut.Accumulator), result, 0.0001);
            }

            [TestCase(1, 2, 3)]
            public void UnitTestAccumulator_Add_Twice(double a, double b, double result)
            {
                uut.Add(100, 100);
                uut.Add(a, b);
                Assert.AreEqual((uut.Accumulator), result, 0.0001);
            }

            [TestCase(1, 2, 3, 100, 100)]
            [TestCase(1, 2, 3, 0, 100)]
            [TestCase(1, 2, 3, 100, 0)]
            public void UnitTestAccumulator_Add_DivideFirst(double a, double b, double result, double dividend, double divisor)
            {
                uut.Divide(dividend, divisor);
                uut.Add(a, b);
                Assert.AreEqual((uut.Accumulator), result, 0.0001);
            }

            [TestCase(3.75, 4.26, 8.01)]
            [TestCase(3.75, -3.75, 0)]
            [TestCase(-3.75, -4.26, -8.01)]
            public void UnitTestClear(double a, double b, double result)
            {
                uut.Add(a, b);
                Assert.AreEqual(uut.Accumulator, result, 0.01);

                uut.Clear();
                Assert.AreEqual(uut.Accumulator, 0);
            }

            [TestCase(3.75, 4.26, 8.01)]

            public void UnitTestAddWithAccumulator(double a, double b, double result)
            {
                uut.Add(a, b);

                Assert.AreEqual(uut.AddToAccumulator(b), result + b, 0.001);
            }

            [TestCase(3.75, 4.26, -0.51)]

            public void UnitTestSubtractFromAccumulator(double a, double b, double result)
            {
                uut.Subtract(a, b);

                Assert.AreEqual(uut.SubtractFromAccumulator(a), result - a, 0.0001);
            }

            [TestCase(3.75, 4.26, 15.975)]
            public void UnitTestMultiplyWithAccumulator(double a, double b, double result)
            {
                uut.Multiply(a, b);

                Assert.AreEqual(uut.MultiplyWithAccumulator(a), result * a, 0.0001);
            }

            [TestCase(3.75, 4, 197.7539)]
            public void UnitTestPowerToAccumulator(double a, int exp, double result)
            {
                uut.Power(a, exp);

                //Denne metode er testet ved at finde hvad resultatet er vha. en lommeregner...
                Assert.AreEqual(uut.PowerToAccumulator(exp), 1529326745.2420878, 0.0001);
            }

            [TestCase(1.75, 2.25, 0.7777)]
            public void UnitTestDivideAccumulatorWith(double a, double b, double result)
            {
                uut.Divide(a, b);

                Assert.AreEqual(uut.DivideAccumulatorWith(a), result / a, 0.0001);
            }





            //HVAD ER DETTE??

            //[TestCase(1, 2, 3)]
            //public void UnitTestAccumulator_Add(double a, double b, double result)
            //{
            //    uut.Add(a, b);
            //    Assert.AreEqual((uut.Accumulator), result, 0.0001);
            //}

            //[TestCase(1, 2, 3)]
            //public void UnitTestAccumulator_Add_Twice(double a, double b, double result)
            //{
            //    uut.Add(100, 100);
            //    uut.Add(a, b);
            //    Assert.AreEqual((uut.Accumulator), result, 0.0001);
            //}

            //[TestCase(1, 2, 3, 100, 100)]
            //[TestCase(1, 2, 3, 0, 100)]
            //[TestCase(1, 2, 3, 100, 0)]
            //public void UnitTestAccumulator_Add_DivideFirst(double a, double b, double result, double dividend, double divisor)
            //{
            //    uut.Divide(dividend, divisor);
            //    uut.Add(a, b);
            //    Assert.AreEqual((uut.Accumulator), result, 0.0001);
            //}
        }
    }
