using System.Collections.Generic;
using System.Web.Mvc;
using Orchard.Mvc.Routes;
using System.Web.Routing;

namespace Nvx.Orchard.OData
{
	public class Routes : IRouteProvider
	{
		public void GetRoutes(ICollection<RouteDescriptor> routes)
		{
			foreach (var routeDescriptor in GetRoutes())
				routes.Add(routeDescriptor);
		}

		public IEnumerable<RouteDescriptor> GetRoutes()
		{
			return new RouteDescriptor[] {
        		new RouteDescriptor {
        			Priority = 5,
        			Route = new Route(
        				"OData/{res1}/{res2}/{res3}/{res4}/{res5}/{res6}/{res7}/{res8}/{res9}/{res10}",
        				new RouteValueDictionary {
        					{"area", "Nvx.Orchard.OData"},
        					{"controller", "Main"},
        					{"action", "Index"},
							
							{"res1", UrlParameter.Optional},
							{"res2", UrlParameter.Optional},
							{"res3", UrlParameter.Optional},
							{"res4", UrlParameter.Optional},
							{"res5", UrlParameter.Optional},
							{"res6", UrlParameter.Optional},
							{"res7", UrlParameter.Optional},
							{"res8", UrlParameter.Optional},
							{"res9", UrlParameter.Optional},
							{"res10", UrlParameter.Optional}
        				},
        				new RouteValueDictionary(),
        				new RouteValueDictionary {
        					{"area", "Nvx.Orchard.OData"}
        				},
        				new MvcRouteHandler())
        		}
        	};
		}
	}
}