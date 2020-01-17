using System;
using System.ComponentModel;

namespace CommonLibraryStandard.Enums
{
    [Serializable]
    public enum GameType
    {
        [Description("Дуэль")]
        Duel,

        [Description("Классическая")]
        Classic,

        [Description("Расширенная")]
        Extended
    }
}
