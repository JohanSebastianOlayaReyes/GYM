using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace Utilities.Interfaces
{
    /// <summary>
    /// Interfaz unificada que agrupa utilidades generales para validación, manejo de usuarios, roles, fechas, contraseñas y encabezados de autenticación.
    /// Hereda de <see cref="IPasswordHelper"/>, <see cref="IAuthHeaderHelper"/>, <see cref="IDatetimeHelper"/>, <see cref="IRoleHelper"/>, <see cref="IUserHelper"/> y <see cref="IValidationHelper"/>.
    /// </summary>
    public interface IGenericIHelpers : IPasswordHelper, IAuthHeaderHelper, IDatetimeHelper, IRoleHelper, IUserHelper, IValidationHelper
    {
    }

}
