using Utilities.Interfaces;
using Microsoft.AspNetCore.Http;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Utilities.Helpers
{
    public class GenericHelpers : IGenericIHelpers
    {
        private readonly IDatetimeHelper _datetimeHelper;
        private readonly IPasswordHelper _passwordHelper;
        private readonly IAuthHeaderHelper _authHeaderHelper;
        private readonly IRoleHelper _roleHelper;
        private readonly IUserHelper _userHelper;
        private readonly IValidationHelper _validationHelper;

        public GenericHelpers(
            IDatetimeHelper datetimeHelper,
            IPasswordHelper passwordHelper,
            IAuthHeaderHelper authHeaderHelper,
            IRoleHelper roleHelper,
            IUserHelper userHelper,
            IValidationHelper validationHelper)
        {
            _datetimeHelper = datetimeHelper;
            _passwordHelper = passwordHelper;
            _authHeaderHelper = authHeaderHelper;
            _roleHelper = roleHelper;
            _userHelper = userHelper;
            _validationHelper = validationHelper;
        }

        public DateTime GetCurrentUtcDateTime() => _datetimeHelper.GetCurrentUtcDateTime();
        public DateTime ConvertToLocalTime(DateTime utcDateTime, string timeZoneId) => _datetimeHelper.ConvertToLocalTime(utcDateTime, timeZoneId);
        public DateTime ConvertToUtc(DateTime localDateTime, string timeZoneId) => _datetimeHelper.ConvertToUtc(localDateTime, timeZoneId);
        public string FormatDateTime(DateTime dateTime, string format = null) => _datetimeHelper.FormatDateTime(dateTime, format);
        public int CalculateAge(DateTime birthDate) => _datetimeHelper.CalculateAge(birthDate);
        public bool IsWeekend(DateTime date) => _datetimeHelper.IsWeekend(date);
        public bool IsBusinessHour(DateTime dateTime, int startHour = 9, int endHour = 17) => _datetimeHelper.IsBusinessHour(dateTime, startHour, endHour);

        public string HashPassword(string password) => _passwordHelper.HashPassword(password);
        public bool VerifyPassword(string hashedPassword, string providedPassword) => _passwordHelper.VerifyPassword(hashedPassword, providedPassword);
        public string GenerateRandomPassword(int length = 12) => _passwordHelper.GenerateRandomPassword(length);

        public string ExtractBearerToken(HttpRequest request) => _authHeaderHelper.ExtractBearerToken(request);
        public (string username, string password) ExtractBasicAuth(HttpRequest request) => _authHeaderHelper.ExtractBasicAuth(request);
        public bool TryGetBearerToken(HttpRequest request, out string token) => _authHeaderHelper.TryGetBearerToken(request, out token);

        public bool HasPermission(IEnumerable<string> userRole, string requiredPermission) => _roleHelper.HasPermission(userRole, requiredPermission);
        public bool IsInRole(IEnumerable<string> userRole, string roleName) => _roleHelper.IsInRole(userRole, roleName);
        public bool HasAnyRole(IEnumerable<string> userRole, IEnumerable<string> requiredRole) => _roleHelper.HasAnyRole(userRole, requiredRole);
        public string GetHighestRole(IEnumerable<string> userRole, IDictionary<string, int> rolePriorities) => _roleHelper.GetHighestRole(userRole, rolePriorities);


        public bool IsValidEmail(string email) => _userHelper.IsValidEmail(email);
        public bool IsValidUsername(string username) => _userHelper.IsValidUsername(username);
        public string NormalizeUsername(string username) => _userHelper.NormalizeUsername(username);


        public bool IsValidPhoneNumber(string phoneNumber) => _validationHelper.IsValidPhoneNumber(phoneNumber);
        public bool IsStrongPassword(string password) => _validationHelper.IsStrongPassword(password);
        public bool IsValidUrl(string url) => _validationHelper.IsValidUrl(url);
        public bool IsValidIp(string ipAddress) => _validationHelper.IsValidIp(ipAddress);
        public bool IsValidCreditCard(string cardNumber) => _validationHelper.IsValidCreditCard(cardNumber);
        public bool IsValidIdentityNumber(string identityNumber) => _validationHelper.IsValidIdentityNumber(identityNumber);
        public Task<ValidationResult> Validate<T>(T dto) => _validationHelper.Validate(dto);

    }
}