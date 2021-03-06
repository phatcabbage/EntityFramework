// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;

namespace Microsoft.Data.Entity.Relational.FunctionalTests
{
    public abstract class MappingQueryFixtureBase
    {
        protected Model CreateModel()
        {
            var model = new Model();
            var modelBuilder = new BasicModelBuilder(model);

            modelBuilder.Entity<MappingQueryTestBase.MappedCustomer>(e =>
                {
                    e.Key(c => c.CustomerID);
                    e.Property(c => c.CompanyName2).Metadata.Relational().Column = "Broken";
                    e.Metadata.Relational().Table = "Broken";
                    e.Metadata.Relational().Schema = "wrong";
                });

            modelBuilder.Entity<MappingQueryTestBase.MappedEmployee>(e =>
                {
                    e.Key(em => em.EmployeeID);
                    e.Property(em => em.City2).Metadata.Relational().Column = "City";
                    e.Metadata.Relational().Table = "Employees";
                    e.Metadata.Relational().Schema = "dbo";
                });

            modelBuilder.Entity<MappingQueryTestBase.MappedOrder>(e =>
                {
                    e.Key(o => o.OrderID);
                    e.Property(em => em.ShipVia2).Metadata.Relational().Column = "ShipVia";
                    e.Metadata.Relational().Table = "Orders";
                    e.Metadata.Relational().Schema = "dbo";
                });

            OnModelCreating(modelBuilder);

            return model;
        }

        protected virtual void OnModelCreating(BasicModelBuilder modelBuilder)
        {
        }
    }
}
