using System.Collections.Generic;

namespace jeza.ToDoList
{
    public interface ITaskManager
    {
        /// <summary>
        /// Deletes the specified task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        bool Delete(Task task);

        /// <summary>
        /// Inserts the specified task.
        /// </summary>
        /// <param name="task">The task <see cref="Task"/>.</param>
        /// <returns></returns>
        bool Insert(Task task);

        /// <summary>
        /// Fetch the event list for specified account.
        /// </summary>
        /// <param name="accountInfo">The account info <see cref="IAccountInfo"/>.</param>
        /// <returns><see cref="List{T}"/></returns>
        List<Task> Query(IAccountInfo accountInfo);

        /// <summary>
        /// Updates the specified task.
        /// </summary>
        /// <param name="task">The task <see cref="Task"/>.</param>
        /// <returns></returns>
        bool Update(Task task);
    }
}