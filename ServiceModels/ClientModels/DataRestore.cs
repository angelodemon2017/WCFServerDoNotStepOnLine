using System;
using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class DataRestore
    {
        [DataMember(EmitDefaultValue = false)]
        public SPlayer sPlayer;
        [DataMember(EmitDefaultValue = false)]
        public SPlayerInfoStatistic sPlayerInfoStatistic;
        [DataMember(EmitDefaultValue = false)]
        public SRecord sRecord1;
        [DataMember(EmitDefaultValue = false)]
        public SRecord sRecord2;
        [DataMember(EmitDefaultValue = false)]
        public SAchievement sAchievement1;
    }
}
