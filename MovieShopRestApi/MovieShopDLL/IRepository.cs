using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDLL
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Create an object.
        /// </summary>
        /// <param name="item">Object as parameter</param>
        /// <returns>Returns an object itself</returns>
        T Create(T item);

        /// <summary>
        /// Read one object
        /// </summary>
        /// <param name="id">ID of an object as parameter</param>
        /// <returns>Returns an object itself</returns>
        T Read(int id);

        /// <summary>
        /// Read all objects
        /// </summary>
        /// <returns>Returns the list of all objects</returns>
        List<T> Read();

        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="item">Object as a parameter</param>
        /// <returns>Returns updated object itself.</returns>
        T Update(T item);

        /// <summary>
        /// Delete an object.
        /// </summary>
        /// <param name="id">ID of the object as parameter</param>
        void Delete(int id);
    }
}
