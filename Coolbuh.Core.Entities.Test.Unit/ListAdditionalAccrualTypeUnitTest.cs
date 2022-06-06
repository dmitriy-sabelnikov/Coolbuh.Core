using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit;

/// <summary>
/// Тестирование доменного сервиса "Типы дополнительных начислений"
/// </summary>
public class ListAdditionalAccrualTypeUnitTest
{
    /// <summary>
    /// Валидация типа дополнительных начислений - не указан код
    /// </summary>
    [Fact]
    public void ValidateEntityWithoutCodeTest()
    {
        // Arrange
        var service = new ListAdditionalAccrualTypesService();
        var entity = GetFakeListAdditionalAccrualType();
        entity.Code = string.Empty;

        // Act
        var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

        // Assert
        Assert.NotEmpty(result.Message);
    }

    /// <summary>
    /// Валидация типа дополнительных начислений - превышение допустимой длины кода
    /// </summary>
    [Fact]
    public void ValidateEntityAbnormalCodeLengthTest()
    {
        // Arrange
        var service = new ListAdditionalAccrualTypesService();
        var entity = GetFakeListAdditionalAccrualType();
        entity.Code = new string('A', ListAdditionalAccrualTypeConstants.CodeLength + 1);

        // Act
        var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

        // Assert
        Assert.NotEmpty(result.Message);
    }

    /// <summary>
    /// Валидация типа дополнительных начислений - не указано наименование
    /// </summary>
    [Fact]
    public void ValidateEntityWithoutNameTest()
    {
        // Arrange
        var service = new ListAdditionalAccrualTypesService();
        var entity = GetFakeListAdditionalAccrualType();
        entity.Name = string.Empty;

        // Act
        var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

        // Assert
        Assert.NotEmpty(result.Message);
    }

    /// <summary>
    /// Валидация типа дополнительных начислений - превышение допустимой длины наименования
    /// </summary>
    [Fact]
    public void ValidateEntityAbnormalNameLengthTest()
    {
        // Arrange
        var service = new ListAdditionalAccrualTypesService();
        var entity = GetFakeListAdditionalAccrualType();
        entity.Name = new string('A', ListAdditionalAccrualTypeConstants.NameLength + 1);

        // Act
        var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

        // Assert
        Assert.NotEmpty(result.Message);
    }

    /// <summary>
    /// Получить фейковый тип дополнительных начислений
    /// </summary>
    /// <returns>Фейковый тип дополнительных начислений</returns>
    private static ListAdditionalAccrualType GetFakeListAdditionalAccrualType()
    {
        return new ListAdditionalAccrualType
        {
            Id = 1,
            Code = "1",
            Name = "1",
            Flags = 0
        };
    }
}
