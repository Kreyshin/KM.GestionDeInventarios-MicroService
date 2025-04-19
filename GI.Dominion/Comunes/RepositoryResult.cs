namespace GI.Dominio.Comunes
{
    public abstract class RepositoryResult
    {
        public int StatusCode { get; set; } = 0;
        public int ErrorCode { set; get; } = 0;
        public string ErrorMessage { set; get; } = "";
        public string StatusMessage { get; set; } = "Correcto";
        public string StatusType { set; get; }
    }
}
