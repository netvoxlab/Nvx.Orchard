using System;
using System.Linq.Expressions;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Models;

namespace Nvx.Orchard.OData.Models.Visitors {
    public class RootVisitor : OrchardExpressionVisitor
    {
        private readonly ContentTypeDefinition _type;
        private readonly OrchardDataSource _dataSource;
        private readonly IContentQuery<ContentItem> _contentQuery;
        private readonly bool _isAtRoot;
        private bool hasResults;
        private object results;

        public RootVisitor(ContentTypeDefinition type, OrchardDataSource dataSource, IContentQuery<ContentItem> contentQuery, bool isAtRoot) {
            _type = type;
            _dataSource = dataSource;
            _contentQuery = contentQuery;
            _isAtRoot = isAtRoot;
        }

        public object Results
        {
            get
            {
                if (this.hasResults)
                {
                    return this.results;
                }
                return this._contentQuery;
            }
        }

        //private void HandleOrderByCall(MethodCallExpression call)
        //{
        //    Expression operand = ((UnaryExpression)call.Arguments[1]).Operand;
        //    string memberName = MemberNameVisitor.GetMemberName(metaType, operand);
        //    pagedFilter.SortBy = memberName;
        //    pagedFilter.Ascending = true;
        //}

        protected override Expression VisitMethodCall(MethodCallExpression expr)
        {
            this.Visit(expr.Arguments[0]);
            switch (expr.Method.Name) {
                case "Where":
                    this.HandleWhereCall(expr);
                    return expr;
                default:
                    throw new NotImplementedException("The method " + expr.Method.Name + " is not implemented.");
            }
        }

        private void HandleWhereCall(MethodCallExpression call)
        {
            WhereArgumentsVisitor.GetCriterion(_type, _contentQuery, call.Arguments[1]);
        }
    }
}