using System;
using System.Linq;
using System.Linq.Expressions;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Models;

namespace Nvx.Orchard.OData.Models {
    public class OrchardQueryProvider : IQueryProvider {
        private readonly ContentTypeDefinition _type;
        private readonly OrchardDataSource _dataSource;

        public OrchardQueryProvider(ContentTypeDefinition type, OrchardDataSource dataSource) {
            _type = type;
            _dataSource = dataSource;
        }

        #region Implementation of IQueryProvider

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            Type elementType = typeof(TElement);
            return new OrchardQueryable<TElement>(_type, this, expression);
        }

        public IQueryable CreateQuery(Expression expression) {
            return new OrchardQueryable<ContentItem>(_type, this, expression);
        }


        public object Execute(Expression expression) {
            return (new OrchardQueryContext(_type, _dataSource)).Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression) {
            return (TResult)(new OrchardQueryContext(_type,_dataSource)).Execute(expression);
        }

        #endregion
    }
}