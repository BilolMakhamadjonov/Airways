﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.DataAccess.Authentication;

public interface IPasswordHasher
{
    string Encrypt(string password, string salt);
    bool Verify(string hash, string password, string salt);
}
