using System;
using System.Linq.Expressions;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement;

namespace Nvx.Orchard.OData.Models {
    public class OrchardQueryContext
    {
        private readonly ContentTypeDefinition _type;
        private readonly OrchardDataSource _dataSource;

        public OrchardQueryContext(ContentTypeDefinition type, OrchardDataSource dataSource) {
            _type = type;
            _dataSource = dataSource;
        }

        public object Execute(Expression expression) {

            var q = _dataSource.ContentManager.Query(_type.Name);
            TranslateExpression(q, expression);
            return q.List();
        }

        private void TranslateExpression(IContentQuery<ContentItem> contentQuery, Expression expression) {
            
        }
    }
}