﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebLabs.DAL.Entities
{
   public class ApplicationUser:IdentityUser
    {
        public byte[] AvatarImage { get; set; }
        public string ImageMimeType { get; set; }
    }
}
