using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ZavrsniRad
{
    public static class LINQExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerableList)
        {
            if (enumerableList != null)
            {

                var observableCollection = new ObservableCollection<T>();

                foreach (var item in enumerableList)
                {
                    observableCollection.Add(item);
                }

                return observableCollection;
            }
            return null;

        }
    }
}

