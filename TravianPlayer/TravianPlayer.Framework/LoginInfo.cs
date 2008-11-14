namespace TravianPlayer.Framework
{
    public class LoginInfo
    {
        public string Username { get; set; }

        public string Password { get; set; }

        /*
        <input type="hidden" name="w" value="">
         */
        public string HiddenWValue { get; set; }

        /*
        <input type="hidden" name="login" value="1226249860">
         */
        public string HiddenLoginValue { get; set; }

        /*
        <p align="center"><input type="hidden" name="ebb412a" value="e697604783">
         */
        public string HiddenName { get; set; }

        /*
        <p align="center"><input type="hidden" name="ebb412a" value="e697604783">
         */
        public string HiddenValue { get; set; }

        /*
        <input class="fm fm110" type="text" name="eb4b613" value="jeza1" maxlength="15"> <span class="e f7"></span>
         */
        public string TextBoxUserame { get; set; }

        /*
        <input class="fm fm110" type="password" name="eb77f54" value="*****" maxlength="20"> <span class="e f7"></span>
         */
        public string TextBoxPassword { get; set; }
    }
}