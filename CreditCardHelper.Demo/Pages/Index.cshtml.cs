using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreditCardHelper.Demo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Text { get; set; }
        public bool CreditCardFound { get; set; }
        public string MatchingText { get; set; }

        public IndexModel()
        {
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            CreditCardFound = Validator.TextContainsCreditCard(Text);
            if(CreditCardFound)
                MatchingText = Validator.GetCardNumberFromText(Text);
        }
    }
}