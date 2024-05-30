




namespace Repository_Hotel
{
	public static class SpecificationEvalutor<TEnity> where TEnity : BaseEntity
	{
		public static IQueryable<TEnity> GetQuery(IQueryable<TEnity> queryable, ISpecification<TEnity> specification)
		{
			var query = queryable;
			if (specification.Createria is not null)
				query = query.Where(specification.Createria);
			if (specification.OrderBy is not null)
				query = query.OrderBy(specification.OrderBy);
			if (specification.OrderByDesc is not null)
				query = query.OrderByDescending(specification.OrderByDesc);
			if (specification.IsPaginationEnable)
				query = query.Skip(specification.Skip).Take(specification.Take);

			query = specification.Includes.Aggregate(query, (current, includeexpprsion) => current.Include(includeexpprsion));
			return query;
		}
	}
}
