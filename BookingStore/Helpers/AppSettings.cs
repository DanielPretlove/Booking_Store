using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingStore.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        // refresh token tgime to live (in days), inactive tokens aree 
        // automatically deleted from the database after this time

        public int RefreshTokenTTL { get; set; }

        public string EmailFrom { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
    }
}