using System;

namespace Coolbuh.Core.Entities.Enums
{
    /// <summary>
    /// Флаги справочника "Надбавки за пенсию"
    /// </summary>
    [Flags]
    public enum ListPensionAllowanceActions
    {
        /// <summary>
        /// Не использовать надбавку
        /// </summary>
        NoUse = 0x01
    }
}
