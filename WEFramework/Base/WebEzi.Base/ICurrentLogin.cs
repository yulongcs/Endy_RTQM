//using WebEzi.Base.DefinedData;

namespace WebEzi.Base
{
    public interface ICurrentLogin
    {
        string UserID { get; set; }

        string UserName { get; set; }
  
        string Role { get; set; }
    }
}
