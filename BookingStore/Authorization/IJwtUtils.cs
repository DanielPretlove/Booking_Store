using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingStore.Entities;

namespace BookingStore.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Account account);
        public int? ValidateJwtToken(string token);
        public RefreshToken GenerateRefreshToken(string ipAddress);
    }
}