using Business.Implements;
using Entity;
using Entity.Dtos.RolUserDTO;
using Entity.Model;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de relaciones entre usuarios y roles.
    /// Hereda operaciones CRUD genéricas de  <see cref="IBaseBusiness{RolUser, RolUserDto}"/>.
    ///</summary>
    public interface IRoleUserBusiness : IBaseBusiness<RolUser, RolUserDto>
    {
        /// <summary>
        /// Actualiza parcialmente la relación entre un usuario y un rol.
        /// </summary>
        /// <param name="id">ID de la relación usuario-rol a actualizar.</param>
        /// <param name="roleId">Nuevo ID del rol a asignar al usuario.</param>
        ///<returns>True si la actualización fue exitosa; de lo contario false</returns>
        Task<bool> UpdateParcialRoleUserAsync(UpdateRolUserDto dto);
    }
}
