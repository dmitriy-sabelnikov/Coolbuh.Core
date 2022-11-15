using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.UpdateListSocialBenefit
{
    /// <summary>
    /// Обработчик команды "Обновить социальную льготу"
    /// </summary>
    public class UpdateListSocialBenefitRequestHandler
        : IRequestHandler<UpdateListSocialBenefitRequest, ListSocialBenefitDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListSocialBenefitsService _socialBenefitsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="socialBenefitsService">Доменный сервис справочника "Социальные льготы"</param>
        public UpdateListSocialBenefitRequestHandler(IDbContext dbContext,
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
        public async Task<ListSocialBenefitDto> Handle(UpdateListSocialBenefitRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SocialBenefit == null) throw new InvalidOperationException("request.SocialBenefit is null");

            var socialBenefit = request.SocialBenefit.MapListSocialBenefit();
            var socialBenefits = await _dbContext.ListSocialBenefits.AsNoTracking().ToListAsync(cancellationToken);

            if (!socialBenefits.Any(rec => rec.Id == socialBenefit.Id))
                throw new NotFoundEntityUseCaseException($"Відсутня соціальна пільга в базі (id: {socialBenefit.Id})");

            _socialBenefitsService.ValidationEntity(socialBenefit);

            if (_socialBenefitsService.IsExistsPeriodIntersection(socialBenefit, socialBenefits))
                throw new UseCaseException("Період перетинається з існуючим");

            _dbContext.ListSocialBenefits.Update(socialBenefit);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return socialBenefit.MapListSocialBenefitDto();
        }
    }
}