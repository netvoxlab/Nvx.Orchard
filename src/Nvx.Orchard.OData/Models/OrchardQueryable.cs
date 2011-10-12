using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Models;

namespace Nvx.Orchard.OData.Models {
    public class OrchardQueryable<T> : IOrderedQueryable<T>
    {
        private readonly ContentTypeDefinition _type;
        private readonly OrchardDataSource _dataSource;

        public OrchardQueryable(ContentTypeDefinition type, OrchardDataSource dataSource) {
            _type = type;
            _dataSource = dataSource;

            Provider = new OrchardQueryProvider(type, _dataSource);
            Expression = Expression.Constant(this);
            ElementType = typeof (ContentItem);
        }

        public OrchardQueryable(ContentTypeDefinition type, OrchardQueryProvider orchardQueryProvider, Expression expression) {
            _type = type;

            Provider = orchardQueryProvider;
            Expression = expression;
            ElementType = typeof(ContentItem);
        }

        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return (Provider.Execute<IEnumerable<T>>(Expression)).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public IEnumerator GetEnumerator() {
            return Provider.Execute<IEnumerable>(Expression).GetEnumerator();
        }

        #endregion

        #region Implementation of IQueryable

        public Expression Expression { get; set; }

        public Type ElementType { get; set; }

        public IQueryProvider Provider { get; set; }

        #endregion
    }
}