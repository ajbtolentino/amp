namespace AMP.Infrastructure.Pagination;

public class PagedResult<T>
{
    public int PageNumber { get; set; }
    public int TotalRecords { get; set; }
    public IEnumerable<T> Result { get; set; }
}