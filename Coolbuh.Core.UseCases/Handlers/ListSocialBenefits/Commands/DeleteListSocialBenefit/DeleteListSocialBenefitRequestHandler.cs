using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.DeleteListSocialBenefit
{
    /// <summary>
    /// Обработчик команды "Удалить социальную льготу"
    /// </summary>
    public class DeleteListSocialBenefitRequestHandler
        : IRequestHandler<DeleteListSocialBenefitRequest, ListSocialBenefitDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListSocialBenefitRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Социальные льготы"</returns>
        public async Task<ListSocialBenefitDto> Handle(DeleteListSocialBenefitRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SocialBenefit == null) throw new InvalidOperationException("request.SocialBenefit is null");

            var socialBenefit = await GetListSpecialSeniorityAsync(request.SocialBenefit.Id, cancellationToken);

            _dbContext.ListSocialBenefits.Remove(socialBenefit);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return socialBenefit.MapListSocialBenefitDto();
        }

        /// <summary>
        /// Получить социальную льготу
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Спецстаж</returns>
        private async Task<ListSocialBenefit> GetListSpecialSeniorityAsync(int id, CancellationToken cancellationToken)
        {
            var socialBenefit = await _dbContext.ListSocialBenefits.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (socialBenefit == null)
                throw new NotFoundEntityUseCaseException($"Відсутня соціальна пільга в базі (id: {id})");

            return socialBenefit;
        }
    }
}