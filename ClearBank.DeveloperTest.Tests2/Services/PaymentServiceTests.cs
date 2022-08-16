using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using Moq;
using NUnit.Framework;
using ClearBank.DeveloperTest.Tests;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PrintServiceTests
    {
        private PaymentService _paymentService;
       // private Mock<ICalculator> _calculatorMock = new Mock<ICalculator>();
       // private Mock<StreamWriter> _streamWriterMock = new Mock<StreamWriter>("output.txt");

        [Test]
        public void When_PrintToFile_Called_Then_StreamWriterWriteLine_Called()
        {
            List<string> inMemoryDocument = new List<string> { "1", "2" };
            _paymentService = new PaymentService();

            _paymentService.MakePayment(new MakePaymentRequest());

            //printService.PrintToFile(inMemoryDocument, _streamWriterMock.Object);

            //_streamWriterMock.Verify(x => x.WriteLine("1"), Times.Once);
            //_streamWriterMock.Verify(x => x.WriteLine("2"), Times.Once);
        }


    }
}
