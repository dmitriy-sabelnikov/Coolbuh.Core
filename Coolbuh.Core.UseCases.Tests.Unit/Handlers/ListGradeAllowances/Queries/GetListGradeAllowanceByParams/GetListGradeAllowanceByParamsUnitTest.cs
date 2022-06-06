using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowanceByParams;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListGradeAllowances.Queries.GetListGradeAllowanceByParams
{
    /// <summary>
    /// Тестирование запроса "Получить надбавку за классность"
    /// </summary>
    public class GetListGradeAllowanceByParamsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListGradeAllowanceByParamsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeGradeAllowances = FakeDbRepository.GetFakeListGradeAllowances();

            _fakeDbContext.Setup(set => set.ListGradeAllowances).Returns(fakeGradeAllowances.Object);
        }

        /// <summary>
        /// Тестирование получения надбавки за классность
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListGradeAllowanceByParamsTest()
        {
            // Arrange
            var gradeAllowance = _fakeDbContext.Object.ListGradeAllowances.First();

            var query = new GetListGradeAllowanceByParamsRequestHandler(_fakeDbContext.Object);
            var request = new GetListGradeAllowanceByParamsRequest()
            {
                DepartmentId = gradeAllowance.Id,
                Grade = gradeAllowance.Grade
            };

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(gradeAllowance.Id, result.Id);
            Assert.Equal(gradeAllowance.Name, result.Name);
        }
    }
}
