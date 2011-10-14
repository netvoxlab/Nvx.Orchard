using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Models;

namespace Nvx.Orchard.OData.Models.Visitors
{
    class OrchardQueryTranslator : OrchardExpressionVisitor
    {
        private readonly ContentTypeDefinition _type;
        private readonly OrchardDataSource _dataSource;

        public OrchardQueryTranslator(ContentTypeDefinition type, OrchardDataSource dataSource) {
            _type = type;
            _dataSource = dataSource;
        }

        public object Translate(IContentQuery<ContentItem> contentQuery, Expression expression)
        {
            this.Visit(expression);
            RootVisitor visitor = new RootVisitor(_type, _dataSource, contentQuery, true);
            visitor.Visit(expression);
            return visitor.Results;
        }
    }
}
