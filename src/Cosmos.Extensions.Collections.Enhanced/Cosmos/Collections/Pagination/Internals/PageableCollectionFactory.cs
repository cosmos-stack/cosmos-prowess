﻿// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable RedundantCast

namespace Cosmos.Collections.Pagination.Internals;

internal static class PageableCollectionFactory
{
    /// <summary>
    /// Get real member count<br />.
    /// first parameter(l) means limitedMemberCount<br />,
    /// second parameter(c) means count.
    /// </summary>
    /// <returns></returns>
    private static Func<int?, Func<int, int>> GetRealMemberCountFunc()
        => l => c => l.IsValid() && l.HasValue ? l.Value > c ? c : l.Value : c;

    /// <summary>
    /// Get real page count<br />.
    /// first parameter(m) means real member count, which has been gotten from <see cref="GetRealMemberCountFunc"/><br />,
    /// second parameter(s) means page size.
    /// </summary>
    /// <returns></returns>
    private static Func<int, Func<int, int>> GetRealPageCountFunc()
        => m => s => (int) Math.Ceiling((double) m / (double) s);

    /// <summary>
    /// Make enumerable result to EnumerablePage collection
    /// </summary>
    /// <typeparam name="T">element type of your enumerable result</typeparam>
    /// <param name="enumerable">original enumerable result</param>
    /// <param name="pageSize">page size</param>
    /// <param name="limitedMemberCount">limited member count</param>
    /// <returns></returns>
    public static PageableEnumerable<T> CreatePageSet<T>(IEnumerable<T> enumerable, int? pageSize = null, int? limitedMemberCount = null)
    {
        ArgumentNullException.ThrowIfNull(enumerable);

        pageSize ??= PageableSettingsManager.Settings.DefaultPageSize;

        var size = pageSize.Value;
        var realMemberCount = GetRealMemberCountFunc()(limitedMemberCount)(enumerable.Count());
        var realPageCount = GetRealPageCountFunc()(realMemberCount)(size);

        return limitedMemberCount.IsValid() && limitedMemberCount.HasValue
            ? new PageableEnumerable<T>(enumerable, size, realPageCount, realMemberCount, limitedMemberCount.Value)
            : new PageableEnumerable<T>(enumerable, size, realPageCount, realMemberCount);
    }

    /// <summary>
    /// Make queryable source to QueryablePage collection
    /// </summary>
    /// <typeparam name="T">element type of your queryable source</typeparam>
    /// <param name="queryable">original queryable result</param>
    /// <param name="pageSize">page size</param>
    /// <param name="limitedMemberCount">limited member count</param>
    /// <returns></returns>
    public static PageableQueryable<T> CreatePageSet<T>(IQueryable<T> queryable, int? pageSize = null, int? limitedMemberCount = null)
    {
        ArgumentNullException.ThrowIfNull(queryable);

        pageSize ??= PageableSettingsManager.Settings.DefaultPageSize;

        var size = pageSize.Value;
        var realMemberCount = GetRealMemberCountFunc()(limitedMemberCount)(queryable.Count());
        var realPageCount = GetRealPageCountFunc()(realMemberCount)(size);

        return limitedMemberCount.IsValid() && limitedMemberCount.HasValue
            ? new PageableQueryable<T>(queryable, size, realPageCount, realMemberCount, limitedMemberCount.Value)
            : new PageableQueryable<T>(queryable, size, realPageCount, realMemberCount);
    }
}