using Microsoft.EntityFrameworkCore;

namespace ShopSphere.Web.ViewModels
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        //1,2,3,4,5,6
        //1=>no previous page ,has next page
        //2=>has previous page, has next page
        //6=>has previous page, no next page
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        //iqueryable<T> is used to allow for deferred execution and to work with Entity Framework queries.
        public static async Task<PaginatedList<T>> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();//tolistasync => async execution of query. async is non blocking thread 
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
