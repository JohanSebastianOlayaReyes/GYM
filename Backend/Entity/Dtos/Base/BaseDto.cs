namespace Entity.Dtos.Base
{
    /// <summary>
    /// Clase base para los DTOs que contiene propiedades comunes
    /// </summary>
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
