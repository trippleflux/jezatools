#region

using System;

#endregion

namespace ProductTracker
{
    public class Shop
    {
        public Shop()
        {
        }

        public Shop(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>The same object.</returns>
        public Shop AddAddress(string address)
        {
            Address = address;
            return this;
        }

        /// <summary>
        /// Adds the owner.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>The same object.</returns>
        public Shop AddOwner(string owner)
        {
            Owner = owner;
            return this;
        }

        /// <summary>
        /// Adds the postal code.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns>The same object.</returns>
        public Shop AddPostalCode(int postalCode)
        {
            PostalCode = postalCode;
            return this;
        }

        /// <summary>
        /// Adds the city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns>The same object.</returns>
        public Shop AddCity(string city)
        {
            City = city;
            return this;
        }

        /// <summary>
        /// The shop is a company.
        /// </summary>
        /// <returns>The same object.</returns>
        public Shop IsACompany()
        {
            IsCompany = true;
            return this;
        }

        /// <summary>
        /// Gets or sets the id of the shop.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the shop.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the shop.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the owner of the shop.
        /// </summary>
        /// <value>The owner.</value>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        public int PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city where the shop is.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the shop is company or a single person.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is company; otherwise, <c>false</c>.
        /// </value>
        public bool IsCompany { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Name: {1}, Address: {2}, Owner: {3}, PostalCode: {4}, City: {5}, IsCompany: {6}", Id, Name,
                    Address, Owner, PostalCode, City, IsCompany);
        }
    }
}