using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Entity;

using Business.Services;
using Entity.Model;
using Business.Interfaces;
using Data.Interfaces;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Dtos.PermissionDto;
using Entity.Dtos.Permission;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Permission.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class PermissionBusiness : BaseBusiness<Permission, PermissionDto>, IPermissionBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de Permission</summary>
        private readonly IPermissionData _permissionData;

        /// <summary>
        /// Constructor de la clase PermissionBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con Permission.
        /// </summary>
        public PermissionBusiness(IPermissionData permissionData, IMapper mapper, ILogger<PermissionBusiness> logger, IGenericIHelpers helpers)
            : base(permissionData, mapper, logger, helpers)
        {
            _permissionData = permissionData;
        }

        ///<summary>
        /// Actualiza parcialmente un Permission en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialPermissionAsync(UpdatePermissionDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var permission = _mapper.Map<Permission>(dto);

            var result = await _permissionData.UpdatePartial(permission); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Desactiva un Permission en la base de datos
        /// </summary>
        public async Task<bool> DeleteLogicPermissionAsync(DeleteLogiPermissionDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del permiso es inválido");

            var exists = await _permissionData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("permission", dto.Id);

            return await _permissionData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
