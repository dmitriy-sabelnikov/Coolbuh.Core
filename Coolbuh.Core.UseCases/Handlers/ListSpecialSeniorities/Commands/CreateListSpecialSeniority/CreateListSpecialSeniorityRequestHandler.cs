using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.CreateListSpecialSeniority
{
    /// <summary>
    /// Обработчик команды "Создать спецстаж"
    /// </summary>
    public class CreateListSpecialSeniorityRequestHandler
        : IRequestHandler<CreateListSpecialSeniorityRequest, ListSpecialSeniorityDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListSpecialSenioritiesService _specialSenioritiesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="specialSenioritiesService">Доменный сервис справочника "Спецстажи"</param>
        public CreateListSpecialSeniorityRequestHandler(IDbContext dbContext,
            IListSpecialSenioritiesService specialSenioritiesService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _specialSenioritiesService = specialSenioritiesService ??
                                         throw new ArgumentNullException(nameof(specialSenioritiesService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Спецстажи"</returns>
        public async Task<ListSpecialSeniorityDto> Handle(CreateListSpecialSeniorityRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SpecialSeniority == null) throw new InvalidOperationException("request.SpecialSeniority is null");

            await CheckCreateListSpecialSeniorityDtoAsync(request.SpecialSeniority, cancellationToken);

            var specialSeniority = request.SpecialSeniority.MapListSpecialSeniority();

            _specialSenioritiesService.ValidationEntity(specialSeniority);

            await _dbContext.ListSpecialSeniorities.AddAsync(specialSeniority, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return specialSeniority.MapListSpecialSeniorityDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Спецстажи"
        /// </summary>
        /// <param name="specialSeniority">DTO создания "Спецстажи"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreateListSpecialSeniorityDtoAsync(CreateListSpecialSeniorityDto specialSeniority,
            CancellationToken cancellationToken)
        {
            if (specialSeniority == null) throw new ArgumentNullException(nameof(specialSeniority));

            if (await _dbContext.ListSpecialSeniorities
                .AnyAsync(rec => rec.Code == specialSeniority.Code, cancellationToken))
                throw new UseCaseException($"Дублікат коду {specialSeniority.Code} в довіднику");
        }
    }
}
