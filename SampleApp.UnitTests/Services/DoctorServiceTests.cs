using System.Net;
using Moq;
using Moq.Protected;
using SampleApp.Services;

namespace SampleApp.UnitTests.Services
{
    [TestClass]
    public class DoctorServiceTests
    {

        [TestMethod]
        public async Task GetDoctors_ClientFactoryCreateClientIsCalled()
        {
            // Arrange
            var mockFactory = new Mock<IHttpClientFactory>();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest
                });
            

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://test.com"),
            };

            mockFactory.Setup(f => f.CreateClient("DoctorClient")).Returns(client);

            var doctorService = new DoctorService(mockFactory.Object);

            // Act
            var result = await doctorService.GetDoctors();

            // Assert
            mockFactory.Verify(v => v.CreateClient("DoctorClient"), Times.Once);
        }

        [TestMethod]
        public async Task GetDoctors_HttpClientDoesNotReturnSuccess_EmptyListIsReturned()
        {
            // Arrange
            var mockFactory = new Mock<IHttpClientFactory>();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest
                });

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://test.com")
            };

            mockFactory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

            var doctorService = new DoctorService(mockFactory.Object);

            // Act
            var result = await doctorService.GetDoctors();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task GetDoctors_NoDoctorsFound_ReturnsAnEmptyList()
        {
            // Arrange
            var mockFactory = new Mock<IHttpClientFactory>();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent("[{'id':1,'firstName':'First', 'lastName': 'Last'}]")
                    Content = new StringContent("[]")
                });

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://test.com")
            };

            mockFactory.Setup(f=> f.CreateClient("DoctorClient")).Returns(client);

            var doctorService = new DoctorService(mockFactory.Object);

            // Act
            var result = await doctorService.GetDoctors();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task GetDoctors_DoctorsAreFound_ReturnsAList()
        {
            // Arrange
            var mockFactory = new Mock<IHttpClientFactory>();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{'id':1,'firstName':'First', 'lastName': 'Last'}]")
                });

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://test.com")
            };

            mockFactory.Setup(f => f.CreateClient("DoctorClient")).Returns(client);

            var doctorService = new DoctorService(mockFactory.Object);

            // Act
            var result = await doctorService.GetDoctors();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }
    }
}

