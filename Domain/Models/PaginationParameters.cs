namespace Domain.Models
{
    public abstract class PaginationParameters
    {
        const int MAXPAGESIZE = 50;
        private int DefaultPageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return DefaultPageSize;
            }
            set
            {
                DefaultPageSize = (value > MAXPAGESIZE) ? MAXPAGESIZE : value;
            }
        }
    }
}