using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using orders.appliaction.contracts.infrastructure;
using orders.appliaction.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.infrastructure.email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;
        private readonly ILogger<EmailService> logger;

        public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
        {
            emailSettings = mailSettings.Value;
            this.logger = logger;
        }
        public async Task<bool> SendEmail(Email email)
        {
            logger.LogInformation("The email service does not send emails, it is an mock email service.");

            return true;
        }
    }
}
