using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Entity;

using Business.Services;
using Entity.Model;
using Entity.Dtos.RolDTO;
using Business.Interfaces;
using Data.Interfaces;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Data.Implements.RolUserData;
using Entity.Dtos.RolUserDTO;
using Utilities.Interfaces;


namespace Business.Implements
{
    /// <summary>
    /// Contiene la logica de negocio de los metodos especificos para la entidad Rol
    /// Extiende BaseBusiness heredando la logica de negocio de los metodos base 
    /// </summary>
    public class RolBusiness : BaseBusiness<Rol, RolDto>, IRolBusiness
    {
        ///<summary>Proporciona acceso a los metodos de la capa de datos de roles</summary>
        private readonly IRolData _rolData;

        /// <summary>
        /// Constructor de la clase RolBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con roles.
        /// </summary>
        public RolBusiness(IRolData rolData, IMapper mapper, ILogger<RolBusiness> logger, IGenericIHelpers helpers)
      : base(rolData, mapper, logger, helpers)
        {
            _rolData = rolData;
        }


        ///<summary>
        /// Actualiza parcialmente un rol en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialRolAsync(UpdateRolDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");


            var rol = _mapper.Map<Rol>(dto);

            var result = await _rolData.UpdatePartial(rol); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Desactiva un rol en la base de datos
        /// </summary>
        public async Task<bool> DeleteLogicRolAsync(DeleteLogiRolDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del rol es inválido");

            var exists = await _rolData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("rol", dto.Id);

            return await _rolData.ActiveAsync(dto.Id, dto.Status);
        }

    }
}