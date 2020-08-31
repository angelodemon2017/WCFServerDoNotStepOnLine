using System;
using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class SAchievement
    {
        [DataMember]
        public long Achievent;
        [DataMember(EmitDefaultValue = false)]
        public SPlayer LinkPlayer;
        [DataMember(EmitDefaultValue = false)]
        public string NameAchievement;
        [DataMember(EmitDefaultValue = false)]
        public string NumberRewards;
    }
}
