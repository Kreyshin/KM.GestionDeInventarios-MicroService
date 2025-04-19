namespace GI.Dominio.Comunes
{
    public class ListResponse<T> : RepositoryResult
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
    }
}
