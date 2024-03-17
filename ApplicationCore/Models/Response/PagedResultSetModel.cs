namespace ApplicationCore.Models.Response;

public class PagedResultSetModel<T> where T: class
{
    
    public int PageNumber { get; }
    
    public int TotalRecords { get; }
    
    public int PageSize { get; }
    
    public int TotalPages { get; }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;
    
    public IEnumerable<T> PagedData { get; set; }

    public PagedResultSetModel(int pageNumber, int totalRecords, int pageSize, IEnumerable<T> pagedData)
    {
        PageNumber = pageNumber;
        TotalRecords = totalRecords;
        PageSize = pageSize;
        TotalPages = (int) Math.Ceiling(TotalRecords / (double)PageSize);
        PagedData = pagedData;
    }
}