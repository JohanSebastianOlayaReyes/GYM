using Business.Interfaces;
using Entity.Dtos.MembershipDTO;
using Gym;

namespace Business.Interfaces
{
    public interface IMembershipBusiness : IBaseBusiness<Membership, MembershipDto>
    {
        Task<IEnumerable<MembershipDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<MembershipDto>> GetActiveMembershipsAsync();
        Task<IEnumerable<MembershipDto>> GetExpiredMembershipsAsync();
        Task<MembershipDto> GetCurrentMembershipByUserIdAsync(int userId);

        /// <summary>
        /// Obtiene membresías que están próximas a expirar
        /// </summary>
        /// <param name="daysUntilExpiration">Número de días hasta la expiración</param>
        /// <returns>Lista de membresías próximas a expirar</returns>
        Task<IEnumerable<MembershipDto>> GetExpiringMembershipsAsync(int daysUntilExpiration);

        /// <summary>
        /// Obtiene membresías por tipo
        /// </summary>
        /// <param name="type">Tipo de membresía a buscar</param>
        /// <returns>Lista de membresías del tipo especificado</returns>
        Task<IEnumerable<MembershipDto>> GetByTypeAsync(string type);

        /// <summary>
        /// Extiende la duración de una membresía
        /// </summary>
        /// <param name="membershipId">ID de la membresía a extender</param>
        /// <param name="additionalDays">Días adicionales a agregar</param>
        /// <returns>True si la extensión fue exitosa, false en caso contrario</returns>
        Task<bool> ExtendMembershipAsync(int membershipId, int additionalDays);

        /// <summary>
        /// Verifica si un usuario tiene una membresía activa
        /// </summary>
        /// <param name="userId">ID del usuario a verificar</param>
        /// <returns>True si el usuario tiene una membresía activa, false en caso contrario</returns>
        Task<bool> HasActiveMembershipAsync(int userId);

        /// <summary>
        /// Obtiene el número total de membresías activas
        /// </summary>
        /// <returns>Cantidad de membresías activas</returns>
        Task<int> GetActiveMembershipsCountAsync();
    }
}
