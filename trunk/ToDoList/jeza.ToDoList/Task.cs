using System;

namespace jeza.ToDoList
{
    [Serializable]
    public class Task
    {
        public string Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StopDate { get; set; }

        public string Location { get; set; }

        public string Head { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public GoogleAccountInfo GoogleAccount { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, GoogleAccountInfo: [{7}], StartDate: {1}, StopDate: {2}, Location: {6}, Head: {3}, Description: {4}, Notes: {5}", Id,
                                 StartDate, StopDate, Head, Description, Notes, Location, GoogleAccount);
        }
    }
}