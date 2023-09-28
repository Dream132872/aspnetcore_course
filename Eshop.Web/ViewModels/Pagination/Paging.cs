namespace Eshop.Web.ViewModels.Pagination
{
    public class BasePaging
    {
        public BasePaging()
        {
            Page = 1;
            Take = 10;
            HowManyPagesShowAfterBefore = 5;
        }

        public int AllEntitiesCount { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Page { get; set; }
        public int PagesCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int HowManyPagesShowAfterBefore { get; set; }

        public bool HasNextPage => Page < PagesCount;
        public bool HasPreviousPage => Page > 1;
        public int NextPage => Page + 1;
        public int PreviousPage => Page - 1;

        public BasePaging GetCurrentPaging()
        {
            return this;
        }
    }


    public class Paging<T> : BasePaging
    {
        public List<T> Entities { get; set; } = new List<T>();

        public void SetPaging(IQueryable<T> query)
        {
            if (Page <= 0) Page = 1;
            if (Take < 1) Take = 1;
            if (HowManyPagesShowAfterBefore < 1) HowManyPagesShowAfterBefore = 1;
            AllEntitiesCount = query.Count();
            PagesCount = (int)Math.Ceiling(AllEntitiesCount / (double)Take);
            if (Page > PagesCount) Page = PagesCount;
            Skip = (Page - 1) * Take;
            StartPage = Page - HowManyPagesShowAfterBefore > 0 ? Page - HowManyPagesShowAfterBefore : 1;
            EndPage = Page + HowManyPagesShowAfterBefore > PagesCount ? PagesCount : Page + HowManyPagesShowAfterBefore;
            Entities = query.Skip(Skip).Take(Take).ToList();
        }
    }
}