using System.Runtime.Serialization;


namespace WebEzi.Service.WCF.Contracts
{
    [DataContract(Name = SoapNamespace.WebEziSoapHeader, Namespace = SoapNamespace.WebEziNamespace)]
    public partial class SoapHeader : ISoapHeader
    {
        [DataMember]
        public string WebEziUID
        { get; set; }
        [DataMember]
        public string WebEziUName
        { get; set; }
        [DataMember]
        public string WebEziUPwd
        { get; set; }
        [DataMember]
        public string WebEziUKey
        { get; set; }
        [DataMember]
        public bool State;


        public SoapHeader()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="UName"></param>
        /// <param name="UPwd"></param>
        /// <param name="UKey"></param>
        public SoapHeader(string UID, string UName, string UPwd, string UKey)
        {
            this.WebEziUID = UID;
            this.WebEziUName = UName;
            this.WebEziUPwd = UPwd;
            this.WebEziUKey = UKey;
        }
    }

}
