namespace mrs.ApplicationCore.Specification
{
    using mrs.ApplicationCore.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.ISpecification{T}" />
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSpecification{T}"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public BaseSpecification(Expression<Func<T,bool>> criteria)
        {
            Criteria = criteria;
        }
        /// <summary>
        /// Gets the criteria.
        /// </summary>
        /// <value>
        /// The criteria.
        /// </value>
        public Expression<Func<T, bool>> Criteria { get; }
        /// <summary>
        /// Gets the includes.
        /// </summary>
        /// <value>
        /// The includes.
        /// </value>
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        /// <summary>
        /// Gets the include strings.
        /// </summary>
        /// <value>
        /// The include strings.
        /// </value>
        public List<string> IncludeStrings { get; } = new List<string>();
        /// <summary>
        /// Adds the include.
        /// </summary>
        /// <param name="includeExpression">The include expression.</param>
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        /// <summary>
        /// Adds the include.
        /// </summary>
        /// <param name="includeString">The include string.</param>
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}
