// As introduced earlier in the design section, the Specification pattern(its full name would be Query-specification pattern)
// is a Domain-Driven Design pattern designed as the place where you can put the definition of a query with optional sorting
// and paging logic.The Specification pattern defines a query in an object. For example, in order to encapsulate a paged query
// that searches for some products you can create a PagedProduct specification that takes the necessary input parameters(pageNumber, pageSize, filter, etc.).
// Then, any Repository’s method(usually a List() overload) would accept an ISpecification and run the expected query based on
// that specification.
namespace mrs.ApplicationCore.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Interface for implementing Query-Specification pattern.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the criteria.
        /// </summary>
        /// <value>
        /// The criteria.
        /// </value>
        Expression<Func<T, bool>> Criteria { get; }
        /// <summary>
        /// Gets the includes.
        /// </summary>
        /// <value>
        /// The includes.
        /// </value>
        List<Expression<Func<T, object>>> Includes { get; }
        /// <summary>
        /// Gets the include strings.
        /// </summary>
        /// <value>
        /// The include strings.
        /// </value>
        List<string> IncludeStrings { get; }
    }
}
