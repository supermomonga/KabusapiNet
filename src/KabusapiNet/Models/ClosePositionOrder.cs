namespace KabusapiNet.Models;

/// <summary>
/// 決済順序
/// </summary>
public enum ClosePositionOrder
{
    /// <summary>
    /// 日付（古い順）、損益（高い順）
    /// </summary>
    DateAscendingProfitDescending = 0,

    /// <summary>
    /// 日付（古い順）、損益（低い順）
    /// </summary>
    DateAscendingProfitAscending = 1,

    /// <summary>
    /// 日付（新しい順）、損益（高い順）
    /// </summary>
    DateDescendingProfitDescending = 2,

    /// <summary>
    /// 日付（新しい順）、損益（低い順）
    /// </summary>
    DateDescendingProfitAscending = 3,

    /// <summary>
    /// 損益（高い順）、日付（古い順）
    /// </summary>
    ProfitDescendingDateAscending = 4,

    /// <summary>
    /// 損益（高い順）、日付（新しい順）
    /// </summary>
    ProfitDescendingDateDescending = 5,

    /// <summary>
    /// 損益（低い順）、日付（古い順）
    /// </summary>
    ProfitAscendingDateAscending = 6,

    /// <summary>
    /// 損益（低い順）、日付（新しい順）
    /// </summary>
    ProfitAscendingDateDescending = 7
}
