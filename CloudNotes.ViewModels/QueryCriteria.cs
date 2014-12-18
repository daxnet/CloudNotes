
using Apworks.Storage;

namespace CloudNotes.ViewModels
{
    public class QueryCriteria : ViewModel
    {
        public virtual string FilterExpression
        {
            get;
            set;
        }

        public virtual int? PageSize
        {
            get;
            set;
        }

        public virtual int? PageNumber
        {
            get;
            set;
        }

        public virtual string SortingField
        {
            get;
            set;
        }

        public virtual SortOrder? SortingOrder
        {
            get;
            set;
        }

    }
}
