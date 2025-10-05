namespace GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Response
{
    public class TipoAlmacenConsultarRE
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public bool activo { get; set; }
        public string estado { get; set; } = string.Empty;
    }
}
