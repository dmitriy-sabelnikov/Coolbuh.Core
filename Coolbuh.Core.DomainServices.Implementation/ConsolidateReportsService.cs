using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IConsolidateReportsService"/>
    public class ConsolidateReportsService : IConsolidateReportsService
    {
        public void ValidationEntity(ConsolidateReportCatalog сonsolidateReportCatalog)
        {
            if (сonsolidateReportCatalog == null) throw new ArgumentNullException(nameof(сonsolidateReportCatalog));

            if (сonsolidateReportCatalog.Quarter < 1 || сonsolidateReportCatalog.Quarter > 4)
                throw new NotValidEntityEntityException("Квартал повинен бути в діапазоні від 1 до 4");

            if (сonsolidateReportCatalog.Year == 0)
                throw new NotValidEntityEntityException("Не заповнений рік");

            if (сonsolidateReportCatalog.Number == 0)
                throw new NotValidEntityEntityException("Не заповнений номер");

            if (сonsolidateReportCatalog.Name == string.Empty)
                throw new NotValidEntityEntityException("Не заповнене найменування");
        }
    }
}