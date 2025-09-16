namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request
{
    public class AlmacenCrearRQ
    {
        public string codigo { set; get; }
        public string nombre { set; get; }
        public string direccion { set; get; }
        public int idTipoAlmacen { set; get; }
        public string ubigeo { set; get; }
        public string telefono { set; get; }
        public string latitud { set; get; }
        public string longitud { set; get; }
    }
}
