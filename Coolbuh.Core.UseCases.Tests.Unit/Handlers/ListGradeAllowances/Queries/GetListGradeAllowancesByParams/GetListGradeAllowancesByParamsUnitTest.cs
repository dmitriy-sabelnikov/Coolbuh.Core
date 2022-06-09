using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowancesByParams;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListGradeAllowances.Queries.GetListGradeAllowancesByParams
{
    /// <summary>
    /// Тестирование запроса "Получить надбавку за классность"
    /// </summary>
    public class GetListGradeAllowancesByParamsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListGradeAllowancesByParamsUnitTest()
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
            
            var count = _fakeDbContext.Object.ListGradeAllowances
                .Where(rec => rec.DepartmentId == gradeAllowance.DepartmentId &&
                    rec.Grade == gradeAllowance.Grade)
                .Count();

            var query = new GetListGradeAllowancesByParamsRequestHandler(_fakeDbContext.Object);
            var request = new GetListGradeAllowancesByParamsRequest()
            {
                DepartmentId = gradeAllowance.DepartmentId,
                Grade = gradeAllowance.Grade
            };

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
