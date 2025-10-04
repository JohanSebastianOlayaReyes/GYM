using AutoMapper;
using Business.Implements;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.MembershipDTO;
using Gym;
using Microsoft.Extensions.Logging;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class MembershipBusiness : BaseBusiness<Membership, MembershipDto>, IMembershipBusiness
    {
        private readonly IMembershipData _membershipData;

        public MembershipBusiness(
            IMembershipData data,
            IMapper mapper,
            ILogger<MembershipBusiness> logger,
            IGenericIHelpers helpers)
            : base(data, mapper, logger, helpers)
        {
            _membershipData = data;
        }

        public async Task<IEnumerable<MembershipDto>> GetByUserIdAsync(int userId)
        {
            try
            {
                var memberships = await _membershipData.GetByUserIdAsync(userId);
                return _mapper.Map<IEnumerable<MembershipDto>>(memberships);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener membresías del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<MembershipDto>> GetActiveMembershipsAsync()
        {
            try
            {
                var memberships = await _membershipData.GetActiveMembershipsAsync();
                return _mapper.Map<IEnumerable<MembershipDto>>(memberships);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener membresías activas: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<MembershipDto>> GetExpiredMembershipsAsync()
        {
            try
            {
                var memberships = await _membershipData.GetExpiredMembershipsAsync();
                return _mapper.Map<IEnumerable<MembershipDto>>(memberships);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener membresías expiradas: {ex.Message}");
                throw;
            }
        }

        public async Task<MembershipDto> GetCurrentMembershipByUserIdAsync(int userId)
        {
            try
            {
                var membership = await _membershipData.GetCurrentMembershipByUserIdAsync(userId);
                return _mapper.Map<MembershipDto>(membership);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener membresía actual del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene membresías que están próximas a expirar
        /// </summary>
        /// <param name="daysUntilExpiration">Número de días hasta la expiración</param>
        /// <returns>Lista de membresías próximas a expirar</returns>
        public async Task<IEnumerable<MembershipDto>> GetExpiringMembershipsAsync(int daysUntilExpiration)
        {
            try
            {
                var memberships = await _membershipData.GetExpiringMembershipsAsync(daysUntilExpiration);
                return _mapper.Map<IEnumerable<MembershipDto>>(memberships);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener membresías próximas a expirar en {daysUntilExpiration} días: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene membresías por tipo
        /// </summary>
        /// <param name="type">Tipo de membresía a buscar</param>
        /// <returns>Lista de membresías del tipo especificado</returns>
        public async Task<IEnumerable<MembershipDto>> GetByTypeAsync(string type)
        {
            try
            {
                var memberships = await _membershipData.GetByTypeAsync(type);
                return _mapper.Map<IEnumerable<MembershipDto>>(memberships);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener membresías de tipo '{type}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Extiende la duración de una membresía
        /// </summary>
        /// <param name="membershipId">ID de la membresía a extender</param>
        /// <param name="additionalDays">Días adicionales a agregar</param>
        /// <returns>True si la extensión fue exitosa, false en caso contrario</returns>
        public async Task<bool> ExtendMembershipAsync(int membershipId, int additionalDays)
        {
            try
            {
                return await _membershipData.ExtendMembershipAsync(membershipId, additionalDays);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al extender membresía {membershipId} por {additionalDays} días: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifica si un usuario tiene una membresía activa
        /// </summary>
        /// <param name="userId">ID del usuario a verificar</param>
        /// <returns>True si el usuario tiene una membresía activa, false en caso contrario</returns>
        public async Task<bool> HasActiveMembershipAsync(int userId)
        {
            try
            {
                return await _membershipData.HasActiveMembershipAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al verificar membresía activa del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el número total de membresías activas
        /// </summary>
        /// <returns>Cantidad de membresías activas</returns>
        public async Task<int> GetActiveMembershipsCountAsync()
        {
            try
            {
                return await _membershipData.GetActiveMembershipsCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener cantidad de membresías activas: {ex.Message}");
                throw;
            }
        }
    }
}
