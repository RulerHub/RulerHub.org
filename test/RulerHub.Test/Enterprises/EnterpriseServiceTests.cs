using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using RulerHub.Data.Context;
using RulerHub.Data.Services.Enterprises.Implements;
using RulerHub.Shared.Entities.Enterprises;
using System.Security.Claims;

namespace RulerHub.Test.Enterprises
{
    [TestClass]
    public class EnterpriseServiceTests
    {
        private Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private ApplicationDbContext _context;
        private EnterpriseService _enterpriseService;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            _enterpriseService = new EnterpriseService(_context, _httpContextAccessorMock.Object);
        }

        [TestMethod]
        public async Task CreateEnterprise_ShouldAddEnterprise()
        {
            // Arrange
            var userId = "test-user-id";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));

            _httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var enterprise = new Enterprise
            {
                Name = "Test Enterprise",
                Description = "Test Description"
            };

            // Act
            var result = await _enterpriseService.CreateEnterprise(enterprise);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.UserId);
            Assert.AreEqual("Test Enterprise", result.Name);
        }

        [TestMethod]
        public async Task GetEnterprises_ShouldReturnEnterprisesForUser()
        {
            // Arrange
            var userId = "test-user-id";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));

            _httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            _context.Enterprises.Add(new Enterprise { Name = "Enterprise 1", UserId = userId });
            _context.Enterprises.Add(new Enterprise { Name = "Enterprise 2", UserId = userId });
            _context.Enterprises.Add(new Enterprise { Name = "Enterprise 3", UserId = "other-user-id" });
            await _context.SaveChangesAsync();

            // Act
            var result = await _enterpriseService.GetEnterprises();

            // Assert
            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.All(e => e.UserId == userId));
        }
        [TestMethod]
        public async Task DeleteEnterprise_ShouldDeleteEnterpriseForUser()
        {
            // Arrange
            var userId = "test-user-id";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));

            _httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var enterprise = new Enterprise { Id = 54, Name = "Enterprise 54", UserId = userId };
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _enterpriseService.DeleteEnterprise(54);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(await _context.Enterprises.FindAsync(54));
        }

        [TestMethod]
        public async Task DeleteEnterprise_ShouldReturnFalseForDifferentUser()
        {
            // Arrange
            var userId = "test-user-id";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));

            _httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var enterprise = new Enterprise { Id = 5, Name = "Enterprise 5", UserId = "other-user-id" };
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _enterpriseService.DeleteEnterprise(5);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNotNull(await _context.Enterprises.FindAsync(5));
        }
        [TestMethod]
        public async Task UpdateEnterprise_ShouldUpdateEnterpriseForUser()
        {
            // Arrange
            var userId = "test-user-id";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));

            _httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var enterprise = new Enterprise { Id = 6, Name = "Enterprise 6", UserId = userId };
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();

            var updatedEnterprise = new Enterprise { Id = 6, Name = "Updated Enterprise", UserId = userId };

            // Act
            var result = await _enterpriseService.UpdateEnterprise(updatedEnterprise);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Enterprise", result.Name);
        }

        [TestMethod]
        public async Task UpdateEnterprise_ShouldReturnNullForDifferentUser()
        {
            // Arrange
            var userId = "test-user-id";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));

            _httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var enterprise = new Enterprise { Id = 7, Name = "Enterprise 7", UserId = "other-user-id" };
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();

            var updatedEnterprise = new Enterprise { Id = 7, Name = "Updated Enterprise", UserId = userId };

            // Act
            var result = await _enterpriseService.UpdateEnterprise(updatedEnterprise);

            // Assert
            Assert.IsNull(result);
        }

        // Agrega más pruebas para los otros métodos (GetEnterpriseById, UpdateEnterprise, DeleteEnterprise)
    }
}
