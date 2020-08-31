using System;
using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class SBoot
    {
        [DataMember]
        public long BootId;
        [DataMember(EmitDefaultValue = false)]
        public string BootName;
        [DataMember(EmitDefaultValue = false)]
        public int Price;
        [DataMember(EmitDefaultValue = false)]
        public int PremiumPrice;
        [DataMember(EmitDefaultValue = false)]
        public DateTime ActualDate;
        [DataMember(EmitDefaultValue = false)]
        public DateTime BurnDate;
    }
}
