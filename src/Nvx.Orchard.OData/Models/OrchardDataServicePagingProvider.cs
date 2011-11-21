using System.Data.Services.Providers;
using System.Linq;

namespace Nvx.Orchard.OData.Models {
    public class OrchardDataServicePagingProvider : IDataServicePagingProvider
    {
        object[] continuationToken;

        #region IDataServicePagingProvider Members

        public object[] GetContinuationToken(System.Collections.IEnumerator enumerator)
        {
            return continuationToken;
        }

        /// <summary>
        /// Получает токен следующей страницы из параметра запроса $skiptoken в универсальном коде ресурса запроса.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="resourceType"></param>
        /// <param name="continuationToken"></param>
        public void SetContinuationToken(IQueryable query, ResourceType resourceType, object[] continuationToken)
        {
            this.continuationToken = continuationToken;
        }

        #endregion
    }
}