#region

using System;
using System.Globalization;
using WatiN.Core;

#endregion

namespace TW.Helper
{
    public class SendTroops : DefaultPage
    {
        public SendTroops(Browser browser) : base(browser)
        {
            this.browser = browser;
        }

        public SendTroops
            (Browser browser,
             string server,
             string username,
             string password,
             int defaultVillageId) : base(browser, server, username, password, defaultVillageId)
        {
            this.browser = browser;
            Server = server;
            DefaultVillageId = defaultVillageId;
        }

        public bool Attack(AttackSettings attackSettings)
        {
            string url = String.Format(CultureInfo.InvariantCulture, "{0}a2b.php?newdid={1}&z={2}", Server,
                                       DefaultVillageId, attackSettings.DestinationVillage);
            browser.GoTo(url);
            if (browser.Table(Find.ById("troops")).Exists)
            {
                TextField textField = browser.TextField(Find.ByName(attackSettings.TroopName));
                if (textField.Exists)
                {
                    textField.TypeText(attackSettings.TroopCount);
                    RadioButton radioButton = browser.RadioButton(Find.ByValue(attackSettings.AttackType2String));
                    if (radioButton.Exists)
                    {
                        radioButton.Checked = true;
                        Image image = browser.Image(Find.ById("btn_ok"));
                        if (image.Exists)
                        {
                            image.Click();
                            image = browser.Image(Find.ById("btn_ok"));
                            if (image.Exists)
                            {
                                image.Click();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private readonly Browser browser;
    }
}