using System.ComponentModel.DataAnnotations;

namespace MainstreamDOCSdotweb.Pages.Docs
{
    public class Properties
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string? Document { get; set; }
        
    }
}
