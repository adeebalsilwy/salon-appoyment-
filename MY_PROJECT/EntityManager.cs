using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_PROJECT
{
    public abstract class EntityManager<T> where T : Entity
    {
        protected List<T> entities;

        public EntityManager()
        {
            entities = new List<T>();
            LoadData();
        }

        public abstract void Add(T entity);
        public abstract void Display();
        public abstract void SaveData();
        public abstract void LoadData();
    }
}
