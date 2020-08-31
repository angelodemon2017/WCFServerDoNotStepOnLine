using System;
using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class SPlayer
    {
        [DataMember]
        public long PlayerId;
        [DataMember(EmitDefaultValue = false)]
        public string Name;
        [DataMember(EmitDefaultValue = false)]
        public string Ip;
        [DataMember(EmitDefaultValue = false)]
        public string Password;
        [DataMember(EmitDefaultValue = false)]
        public DateTime DateRegistration;
        [DataMember(EmitDefaultValue = false)]
        public DateTime DateLastAction;
        [DataMember(EmitDefaultValue = false)]
        public int EveryDayMark;
        [DataMember(EmitDefaultValue = false)]
        public string DeviceId;
        [DataMember(EmitDefaultValue = false)]
        public string GoogleId;
    }
}
