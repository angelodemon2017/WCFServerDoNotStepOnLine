using System;
using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class SQuestResponse
    {
        [DataMember]
        public bool SCanGenerate;
        [DataMember(EmitDefaultValue = false)]
        public TimeSpan SleftTime;
    }
}
