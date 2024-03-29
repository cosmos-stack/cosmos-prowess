﻿using Cosmos.Collections.Pagination;
using Cosmos.Collections.Pagination.Internals;

namespace Cosmos.Collections;

public static class Pages
{
    /// <summary>
    /// Queryable page from the given collection by page number and page size. <br />
    /// 按页码和页面大小从给定集合中查询的页面。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="queryable">data from database</param>
    /// <param name="pageNumber">page number</param>
    /// <param name="itemCountPerPage">page size</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QueryablePage<T> OfPage<T>(IQueryable<T> queryable, int pageNumber, int itemCountPerPage)
    {
        return queryable.GetPage(pageNumber, itemCountPerPage) as QueryablePage<T>;
    }

    /// <summary>
    /// Enumerable page from the given collection by page number and page size. <br />
    /// 按页码和页面大小从给定集合中可枚举的页面。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable">data in memory</param>
    /// <param name="pageNumber">page number</param>
    /// <param name="itemCountPerPage">page size</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EnumerablePage<T> OfPage<T>(IEnumerable<T> enumerable, int pageNumber, int itemCountPerPage)
    {
        return enumerable.GetPage(pageNumber, itemCountPerPage) as EnumerablePage<T>;
    }

    /// <summary>
    /// Create a page set from the given collection with page size and member count limit. <br />
    /// 从给定的集合中创建一个具有页面大小和成员数量限制的页面集。
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="pageSize"></param>
    /// <param name="limitedMemberCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PageableEnumerable<T> OfPageSet<T>(IEnumerable<T> enumerable, int? pageSize = null, int? limitedMemberCount = null)
    {
        return PageableCollectionFactory.CreatePageSet(enumerable, pageSize, limitedMemberCount);
    }

    /// <summary>
    /// Create a page set from the given collection with page size and member count limit. <br />
    /// 从给定的集合中创建一个具有页面大小和成员数量限制的页面集。
    /// </summary>
    /// <param name="queryable"></param>
    /// <param name="pageSize"></param>
    /// <param name="limitedMemberCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PageableQueryable<T> OfPageSet<T>(IQueryable<T> queryable, int? pageSize = null, int? limitedMemberCount = null)
    {
        return PageableCollectionFactory.CreatePageSet(queryable, pageSize, limitedMemberCount);
    }

    /// <summary>
    /// Create a new instance of <see cref="PageMember{T}"/> <br />
    /// 创建 <see cref="PageMember{T}"/> 的新实例
    /// </summary>
    /// <param name="memberValue"></param>
    /// <param name="offset"></param>
    /// <param name="startIndex"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PageMember<T> OfPageMember<T>(T memberValue, int offset, ref int startIndex)
    {
        return PageMemberFactory.Create(memberValue, offset, ref startIndex);
    }

    /// <summary>
    /// Create a new instance of <see cref="PageMember{T}"/> <br />
    /// 创建 <see cref="PageMember{T}"/> 的新实例
    /// </summary>
    /// <param name="memberColl"></param>
    /// <param name="index"></param>
    /// <param name="offset"></param>
    /// <param name="startIndex"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PageMember<T> OfPageMember<T>(IEnumerable<T> memberColl, int index, int offset, ref int startIndex)
    {
        return PageMemberFactory.Create(memberColl, index, offset, ref startIndex);
    }

    /// <summary>
    /// Create a new instance of <see cref="PageMember{T}"/> <br />
    /// 创建 <see cref="PageMember{T}"/> 的新实例
    /// </summary>
    /// <param name="state"></param>
    /// <param name="offset"></param>
    /// <param name="startIndex"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PageMember<T> OfPageMember<T>(IQueryEntryState<T> state, int offset, ref int startIndex)
    {
        return PageMemberFactory.Create(state, offset, ref startIndex);
    }
}