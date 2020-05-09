namespace CRM.API.Helpers
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; } 

        public PaginationHeader(int currentpage, int itemsperpage, int totalItems, int totalPages)
        {
            this.CurrentPage = currentpage;
            this.ItemsPerPage = itemsperpage;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
        }
    }
}