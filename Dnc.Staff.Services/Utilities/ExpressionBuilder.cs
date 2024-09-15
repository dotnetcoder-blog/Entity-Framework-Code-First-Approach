using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services.Utilities
{
    public static class ExpressionBuilder
    {
        public static Expression<Func<TItem, object>>[] BuildExpressions<TItem>(string[] properties)
        {
            var expressions = new List<Expression<Func<TItem, object>>>();

            foreach (var property in properties)
            {
                var parameter = Expression.Parameter(typeof(TItem), "item");

                var member = Expression.PropertyOrField(parameter, property);

                var lambda = Expression.Lambda<Func<TItem, object>>(member, parameter);

                expressions.Add(lambda);
            }

            return [.. expressions];
        }
    }
}
