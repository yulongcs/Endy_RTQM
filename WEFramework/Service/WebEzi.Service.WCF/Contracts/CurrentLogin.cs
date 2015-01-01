using System;
using System.Runtime.Serialization;


using System.Xml.Serialization;
namespace WebEzi.Service.WCF.Contracts
{
    [DataContract(Name = SoapNamespace.WebEziCurrentLogin, Namespace = SoapNamespace.WebEziNamespace)]
    [Serializable]
    public class CurrentLoginContract : ICurrentLoginContract
    {
        #region  Constructors
        public CurrentLoginContract()
        {
        }
        public CurrentLoginContract(string userID, string userName, string role, decimal ip)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.Role = role;
            this.IP = ip;
        }
        public CurrentLoginContract(dynamic value)
        {
            this.UserID = value.UserID;
            this.UserName = value.UserName;
            this.Role = value.Role;
            //base
            //this.IP = value.IP;
        }
        #endregion Constructors

        #region Properties
        [DataMember(Name = "UserID", Order = 1)]
        public string UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public decimal IP { get; set; }
        #endregion Properties
    }
}
