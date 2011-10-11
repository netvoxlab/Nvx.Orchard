using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Nvx.Orchard.OData.Models;
using Orchard.ContentManagement;
using Orchard.Themes;

namespace Nvx.Orchard.OData.Controllers
{
	public class MainController : Controller
	{
		private readonly IContentManager _contentManager;

		public MainController(IContentManager contentManager) {
			_contentManager = contentManager;
		}

		[Themed]
		[HttpGet]
		public ActionResult Index(params string[] resource) 
		{
            //Here is code to process request:
            //var p = new ServiceProvider<DataSource>(new DataSource(_contentManager));
            //p.ProcessRequest();


			TestServiceModel model = new TestServiceModel();
			string path = Request.Url.PathAndQuery,
				appPath = Request.ApplicationPath;
			
		if(!String.IsNullOrEmpty(path) && !String.IsNullOrEmpty(appPath))
		{
			int start = appPath.Count(),
				count = path.Count() - appPath.Count();

			// формирование относительной ссылки
			string result = path.Substring(start, count);
			var u = new Uri(result, UriKind.Relative);
			// выбор параметров

		}

		resource = Request.Url.Segments;
			//model.XML = resource;

			return View("TestService");
		}

	}
}