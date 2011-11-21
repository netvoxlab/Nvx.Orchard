using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Nvx.Fields {
    public class Migrations : DataMigrationImpl {

        public int Create() {
			// Creating table opg__Nvx_Fields_MapRecord
			SchemaBuilder.CreateTable("MapRecord", table => table
				.ContentPartRecord()
				.Column("Latitude", DbType.Double)
				.Column("Longitude", DbType.Double)
				.Column("Address", DbType.String)
			);



            return 1;
        }
    }
}