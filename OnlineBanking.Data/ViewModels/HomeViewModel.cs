using OnlineBanking.Data.Models.Api;
using System.Collections.Generic;

namespace OnlineBanking.Data.ViewModels
{
    public class HomeViewModel
    {
        public bool IsNewsDisplayed { get; set; }
        public IEnumerable<NewsResult> NewsResults { get; set; }
    }
}
