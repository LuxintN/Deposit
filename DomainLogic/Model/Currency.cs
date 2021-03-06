using System.ComponentModel.DataAnnotations;

namespace DomainLogic.Model
{
    public class Currency
    {
        public int Id { get; set; }
        
        [Display(Name = "Currency")]
        public string Name { get; set; }

        [Display(Name = "Currency")]
        public string Abbreviation { get; set; }
    }
}
