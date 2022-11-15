using System;

namespace Coolbuh.Core.Entities.Enums
{
    /// <summary>
    /// Флаги справочника "Типы дополнительных начислений"
    /// </summary>
    [Flags]
    public enum ListAdditionalAccrualTypeActions
    {
        /// <summary>
        /// Включать в расчет
        /// </summary>
        Calculate = 0x01
    }
}
