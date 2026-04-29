using System;
using System.Collections.Generic;

namespace NuclearDecline
{
    [Serializable]
    public sealed class NuclearDeclineSaveEntry
    {
        public string key;
        public string value;
    }
}

namespace YG
{
    public partial class SavesYG
    {
        public List<NuclearDecline.NuclearDeclineSaveEntry> nuclearDeclineData =
            new List<NuclearDecline.NuclearDeclineSaveEntry>();
    }
}
