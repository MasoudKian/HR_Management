﻿using HR_Management.Application.Models;
using System.Threading.Tasks;

namespace HR_Management.Application.Contract.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
