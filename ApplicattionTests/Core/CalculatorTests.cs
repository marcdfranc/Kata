using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applicattion.Core.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void CalculeTest()
        {
            decimal valor = Calculator.Calcule(8, 15, "3x40");
            Assert.IsTrue(valor == 110);
        }

        [TestMethod()]
        public void CalculeTestNoPromotionQuantity()
        {
            decimal valor = Calculator.Calcule(2, 15, "3x40");
            Assert.IsTrue(valor == 30);
        }

        [TestMethod()]
        public void CalculeTestDiscount()
        {
            decimal valor = Calculator.Calcule(5, 55, "2x-25");
            Assert.IsTrue(valor == 137.5M);
        }

        [TestMethod()]
        public void CalculeTestDiscountNoQuantity()
        {
            decimal valor = Calculator.Calcule(1, 55, "2x-25");
            Assert.IsTrue(valor == 55);
        }

        [TestMethod()]
        public void CalculeTestDiscountNullType()
        {
            decimal valor = Calculator.Calcule(3, 10, null);
            Assert.IsTrue(valor == 30);
        }
    }
}