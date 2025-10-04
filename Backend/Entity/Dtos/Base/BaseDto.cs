namespace Entity.Dtos.Base
{
    /// <summary>
    /// Clase base para los DTOs que contiene propiedades comunes utilizadas en todas las entidades del sistema
    /// </summary>
    public abstract class BaseDto
    {
        /// <summary>
        /// Identificador único del registro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Estado del registro. True para activo, False para inactivo (eliminado lógico)
        /// </summary>
        public bool Status { get; set; }
    }
}
