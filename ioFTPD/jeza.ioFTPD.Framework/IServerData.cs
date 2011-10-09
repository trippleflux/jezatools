using System.Collections.Generic;

namespace jeza.ioFTPD.Framework
{
    public interface IServerData
    {
        /// <summary>
        /// Gets users.
        /// </summary>
        /// <returns>List of users.</returns>
        List<UserFile> GetUsers();

        /// <summary>
        /// Gets groups.
        /// </summary>
        /// <returns>List of groups.</returns>
        List<GroupFile> GetGroups();

        /// <summary>
        /// Gets the spedified user.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns>User data.</returns>
        UserFile GetUser(int uid);

        /// <summary>
        /// Gets the specified group.
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns>Group data.</returns>
        GroupFile GetGroup(int gid);

        /// <summary>
        /// Adds new user.
        /// </summary>
        /// <param name="userFile">The user file.</param>
        /// <returns><c>true</c> when user was successfull added, else <c>false</c>.</returns>
        bool UserAdd(UserFile userFile);

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="userFile">The user file.</param>
        /// <returns><c>true</c> when user was successfull updated, else <c>false</c>.</returns>
        bool UserUpdate(UserFile userFile);

        /// <summary>
        /// Removes the specified user.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns><c>true</c> when user was successfull removed, else <c>false</c>.</returns>
        bool UserDelete(int uid);

        /// <summary>
        /// Add new group.
        /// </summary>
        /// <param name="groupFile">The group file.</param>
        /// <returns><c>true</c> when group was successfull removed, else <c>false</c>.</returns>
        bool GroupAdd(GroupFile groupFile);

        /// <summary>
        /// Update specified group.
        /// </summary>
        /// <param name="groupFile">The group file.</param>
        /// <returns><c>true</c> when group was successfull updated, else <c>false</c>.</returns>
        bool GroupUpdate(GroupFile groupFile);

        /// <summary>
        /// Remove specified group.
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns><c>true</c> when group was successfull removed, else <c>false</c>.</returns>
        bool GroupRemove(int gid);
    }
}