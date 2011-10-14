using System;
using System.Linq.Expressions;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Models;

namespace Nvx.Orchard.OData.Models.Visitors {
    public class WhereArgumentsVisitor : OrchardExpressionVisitor
    {
        private readonly ContentTypeDefinition _type;
        private readonly IContentQuery<ContentItem> _contentQuery;

        private WhereArgumentsVisitor(ContentTypeDefinition type, IContentQuery<ContentItem> contentQuery) {
            _type = type;
            _contentQuery = contentQuery;
        }

        protected override Expression VisitBinary(BinaryExpression expr) {
            ExpressionType nodeType = expr.NodeType;
            if (nodeType != ExpressionType.AndAlso)
            {
                if (nodeType == ExpressionType.OrElse)
                {
                    throw new NotImplementedException();
                }
                VisitBinaryCriterionExpression(expr);
                return expr;
            }
            this.VisitAndAlsoExpression(expr);
            return expr;
        }

        private void VisitAndAlsoExpression(BinaryExpression expr) {
            this.Visit(expr.Left);
            this.Visit(expr.Right);
        }

        private void VisitBinaryCriterionExpression(BinaryExpression expr) {
            throw new NotImplementedException();
            //_contentQuery.Where();
            //.SearchCriterias.Add(BinaryCriterionVisitor.GetBinaryCriteria(metaType, pagedFilter, expr)));
        }

        protected override Expression VisitConstant(ConstantExpression expr)
        {
            throw new NotImplementedException();
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            return base.VisitUnary(u);
        }

        public static void GetCriterion(ContentTypeDefinition type, IContentQuery<ContentItem> contentQuery, Expression expression) {
            WhereArgumentsVisitor visitor = new WhereArgumentsVisitor(type, contentQuery);
            visitor.Visit(expression);
            
        }
    }
}