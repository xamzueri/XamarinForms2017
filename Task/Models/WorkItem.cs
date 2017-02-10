using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Task.Models
{

    public class WorkItem
    {
        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public bool Done
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{Title}\n{Description}";
        }
    }
}
