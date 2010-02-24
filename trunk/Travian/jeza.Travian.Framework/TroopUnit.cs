namespace jeza.Travian.Framework
{
    public class TroopUnit
    {
        /// <summary>
        /// Gets the html class attribute.
        /// </summary>
        /// <value>The class id.</value>
        public string ClassAttribute
        {
            get { return classAttribute; }
        }

        /// <summary>
        /// Gets the troop count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return attribute; }
        }

        /// <summary>
        /// Gets the send troops text box attribute.
        /// </summary>
        /// <value>The send troops text box attribute.</value>
        public string SendTroopsTextBoxAttribute
        {
            get { return sendTroopsTextBoxName; }
        }

        /// <summary>
        /// Adds the name of the HTML class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns></returns>
        public TroopUnit AddHtmlClassName(string className)
        {
            classAttribute = className;
            return this;
        }

        /// <summary>
        /// Adds the name of the troop.
        /// </summary>
        /// <param name="troopName">Name of the troop.</param>
        /// <returns></returns>
        public TroopUnit AddName(string troopName)
        {
            attribute = troopName;
            return this;
        }

        /// <summary>
        /// Adds the name of the send troop text box.
        /// </summary>
        /// <param name="textBoxName">The name attribute.</param>
        /// <returns></returns>
        public TroopUnit AddSendTroopTextBoxName(string textBoxName)
        {
            sendTroopsTextBoxName = textBoxName;
            return this;
        }

        /// <summary>
        /// Adds the troop count.
        /// </summary>
        /// <param name="troopCount">The troop count.</param>
        /// <returns></returns>
        public TroopUnit AddTroopCount(int troopCount)
        {
            count = troopCount;
            return this;
        }

        private string attribute;
        private string classAttribute;
        private int count;
        private string sendTroopsTextBoxName;
    }
}