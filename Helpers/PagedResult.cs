namespace Api.FCXLabs.AvaliacaoUsuario.Helpers
{
    public class PagedResult<T>
    {
        public List<T> Results { get; set; }
        public int Page { get; set; }

        public PagedResult(List<T> results, int page)
        {
            Results = results;
            Page = page;
        }
    }
}
