namespace DemoWebApp
{
    public class SiteMapping
    {
        public const string Default = "Default.aspx";

        /// <summary>
        /// Please Note, any URL or Path defined here never user prefix path "/",base page will add application path for them.
        /// For Example:
        /// Wrong URL defined:   "/ASPX/User/User.aspx"
        /// Correct URL defined: "ASPX/User/User.aspx"  
        /// !!!Please Note , we dont need the first "/" of all urls here.!!!
        /// </summary>

        public class ASPX
        {
            private const string Prefix = "ASPX/";
            public const string Home = Prefix + "Home.aspx";
            public const string Login = Prefix + "Login.aspx";

            public class Department
            {
                private const string Prefix = ASPX.Prefix+"Department/";
                public const string CustomerList = Prefix + "Departments.aspx";
            }

            public class User
            {
                private const string Prefix = ASPX.Prefix+"User/";
                public const string UserList = Prefix + "Users.aspx";
            }
   
        }
    }
}
