using Business.Interfaces;
using Entity.Dtos.RolDTO;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los m�todos de negocio especif�cos para la gesti�n de roles.
    /// Hereda operaciones CRUD gen�ricas de <see cref="IBaseBusiness{Rol, RolDto}"/>.
    //</summary>
    public interface IRoleBusiness : IBaseBusiness<Role, RoleDto>
    {

        /// <summary>
        /// Actualiza parcialmente los datos de un rol.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del rol, como nombre o estado.</param>
        ///<returns>True si la actualizaci�n fue exitosa; de lo contario false</returns>
        Task<bool> UpdatePartialRolAsync(UpdateRoleDto dto);

        /// <summary>
        /// Realiza un borrado l�gico del rol, marc�ndolo como inactivo en lugar de eliminarlo f�sicamente.
        /// </summary>
        /// <param name="id">ID del rol a desactivar.</param>
        ///<returns>True si el borrado l�gico fue exitoso; de lo contario false</returns>
        Task<bool> DeleteLogicRolAsync(DeleteLogicalRoleDto dto);
    }
}