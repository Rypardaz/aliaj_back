using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.Presentation.Api.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
	private readonly ILogger<IndexModel> _logger = logger;

	public void OnGet()
	{

	}
}