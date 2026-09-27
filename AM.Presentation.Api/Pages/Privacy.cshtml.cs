using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.Presentation.Api.Pages;

public class PrivacyModel(ILogger<PrivacyModel> logger) : PageModel
{
	private readonly ILogger<PrivacyModel> _logger = logger;

	public void OnGet()
	{
	}
}