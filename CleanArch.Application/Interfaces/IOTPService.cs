﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IOTPService
    {
        void sendOtptoMobile(long mobilenumber,int otp);
    }
}
