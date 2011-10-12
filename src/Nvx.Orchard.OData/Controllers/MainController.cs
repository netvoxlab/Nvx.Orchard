using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Text;
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
            var p = new ServiceProvider<OrchardDataSource>(new OrchardDataSource(_contentManager));
		    var host = new OrchardDataServiceHost(Request);
		    p.AttachHost(host);
            p.ProcessRequest();

		    return new FileContentResult(host.Content, host.ResponseContentType);
		}

	}
}