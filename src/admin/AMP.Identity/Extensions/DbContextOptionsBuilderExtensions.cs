﻿// Copyright (c) 2021 @Olivier Lefebvre. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.Extensions.Configuration;
using AMP.Identity.Models;

namespace Microsoft.EntityFrameworkCore
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseDatabaseFromConfiguration(this DbContextOptionsBuilder options, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var dbType = configuration.GetValue<DbTypes>("DbType");
            switch (dbType)
            {
                case DbTypes.InMemory:
                    options.UseInMemoryDatabase(connectionString);
                    break;
                case DbTypes.SqlServer:
                    options.UseSqlServer(connectionString, options => options.MigrationsAssembly("Aguacongas.TheIdServer.Migrations.SqlServer"));
                    break;
                case DbTypes.Sqlite:
                    options.UseSqlite(connectionString, options => options.MigrationsAssembly("Aguacongas.TheIdServer.Migrations.Sqlite"));
                    break;
                case DbTypes.MySql:
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options => options.MigrationsAssembly("Aguacongas.TheIdServer.Migrations.MySql"));
                    break;
                case DbTypes.Oracle:
                    options.UseOracle(connectionString, options => options.MigrationsAssembly("Aguacongas.TheIdServer.Migrations.Oracle"));
                    break;
                case DbTypes.PostgreSQL:
                    options.UseNpgsql(connectionString, options => options.MigrationsAssembly("Aguacongas.TheIdServer.Migrations.PostgreSQL"));
                    break;
            }
            return options;
        }
    }
}
