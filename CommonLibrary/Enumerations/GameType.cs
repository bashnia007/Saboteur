using System;
using System.ComponentModel;

namespace CommonLibrary.Enumerations
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
