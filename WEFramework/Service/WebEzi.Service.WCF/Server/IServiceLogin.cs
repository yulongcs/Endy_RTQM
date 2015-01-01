using System.ServiceModel;

namespace WebEzi.Service.WCF.Server
{
    /// <summary>
    /// None ESB  服务安全验证，服务端操作重载示例
    /// </summary>
    [ServiceContract(Name = SoapNamespace.WebEziEsbLogin, Namespace = SoapNamespace.WebEziEsbServiceContractNamespace)]
    public interface IServiceLogin : IBaseWebService 
    {
        [OperationContract(Name = "Login")]
        void Login(string UName, string UPwd);
        [OperationContract(Name = "LoginImplicit")]
        void Login();
        [OperationContract(Name = "Logout")]
        void Logout(string UName, string UPwd);
        [OperationContract(Name = "LogoutImplicit")]
        void Logout( );
    }
}
