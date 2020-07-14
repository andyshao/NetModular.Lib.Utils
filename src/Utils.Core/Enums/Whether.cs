using System.ComponentModel;

namespace NetModular.Lib.Utils.Core.Enums
{
    /// <summary>
    /// 是否
    /// </summary>
    public enum Whether
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        UnKnown = -1,
        /// <summary>
        /// 是
        /// </summary>
        [Description("是")]
        True = 1,
        /// <summary>
        /// 否
        /// </summary>
        [Description("否")]
        False = 0
    }
}
