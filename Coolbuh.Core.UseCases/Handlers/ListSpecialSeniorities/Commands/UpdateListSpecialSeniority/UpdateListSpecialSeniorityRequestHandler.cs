using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.UpdateListSpecialSeniority
{
    /// <summary>
    /// Обработчик команды "Обновить спецстаж"
    /// </summary>
    public class UpdateListSpecialSeniorityRequestHandler
        : IRequestHandler<UpdateListSpecialSeniorityRequest, ListSpecialSeniorityDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListSpecialSenioritiesService _specialSenioritiesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="specialSenioritiesService">Доменный сервис справочника "Спецстажи"</param>
        public UpdateListSpecialSeniorityRequestHandler(IDbContext dbContext,
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
        public async Task<ListSpecialSeniorityDto> Handle(UpdateListSpecialSeniorityRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SpecialSeniority == null)
                throw new NullReferenceException(nameof(request.SpecialSeniority));

            await CheckUpdateListSpecialSeniorityDtoAsync(request.SpecialSeniority, cancellationToken);

            var specialSeniority = request.SpecialSeniority.MapListSpecialSeniority();

            _specialSenioritiesService.ValidationEntity(specialSeniority);

            _dbContext.ListSpecialSeniorities.Update(specialSeniority);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return specialSeniority.MapListSpecialSeniorityDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Спецстажи"
        /// </summary>
        /// <param name="specialSeniority">DTO обновления "Спецстажи"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateListSpecialSeniorityDtoAsync(UpdateListSpecialSeniorityDto specialSeniority,
            CancellationToken cancellationToken)
        {
            if (specialSeniority == null) throw new ArgumentNullException(nameof(specialSeniority));

            //Code можно поменять
            var specialSeniorities = await _dbContext.ListSpecialSeniorities.AsNoTracking()
                .Where(rec => rec.Code == specialSeniority.Code || rec.Id == specialSeniority.Id)
                .ToListAsync(cancellationToken);

            if (specialSeniorities.Any(rec => rec.Id == specialSeniority.Id) == false)
                throw new NotFoundEntityUseCaseException($"Відсутній спецстаж в базі (id: {specialSeniority.Id})");

            if (specialSeniorities.Any(rec => rec.Id != specialSeniority.Id))
                throw new UseCaseException($"Дублікат коду {specialSeniority.Code} в довіднику");
        }
    }
}
