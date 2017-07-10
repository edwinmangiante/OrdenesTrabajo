using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesTrabajo.ClasesUtiles
{
    public class SortableSearchableList<T> : BindingList<T>, IBindingListView
    {
        public SortableSearchableList()
        {
        }

        public SortableSearchableList(IEnumerable<T> collection)
        {
            if (collection == null)
                return;

            foreach (T t in collection)
            {
                this.Add(t);
            }
        }

        public SortableSearchableList(T item)
        {
            if (item == null)
                return;

            this.Add(item);
        }

        public override void EndNew(int itemIndex)
        {
            if (sortPropertyValue != null && itemIndex == this.Count - 1)
                ApplySortCore(this.sortPropertyValue, this.sortDirectionValue);

            base.EndNew(itemIndex);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                return;

            foreach (T t in collection)
            {
                this.Add(t);
            }
        }

        public IEnumerable<T> GetRange(int index, int count)
        {
            return this.ToList().GetRange(index, count);
        }

        ListSortDirection sortDirectionValue;
        PropertyDescriptor sortPropertyValue;
        bool isSortedValue;

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortPropertyValue; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirectionValue; }
        }

        protected override bool IsSortedCore
        {
            get { return isSortedValue; }
        }

        public void RemoveSort()
        {
            RemoveSortCore();
        }

        //private ArrayList sortedList;
        ArrayList unsortedItems;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            ArrayList sortedList = new ArrayList();
            // Check to see if the property type we are sorting by implements
            // the IComparable interface.
            Type interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType == null && prop.PropertyType.IsValueType)
            {
                Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);
                // Nullable.GetUnderlyingType only returns a non-null value if the
                // supplied type was indeed a nullable type.
                if (underlyingType != null)
                    interfaceType = underlyingType.GetInterface("IComparable");
            }

            if (interfaceType != null)
            {
                // If so, set the SortPropertyValue and SortDirectionValue.
                sortPropertyValue = prop;
                sortDirectionValue = direction;
                isSortedValue = true;

                unsortedItems = new ArrayList(this.Count);

                // Loop through each item, adding it the the sortedItems ArrayList.
                foreach (Object item in this.Items)
                {
                    sortedList.Add(prop.GetValue(item));
                    unsortedItems.Add(item);
                }

                // Call Sort on the ArrayList.
                sortedList.Sort();
                T temp;

                // Check the sort direction and then copy the sorted items
                // back into the list.
                if (direction == ListSortDirection.Descending)
                    sortedList.Reverse();

                for (int i = 0; i < this.Count; i++)
                {
                    int position = Find(prop.Name, sortedList[i], i);
                    if (position != i && position > i)
                    {
                        temp = this[i];
                        this[i] = this[position];
                        this[position] = temp;
                    }
                }
                // Raise the ListChanged event so bound controls refresh their
                // values.
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            else
                // If the property type does not implement IComparable, let the user
                // know.
                throw new NotSupportedException("Cannot sort by " + prop.Name + ". This" +
                    prop.PropertyType.ToString() + " does not implement IComparable");
        }

        protected override void RemoveSortCore()
        {
            int position;
            object temp;
            // Ensure the list has been sorted.
            if (unsortedItems != null)
            {
                // Loop through the unsorted items and reorder the
                // list per the unsorted list.
                for (int i = 0; i < unsortedItems.Count;)
                {
                    position = this.Find(sortPropertyValue.Name,
                        unsortedItems[i].GetType().
                        GetProperty(sortPropertyValue.Name).GetValue(unsortedItems[i], null), i);
                    if (position >= 0 && position != i)
                    {
                        temp = this[i];
                        this[i] = this[position];
                        this[position] = (T)temp;
                        i++;
                    }
                    else if (position == i)
                        i++;
                    else
                        // If an item in the unsorted list no longer exists, delete it.
                        unsortedItems.RemoveAt(i);
                }
                isSortedValue = false;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            return FindCore(prop, key, 0);

            // Get the property info for the specified property.
            //System.Reflection.PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
            //T item;

            //if (key != null)
            //{
            //    // Loop through the the items to see if the key
            //    // value matches the property value.
            //    for (int i = 0; i < Count; ++i)
            //    {
            //        item = (T)Items[i];
            //        if (propInfo.GetValue(item, null).Equals(key))
            //            return i;
            //    }
            //}
            //return -1;
        }

        private int FindCore(PropertyDescriptor prop, object key, int index)
        {
            if (key != null || prop.PropertyType.IsValueType)
            {
                // Get the property info for the specified property.
                System.Reflection.PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
                T item;

                // Loop through the the items to see if the key
                // value matches the property value.
                for (int i = index; i < Count; ++i)
                {
                    item = (T)Items[i];
                    object value = propInfo.GetValue(item, null);
                    if ((key != null && value != null && value.Equals(key) ||
                         key == null && value == null && prop.PropertyType.IsValueType))
                        return i;
                }
            }

            return -1;
        }

        public int Find(string property, object key)
        {
            return Find(property, key, 0);

            // Check the properties for a property with the specified name.
            //PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            //PropertyDescriptor prop = properties.Find(property, true);

            //// If there is not a match, return -1 otherwise pass search to
            //// FindCore method.
            //if (prop == null)
            //    return -1;
            //else
            //    return FindCore(prop, key);
        }

        public int Find(string property, object key, int fromIndex)
        {
            // Check the properties for a property with the specified name.
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor prop = properties.Find(property, true);

            // If there is not a match, return -1 otherwise pass search to
            // FindCore method.
            if (prop == null)
                return -1;
            else
                return FindCore(prop, key, fromIndex);
        }

        #region Persistence

        // NOTE: BindingList<T> is not serializable but List<T> is

        public void Save(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                // Serialize data list items
                formatter.Serialize(stream, (List<T>)this.Items);
            }
        }

        public void Load(string filename)
        {
            this.ClearItems();

            if (File.Exists(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    // Deserialize data list items
                    ((List<T>)this.Items).AddRange((IEnumerable<T>)formatter.Deserialize(stream));
                }
            }

            // Let bound controls know they should refresh their views
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        #endregion

        #region IBindingListView

        private ListSortDescriptionCollection _SortDescriptions;

        private List<PropertyComparer<T>> comparers;

        public ListSortDescriptionCollection SortDescriptions
        {
            get { return _SortDescriptions; }
        }

        public bool SupportsAdvancedSorting
        {
            get { return true; }
        }

        private int CompareValuesByProperties(T x, T y)
        {
            if (x == null)
                return (y == null) ? 0 : -1;
            else
            {
                if (y == null)
                    return 1;
                else
                {
                    foreach (PropertyComparer<T> comparer in comparers)
                    {
                        int retval = comparer.Compare(x, y);
                        if (retval != 0)
                            return retval;
                    }
                    return 0;
                }
            }
        }

        public void ApplySort(ListSortDescriptionCollection sorts)
        {
            // Get list to sort
            // Note: this.Items is a non-sortable ICollection<T>
            List<T> items = this.Items as List<T>;

            // Apply and set the sort, if items to sort
            if (items != null)
            {
                _SortDescriptions = sorts;
                comparers = new List<PropertyComparer<T>>();
                foreach (ListSortDescription sort in sorts)
                    comparers.Add(new PropertyComparer<T>(sort.PropertyDescriptor,
                        sort.SortDirection));
                items.Sort(CompareValuesByProperties);
                //_isSorted = true;
            }
            else
            {
                //_isSorted = false;
            }

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        public string Filter
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void RemoveFilter()
        {
            throw new NotImplementedException();
        }

        public bool SupportsFiltering
        {
            get { return false; }
        }

        private class PropertyComparer<T> : System.Collections.Generic.IComparer<T>
        {
            private PropertyDescriptor _property;
            private ListSortDirection _direction;

            public PropertyComparer(PropertyDescriptor property,
                ListSortDirection direction)
            {
                _property = property;
                _direction = direction;
            }

            #region IComparer<T>

            public int Compare(T xWord, T yWord)
            {
                // Get property values
                object xValue = GetPropertyValue(xWord, _property.Name);
                object yValue = GetPropertyValue(yWord, _property.Name);

                // Determine sort order
                if (_direction == ListSortDirection.Ascending)
                {
                    return CompareAscending(xValue, yValue);
                }
                else
                {
                    return CompareDescending(xValue, yValue);
                }
            }

            public bool Equals(T xWord, T yWord)
            {
                return xWord.Equals(yWord);
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }

            #endregion

            // Compare two property values of any type
            private int CompareAscending(object x, object y)
            {
                int result;

                // If values implement IComparer
                if (x is IComparable)
                {
                    result = ((IComparable)x).CompareTo(y);
                }
                // If values don't implement IComparer but are equivalent
                else if (x.Equals(y))
                {
                    result = 0;
                }
                // Values don't implement IComparer and are not equivalent,
                // so compare as typed values
                else result = ((IComparable)x).CompareTo(y);

                // Return result
                return result;
            }

            private int CompareDescending(object x, object y)
            {
                // Return result adjusted for ascending or descending sort order ie
                // multiplied by 1 for ascending or -1 for descending
                return -CompareAscending(x, y);
            }

            private object GetPropertyValue(T value, string property)
            {
                // Get property
                System.Reflection.PropertyInfo propertyInfo = value.GetType().GetProperty(property);

                // Return value
                return propertyInfo.GetValue(value, null);
            }
        }

        #endregion
    }
}
