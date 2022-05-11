namespace ORM.Interfaces
{
    /// <summary>
    /// Intrface for fabric with CRUD operations
    /// </summary>
    public interface IEntityFabric
    {
        /// <summary>
        /// Writes an object to the database
        /// </summary>
        /// <param name="entity">new object for writing</param>
        public void Create(IEntity entity);
        /// <summary>
        /// Gets an object from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEntity Read(int id);
        /// <summary>
        /// Updates an object by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEntity"></param>
        public void Update(int id, IEntity newEntity);
        /// <summary>
        /// Deletes an objects by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
    }
}
