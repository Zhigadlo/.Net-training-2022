using Microsoft.Data.SqlClient;

namespace ORM.Interfaces
{
    /// <summary>
    /// Fabric with CRUD operations. Before working, you need to open a connection.
    /// </summary>
    public interface IEntityFabric<T> : IDisposable where T : IEntity
    {
        public SqlConnection Connection { get; }
        /// <summary>
        /// Writes an object to the database
        /// </summary>
        /// <param name="entity">new object for writing</param>
        public void Insert(T entity);
        /// <summary>
        /// Gets an object from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Read(int id);
        /// <summary>
        /// Updates an object by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEntity"></param>
        public void Update(int id, T newEntity);
        /// <summary>
        /// Deletes an objects by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
    }
}
