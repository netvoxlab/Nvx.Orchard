using System;
using System.Linq.Expressions;
using Orchard.ContentManagement.MetaData.Models;

namespace Nvx.Orchard.OData.Models {
    public class OrchardQueryContext
    {
        private readonly ContentTypeDefinition _type;

        public OrchardQueryContext(ContentTypeDefinition type) {
            _type = type;
        }

        public object Execute(Expression expression) {
            throw new NotImplementedException();
        }
    }
}