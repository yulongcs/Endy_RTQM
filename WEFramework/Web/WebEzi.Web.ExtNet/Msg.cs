using Ext.Net;

namespace WebEzi.Web.ExtNet
{
    public class Msg
    {
        public static void Alert(string title, string msg)
        {
            X.Msg.Alert(title, msg).Show();
        }

        public static void Alert(string title, string msg, string handle)
        {
            X.Msg.Alert(title, msg, handle).Show();
        }

        public static void Confirm(string title, string msg, string yesButtonHandle, string noButtonHandle)
        {
            X.Msg.Confirm(title, msg, new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = yesButtonHandle,
                    Text = "Yes"
                },
                No = new MessageBoxButtonConfig
                {

                    Handler = noButtonHandle,
                    Text = "No"
                }
            }).Show();
        }
    }
}
