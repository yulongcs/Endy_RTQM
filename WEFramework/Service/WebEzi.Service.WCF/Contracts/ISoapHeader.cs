namespace WebEzi.Service.WCF.Contracts
{
    interface ISoapHeader
    {
        string WebEziUID { get; set; }
        string WebEziUKey { get; set; }
        string WebEziUName { get; set; }
        string WebEziUPwd { get; set; }

        //void IsValid(); SoapHeader Extensions:Implemented in the 'DemoService/base/SoapHeader.cs/SoapHeaderExtensions' extension
    }

}
