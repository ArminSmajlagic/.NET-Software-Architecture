using orders.appliaction.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.contracts.infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
