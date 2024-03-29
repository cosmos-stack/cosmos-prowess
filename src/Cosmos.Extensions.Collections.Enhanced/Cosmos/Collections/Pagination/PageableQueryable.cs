﻿namespace Cosmos.Collections.Pagination;

/// <summary>
/// QueryablePage collection <br />
/// 可查询分页集合
/// </summary>
/// <typeparam name="T"></typeparam>
public class PageableQueryable<T> : PageableSetBase<T>
{
    private readonly IQueryable<T> _queryable;

    // ReSharper disable once UnusedMember.Local
    private PageableQueryable() { }

    internal PageableQueryable(IQueryable<T> queryable, int pageSize, int realPageCount, int realMemberCount)
        : base(pageSize, realPageCount, realMemberCount)
    {
        _queryable = queryable;
    }

    internal PageableQueryable(IQueryable<T> queryable, int pageSize, int realPageCount, int realMemberCount, int limitedMembersCount)
        : base(pageSize, realPageCount, realMemberCount, limitedMembersCount)
    {
        _queryable = queryable;
    }

    /// <summary>
    /// Get special page <br />
    /// 获得指定页
    /// </summary>
    /// <param name="currentPageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="realMemberCount"></param>
    /// <returns></returns>
    protected override Lazy<IPage<T>> GetSpecifiedPage(int currentPageNumber, int pageSize, int realMemberCount)
    {
        return new(() => new EnumerablePage<T>(_queryable, currentPageNumber, pageSize, realMemberCount));
    }
}