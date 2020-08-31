using System;
using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class SRecord
    {
        [DataMember]
        public long RecordId;
        [DataMember(EmitDefaultValue = false)]
        public SPlayer LinkPlayer;
        [DataMember(EmitDefaultValue = false)]
        public int Mode;
        [DataMember(EmitDefaultValue = false)]
        public int Score;
        [DataMember(EmitDefaultValue = false)]
        public int MaxSpeed;
        [DataMember(EmitDefaultValue = false)]
        public int Steps;
        [DataMember(EmitDefaultValue = false)]
        public float MaxTime;
    }
}
