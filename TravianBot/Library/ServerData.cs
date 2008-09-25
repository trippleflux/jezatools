using System.Collections;

namespace Library
{
    public class ServerData
    {
        private string username;
        private string password;
        private string servername;
        
        private string textboxLoginName;
        private string textboxLoginValue;
        private string textboxPasswordName;
        private string textboxPasswordValue;

        private string hiddenLoginValue;
        private string hiddenName;
        private string hiddenValue;

        private int playerUID;
        private ArrayList villagesList = new ArrayList();
        private ArrayList productionList = new ArrayList();
        private ArrayList resourcesList = new ArrayList();
        private ArrayList buildingsList = new ArrayList();

        /// <summary>
        /// Login Username.
        /// </summary>
        /// <example>jezonsky</example>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Login password.
        /// </summary>
        /// <example>somepassword</example>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Server URL.
        /// </summary>
        /// <example>http://s3.travian.si/</example>
        public string Servername
        {
            get { return servername; }
            set { servername = value; }
        }

        /// <summary>
        /// <input class="fm fm110" type="text" name="e528e90" value="" maxlength="15">
        /// </summary>
        /// <example>name="e528e90"</example>
        public string TextboxLoginName
        {
            get { return textboxLoginName; }
            set { textboxLoginName = value; }
        }

        /// <summary>
        /// <input class="fm fm110" type="text" name="e528e90" value="" maxlength="15">
        /// </summary>
        /// <example>value=""</example>
        public string TextboxLoginValue
        {
            get { return textboxLoginValue; }
            set { textboxLoginValue = value; }
        }

        /// <summary>
        /// <input class="fm fm110" type="password" name="e4519e5" value="" maxlength="20">
        /// </summary>
        /// <example>name="e4519e5"</example>
        public string TextboxPasswordName
        {
            get { return textboxPasswordName; }
            set { textboxPasswordName = value; }
        }

        /// <summary>
        /// <input class="fm fm110" type="password" name="e4519e5" value="" maxlength="20">
        /// </summary>
        /// <example>value=""</example>
        public string TextboxPasswordValue
        {
            get { return textboxPasswordValue; }
            set { textboxPasswordValue = value; }
        }

        /// <summary>
        /// <input type="hidden" name="login" value="1218716929">
        /// </summary>
        /// <example>value="1218716929"</example>
        public string HiddenLoginValue
        {
            get { return hiddenLoginValue; }
            set { hiddenLoginValue = value; }
        }

        /// <summary>
        /// <input type="hidden" name="eea0521" value="">
        /// </summary>
        /// <example>name="eea0521"</example>
        public string HiddenName
        {
            get { return hiddenName; }
            set { hiddenName = value; }
        }

        /// <summary>
        /// <input type="hidden" name="eea0521" value="">
        /// </summary>
        /// <example>value=""</example>
        public string HiddenValue
        {
            get { return hiddenValue; }
            set { hiddenValue = value; }
        }

        /// <summary>
        /// //<a href="spieler.php?uid=8226">Profil</a>
        /// </summary>
        public int PlayerUID
        {
            get { return playerUID; }
            set { playerUID = value; }
        }

        /// <summary>
        /// <a href="?newdid=10902">Muta01</a>
        /// <a href="?newdid=10903">Muta02</a>
        /// ...
        /// </summary>
        /// <remarks>
        /// List is in format villageID|villageName
        /// </remarks>
        /// <example>
        /// 10902|Muta01
        /// </example>
        public ArrayList VillagesList
        {
            get { return villagesList; }
            set { villagesList = value; }
        }

        public ArrayList ProductionList
        {
            get { return productionList; }
            set { productionList = value; }
        }

        public ArrayList ResourcesList
        {
            get { return resourcesList; }
            set { resourcesList = value; }
        }


        public ArrayList BuildingsList
        {
            get { return buildingsList; }
            set { buildingsList = value; }
        }
    }
}