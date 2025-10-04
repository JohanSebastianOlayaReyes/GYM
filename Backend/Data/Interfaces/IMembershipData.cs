using Gym;

namespace Data.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones de datos específicas de membresías del gimnasio
    /// </summary>
    public interface IMembershipData : IBaseModelData<Membership>
    {
        /// <summary>
        /// Obtiene todas las membresías de un usuario específico
        /// </summary>
        Task<IEnumerable<Membership>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Obtiene todas las membresías activas (no expiradas)
        /// </summary>
        Task<IEnumerable<Membership>> GetActiveMembershipsAsync();

        /// <summary>
        /// Obtiene todas las membresías expiradas
        /// </summary>
        Task<IEnumerable<Membership>> GetExpiredMembershipsAsync();

        /// <summary>
        /// Obtiene la membresía actual activa de un usuario
        /// </summary>
        Task<Membership> GetCurrentMembershipByUserIdAsync(int userId);

        /// <summary>
        /// Obtiene membresías que expiran en los próximos días especificados
        /// </summary>
        Task<IEnumerable<Membership>> GetExpiringMembershipsAsync(int daysUntilExpiration);

        /// <summary>
        /// Obtiene membresías por tipo (mensual, semanal, diaria, etc.)
        /// </summary>
        Task<IEnumerable<Membership>> GetByTypeAsync(string type);

        /// <summary>
        /// Extiende una membresía agregando días adicionales
        /// </summary>
        Task<bool> ExtendMembershipAsync(int membershipId, int additionalDays);

        /// <summary>
        /// Verifica si un usuario tiene una membresía activa
        /// </summary>
        Task<bool> HasActiveMembershipAsync(int userId);

        /// <summary>
        /// Obtiene el número total de membresías activas
        /// </summary>
        Task<int> GetActiveMembershipsCountAsync();
    }
}
