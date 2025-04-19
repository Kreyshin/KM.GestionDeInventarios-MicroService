namespace GI.Dominio.Comunes
{
    public class SingleResponse<T> : RepositoryResult
    {
        public T? Data { get; set; }
    }
}
