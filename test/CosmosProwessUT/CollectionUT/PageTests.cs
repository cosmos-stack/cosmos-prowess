using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;

namespace CosmosProwessUT.CollectionUT;

[Trait("PageUT", "PageUT.Of")]
public class PageTests
{
  [Fact(DisplayName = "Use Pages.OfPage and returns a list with page information test")]
    public void CollOfPageAndReturnsListWithinPageTest()
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
        var page = Pages.OfPage(list, 2, 3);

        page.PageSize.ShouldBe(3);
        page.CurrentPageNumber.ShouldBe(2);
        page.CurrentPageSize.ShouldBe(3);
        page.HasNext.ShouldBeTrue();
        page.HasPrevious.ShouldBeTrue();
        page.TotalMemberCount.ShouldBe(9);

        page[0].Value.ShouldBe(4);
        page[1].Value.ShouldBe(5);
        page[2].Value.ShouldBe(6);

        var list1 = page.ToOriginalItems().ToList();
        var list2 = page.ToList();

        list1.Count.ShouldBe(3);
        list1[0].ShouldBe(4);
        list1[1].ShouldBe(5);
        list1[2].ShouldBe(6);

        list2.Count.ShouldBe(3);
        list2[0].Value.ShouldBe(4);
        list2[1].Value.ShouldBe(5);
        list2[2].Value.ShouldBe(6);
    }

    [Fact(DisplayName = "Use Pages.OfPage for query and returns a list with page information test")]
    public void CollOfPageForQueryAndReturnsListWithinPageTest()
    {
        var query = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9}.AsQueryable();
        var page = Pages.OfPage(query, 2, 3);

        page.PageSize.ShouldBe(3);
        page.CurrentPageNumber.ShouldBe(2);
        page.CurrentPageSize.ShouldBe(3);
        page.HasNext.ShouldBeTrue();
        page.HasPrevious.ShouldBeTrue();
        page.TotalMemberCount.ShouldBe(9);

        page[0].Value.ShouldBe(4);
        page[1].Value.ShouldBe(5);
        page[2].Value.ShouldBe(6);

        var list1 = page.ToOriginalItems().ToList();
        var list2 = page.ToList();

        list1.Count.ShouldBe(3);
        list1[0].ShouldBe(4);
        list1[1].ShouldBe(5);
        list1[2].ShouldBe(6);

        list2.Count.ShouldBe(3);
        list2[0].Value.ShouldBe(4);
        list2[1].Value.ShouldBe(5);
        list2[2].Value.ShouldBe(6);
    }

}