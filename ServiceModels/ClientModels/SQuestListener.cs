using System;
using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class SQuestListener
    {
        [DataMember]
        public int QuestListenerId;
        [DataMember(EmitDefaultValue = false)]
        public SPlayer LinkPlayer;
        [DataMember(EmitDefaultValue = false)]
        public string QuestTypeId;
        [DataMember(EmitDefaultValue = false)]
        public int CurrentValue;
        [DataMember(EmitDefaultValue = false)]
        public bool GetReward;
        [DataMember(EmitDefaultValue = false)]
        public DateTime DateBurnQuest;
    }
}
