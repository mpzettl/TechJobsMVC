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
		
		internal IActionResult Results(JobData FindAll)
		{
			ViewBag.columns = ListController.columnChoices;
			ViewBag.title = "Search";

			foreach (var searchType in ViewBag.columns)
			{
				foreach (var searchTerm in searchType)
				if ((searchType.Equals("all")) || (searchTerm.Equals("")))
				{
					ViewBag.columns = JobData.FindByValue(searchTerm);
				}
				else
				{
					ViewBag.columns = JobData.FindByColumnAndValue(searchType, searchTerm);
				}
			}
			return View();
		}
	}
	
}
		

	

