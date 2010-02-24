namespace jeza.Travian.Framework
{
    /// <summary>
    /// Info about production in village.
    /// </summary>
    public class Production
    {
        /// <summary>
        /// Gets the wood per hour.
        /// </summary>
        /// <value>The wood per hour.</value>
        public int WoodPerHour
        {
            get { return woodPerHour; }
        }

        /// <summary>
        /// Gets the clay per hour.
        /// </summary>
        /// <value>The clay per hour.</value>
        public int ClayPerHour
        {
            get { return clayPerHour; }
        }

        /// <summary>
        /// Gets the iron per hour.
        /// </summary>
        /// <value>The iron per hour.</value>
        public int IronPerHour
        {
            get { return ironPerHour; }
        }

        /// <summary>
        /// Gets the crop per hour.
        /// </summary>
        /// <value>The crop per hour.</value>
        public int CropPerHour
        {
            get { return cropPerHour; }
        }

        /// <summary>
        /// Gets the wood total.
        /// </summary>
        /// <value>The wood total.</value>
        public int WoodTotal
        {
            get { return woodTotal; }
        }

        /// <summary>
        /// Gets the clay total.
        /// </summary>
        /// <value>The clay total.</value>
        public int ClayTotal
        {
            get { return clayTotal; }
        }

        /// <summary>
        /// Gets the iron total.
        /// </summary>
        /// <value>The iron total.</value>
        public int IronTotal
        {
            get { return ironTotal; }
        }

        /// <summary>
        /// Gets the crop total.
        /// </summary>
        /// <value>The crop total.</value>
        public int CropTotal
        {
            get { return cropTotal; }
        }

        /// <summary>
        /// Gets the warehouse capacity.
        /// </summary>
        /// <value>The warehouse.</value>
        public int Warehouse
        {
            get { return warehouse; }
        }

        /// <summary>
        /// Gets the granary capacity.
        /// </summary>
        /// <value>The granary.</value>
        public int Granary
        {
            get { return granary; }
        }

        /// <summary>
        /// Updates the warehouse capacyty.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <returns></returns>
        public Production UpdateWarehouse(int capacity)
        {
            warehouse = capacity;
            return this;
        }

        /// <summary>
        /// Updates the granary capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <returns></returns>
        public Production UpdateGranary(int capacity)
        {
            granary = capacity;
            return this;
        }

        /// <summary>
        /// Updates the per hour production in village.
        /// </summary>
        /// <param name="woodValue">The wood value.</param>
        /// <param name="clayValue">The clay value.</param>
        /// <param name="ironValue">The iron value.</param>
        /// <param name="cropValue">The crop value.</param>
        /// <returns></returns>
        public Production UpdatePerHour(int woodValue, int clayValue, int ironValue, int cropValue)
        {
            woodPerHour = woodValue;
            clayPerHour = clayValue;
            ironPerHour = ironValue;
            cropPerHour = cropValue;
            return this;
        }

        /// <summary>
        /// Updates the total resources in village.
        /// </summary>
        /// <param name="woodValue">The wood value.</param>
        /// <param name="clayValue">The clay value.</param>
        /// <param name="ironValue">The iron value.</param>
        /// <param name="cropValue">The crop value.</param>
        /// <returns></returns>
        public Production UpdateTotals(int woodValue, int clayValue, int ironValue, int cropValue)
        {
            woodTotal = woodValue;
            clayTotal = clayValue;
            ironTotal = ironValue;
            cropTotal = cropValue;
            return this;
        }

        private int woodPerHour;
        private int clayPerHour;
        private int ironPerHour;
        private int cropPerHour;

        private int woodTotal;
        private int clayTotal;
        private int ironTotal;
        private int cropTotal;

        private int warehouse;
        private int granary;
    }
}