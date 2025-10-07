using Business.Implements;
using Entity;
using Entity.Dtos.RolUserDTO;
using Entity.Model;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los m�todos de negocio espec�ficos para la gesti�n de relaciones entre usuarios y roles.
    /// Hereda operaciones CRUD gen�ricas de  <see cref="IBaseBusiness{RolUser, RolUserDto}"/>.
    ///</summary>
    public interface IRoleUserBusiness : IBaseBusiness<UserRole, UserRoleDto>
    {
        /// <summary>
        /// Actualiza parcialmente la relaci�n entre un usuario y un rol.
        /// </summary>
        /// <param name="id">ID de la relaci�n usuario-rol a actualizar.</param>
        /// <param name="roleId">Nuevo ID del rol a asignar al usuario.</param>
        ///<returns>True si la actualizaci�n fue exitosa; de lo contario false</returns>
        Task<bool> UpdateParcialRoleUserAsync(UpdateUserRoleDto dto);
    }
}
