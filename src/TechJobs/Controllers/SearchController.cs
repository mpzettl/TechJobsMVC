using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
	public class SearchController : Controller
	{

		public IActionResult Index()
		{
			ViewBag.columns = ListController.columnChoices; 
			ViewBag.title = "Search";
			return View();
		}

		// TODO #1 - Create a Results action method to process 
		// search request and display results

		[HttpGet]
		[Route("/Search/Results")]
		public IActionResult Results(string searchType, string searchTerm)
		{
			
			if (searchType.Equals("all") || (searchTerm.Equals("")))
				{
					ViewBag.jobs = JobData.FindByValue(searchTerm);
				}

			else
				{
					ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
				
				}

			ViewBag.columns = ListController.columnChoices;
			ViewBag.title = "Search";
			return View("Index", ViewBag.jobs);
		}
	}
	
}
		

	

