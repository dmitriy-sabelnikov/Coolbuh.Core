using System;

namespace Coolbuh.Core.Entities.Enums
{
    /// <summary>
    /// Флаги справочника "Надбавки за классность"
    /// </summary>
    [Flags]
    public enum ListGradeAllowanceActions
    {
        /// <summary>
        /// Не использовать надбавку
        /// </summary>
        NoUse = 0x01
    }
}
