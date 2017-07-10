using OrdenesTrabajo.ClasesUtiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesTrabajo
{
    public abstract class ColeccionEntidades<T> : INotifyPropertyChanged
    {
        #region Propiedades

        protected SortableSearchableList<T> dataSource = new SortableSearchableList<T>();
        public SortableSearchableList<T> DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
                RaisePropertyChanged("DataSource");
            }
        }

        protected T current = default(T);
        public T Current
        {
            get { return current; }
            set
            {
                if (current == null || !current.Equals(value))
                {
                    current = value;
                    RaisePropertyChanged("Current");
                }
            }
        }

        /// <summary>
        /// Devuelve la posicion del elemento Current dentro de la lista
        /// </summary>
        public Int32 PosicionCurrent
        {
            get
            {
                Int32 position = 0;

                try
                {
                    position = DataSource.IndexOf(Current);
                }
                catch (Exception)
                {
                }

                return position;
            }
        }

        #endregion

        #region Metodos

        public virtual void Limpiar()
        {
            DataSource = new SortableSearchableList<T>();
            Current = default(T);
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged Members
    }
}
