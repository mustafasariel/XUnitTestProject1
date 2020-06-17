using Moq;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class AmountServiceTest
    {
        Moq.Mock<ILogger> _mockLogger;
        Mock<IInflationRate> _mockRate;
        AmountService _amountService;
        public AmountServiceTest()
        {
            _mockLogger = new Mock<ILogger>(MockBehavior.Loose);
            _mockRate = new Mock<IInflationRate>();
            _amountService = new AmountService(_mockRate.Object, _mockLogger.Object);
        }
        [Fact]
        public void GetAmountByYear_WhenInvalidYear_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _amountService.GetAmountByYear(100, 0));
        }

        [Fact]
        public void GetAmountByYear_WhenInvalidAmount_ThrowArgumentException()
        {
            Assert.Throws<Exception>(() => _amountService.GetAmountByYear(-1, 2020));
        }
        [Theory]
        [InlineData(2020,0.5,1000,1500)]
        public void GetAmountByYear_WhenValidYearAndAmount_ReturnValidAmount(int year,double rate,
            double amount,double expectedAmount)
        {
            // arrenge
            _mockRate.Setup(x => x.GetRateByYear(year)).Returns(rate);


            // act
            double actualAmount = _amountService.GetAmountByYear(amount, year);


            //assert
            Assert.Equal(expectedAmount, actualAmount);
        }



    }
}
