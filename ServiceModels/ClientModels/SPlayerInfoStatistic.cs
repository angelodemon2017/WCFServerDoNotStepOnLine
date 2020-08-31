using System;
using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class SPlayerInfoStatistic
    {
        [DataMember]
        public int PlayerInfoStatisticId;
        [DataMember(EmitDefaultValue = false)]
        public SPlayer LinkPlayer;
        [DataMember(EmitDefaultValue = false)]
        public int PlayedGames;
        [DataMember(EmitDefaultValue = false)]
        public int Coins;
        [DataMember(EmitDefaultValue = false)]
        public int Donat;
        [DataMember(EmitDefaultValue = false)]
        public int AllStep;
        [DataMember(EmitDefaultValue = false)]
        public int MaxCombo;
        [DataMember(EmitDefaultValue = false)]
        public int PerfectSteps;
        [DataMember(EmitDefaultValue = false)]
        public float Distance;
        [DataMember(EmitDefaultValue = false)]
        public int QuestComplete;
    }
}
