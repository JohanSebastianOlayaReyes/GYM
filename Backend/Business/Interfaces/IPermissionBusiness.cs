using Business.Interfaces;
using Entity.Dtos.Permission;
using Entity.Dtos.PermissionDto;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de permisos (Permission).
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Permission, PermissionDto}"/>.
    ///</summary>
    public interface IPermissionBusiness : IBaseBusiness<Permission, PermissionDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un permiso.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del permiso.</param>
        ///<returns>True si la actualización fue exitosa; de lo contrario false</returns>
        Task<bool> UpdatePartialPermissionAsync(UpdatePermissionDto dto);

        /// <summary>
        /// Realiza un borrado lógico del permiso, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y estado del permiso a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contrario false</returns>
        Task<bool> DeleteLogicPermissionAsync(DeleteLogiPermissionDto dto);
    }
}
