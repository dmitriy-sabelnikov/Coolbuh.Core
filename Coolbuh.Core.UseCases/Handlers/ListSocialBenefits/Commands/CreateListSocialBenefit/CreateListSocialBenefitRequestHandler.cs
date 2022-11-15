using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.CreateListSocialBenefit
{
    /// <summary>
    /// Обработчик команды "Создать социальную льготу"
    /// </summary>
    public class CreateListSocialBenefitRequestHandler
        : IRequestHandler<CreateListSocialBenefitRequest, ListSocialBenefitDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListSocialBenefitsService _socialBenefitsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="socialBenefitsService">Доменный сервис справочника "Социальные льготы"</param>
        public CreateListSocialBenefitRequestHandler(IDbContext dbContext,
            IListSocialBenefitsService socialBenefitsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _socialBenefitsService = socialBenefitsService ??
                                     throw new ArgumentNullException(nameof(socialBenefitsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Социальные льготы"</returns>
        public async Task<ListSocialBenefitDto> Handle(CreateListSocialBenefitRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SocialBenefit == null) throw new InvalidOperationException("request.SocialBenefit is null");

            var socialBenefit = request.SocialBenefit.MapListSocialBenefit();
            _socialBenefitsService.ValidationEntity(socialBenefit);

            var socialBenefits = await _dbContext.ListSocialBenefits.AsNoTracking().ToListAsync(cancellationToken);
            if (_socialBenefitsService.IsExistsPeriodIntersection(socialBenefit, socialBenefits))
                throw new UseCaseException("Період перетинається з існуючим");

            await _dbContext.ListSocialBenefits.AddAsync(socialBenefit, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return socialBenefit.MapListSocialBenefitDto();
        }
    }
}