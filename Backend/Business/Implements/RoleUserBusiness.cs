
using AutoMapper;
using Business.Interfaces;
using Data.Implements.RolUserData;
using Data.Implements.UserDate;
using Data.Interfaces;
using Entity;
using Entity.Dtos.RolUserDTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Utilities.Exceptions;
using Utilities.Interfaces;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad RolUser.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class RoleUserBusiness : BaseBusiness<RolUser, RolUserDto>, IRoleUserBusiness
    {
        /// <summary>
        /// Proporciona acceso a los métodos de la capa de datos de roles de usuario.
        /// </summary>
        private readonly IRolUserData _rolUserData;

        /// <summary>
        /// Constructor de la clase RoleUserBusiness.
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con roles de usuario.
        /// </summary>
        /// <param name="rolUserData">Repositorio para acceso a datos de roles de usuario.</param>
        /// <param name="mapper">Servicio de mapeo entre DTOs y entidades.</param>
        /// <param name="logger">Servicio de logging para registro de eventos y errores.</param>
        /// <param name="helpers">Implementación de helpers genéricos utilizados por la capa de negocio.</param>
        public RoleUserBusiness(IRolUserData rolUserData, IMapper mapper, ILogger<RoleUserBusiness> logger, IGenericIHelpers helpers)
           : base(rolUserData, mapper, logger, helpers)
        {
            _rolUserData = rolUserData;
        }

        /// <summary>
        /// Actualiza parcialmente un rol de usuario en la base de datos.
        /// Solo actualiza los campos proporcionados en el DTO.
        /// </summary>
        /// <param name="dto">Objeto de transferencia con los datos a actualizar del rol de usuario.</param>
        /// <returns>
        /// True si la actualización fue exitosa; false en caso contrario.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Se lanza cuando el ID del rol de usuario es inválido o cuando no se proporciona
        /// ningún campo para actualizar.
        /// </exception>
        public async Task<bool> UpdateParcialRoleUserAsync(UpdateRolUserDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            if (dto.RolId <= 0 && dto.UserId <= 0)
                throw new ArgumentException("Debe enviar al menos un campo para actualizar.");

            var rolUser = _mapper.Map<RolUser>(dto);
            var result = await _rolUserData.UpdatePartial(rolUser);
            return result;
        }
    }
}