using System;
using System.Collections.Generic;
using System.Data;
using Nvx.Orchard.Osm.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Nvx.Orchard.Osm {
    public class Migrations : DataMigrationImpl {

        public int Create() {

            // Creating table OpenStreetMapNodeRecord
            SchemaBuilder.CreateTable("OpenStreetMapNodeRecord", table => table
                .ContentPartRecord()
                .Column("Latitude", DbType.Double)
                .Column("Longitude", DbType.Double)
                .Column("NodeId", DbType.Int64)
            );

            ContentDefinitionManager.AlterPartDefinition(
                typeof(OpenStreetMapNodePart).Name, cfg => cfg.Attachable());

            return 1;
        }
    }
}