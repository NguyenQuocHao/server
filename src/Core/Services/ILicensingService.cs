﻿using System.Threading.Tasks;
using Bit.Core.Entities;
using Bit.Core.Models.Business;

namespace Bit.Core.Services
{
    public interface ILicensingService
    {
        Task ValidateOrganizationsAsync();
        Task ValidateUsersAsync();
        Task<bool> ValidateUserPremiumAsync(User user);
        bool VerifyLicense(ILicense license);
        byte[] SignLicense(ILicense license);
    }
}
