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
        /// <returns><c>UID</c> when user was successfull added, else <c>-1</c>.</returns>
        int UserAdd(UserFile userFile);

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
        /// <returns><c>GID</c> when group was successfull removed, else <c>-1</c>.</returns>
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

        /// <summary>
        /// Change file or dir owner id or permissions (mode).
        /// </summary>
        /// <param name="mode">File or directory mode. Like 755</param>
        /// <param name="uid">User id</param>
        /// <param name="gid">Group Id</param>
        /// <param name="fileOrPath">File or path.</param>
        /// <example>printf("!vfs:add 777 101:101 D:\\desktop\\ioFTPD\\test\n");</example>
        void VfsAdd(int mode, int uid, int gid, string fileOrPath);

        /// <summary>
        /// Create ioFTPD symlink.
        /// </summary>
        /// <param name="realPath">Real path on disk.</param>
        /// <param name="virtualPath">Virtual path</param>
        void CreateSymlink(string realPath, string virtualPath);

        /// <summary>
        /// Gets directory or file attributes.
        /// </summary>
        /// <param name="fileOrPath">File or path.</param>
        /// <example>Get MODE, UID, GID for the specifed directory or path.</example>
        T GetAttributes(string fileOrPath);

        /// <summary>
        /// Check who is online.
        /// </summary>
        /// <returns>List of online data.</returns>
        List<OnlineData> WhoIsOnline();

        /// <summary>
        /// Kicks user from specified directory.
        /// </summary>
        /// <param name="uid">The user id.</param>
        /// <param name="path">Directory full path.</param>
        /// <returns><c>true</c> on success, else <c>false</c>.</returns>
        bool UserKick(int uid, string path);
    }
}