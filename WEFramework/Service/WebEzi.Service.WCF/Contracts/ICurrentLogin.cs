using System;
using System.Runtime.Serialization;

namespace WebEzi.Service.WCF.Contracts
{
    public interface ICurrentLoginContract:WebEzi.Base.ICurrentLogin
    {
        new string UserID { get; set; }

        new string UserName { get; set; }

        new string Role { get; set; }

        decimal IP { get; set; }

    }
}
