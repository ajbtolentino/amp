﻿// Copyright (c) 2021 @Olivier Lefebvre. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
namespace AMP.Identity.Models
{
    public class RavenDbOptions
    {
        public string[] Urls { get; set; }

        public string Database { get; set; }

        public string CertificatePath { get; set; }

        public string CertificatePassword { get; set; }
    }
}
