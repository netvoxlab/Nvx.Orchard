using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;

namespace Nvx.Orchard.OData.Models {
    public class OrchardServiceProvider<T> : DataService<T>, IServiceProvider where T : OrchardDataSource
    {
        private readonly OrchardDataSource _orchardDataSource;
        OrchardDataServiceMetadataProvider _orchardDataServiceMetadataProvider;
        private OrchardDataServiceQueryProvider<T> _query;

        public OrchardServiceProvider(OrchardDataSource orchardDataSource) {
            _orchardDataSource = orchardDataSource;
            _orchardDataServiceMetadataProvider = new OrchardDataServiceMetadataProvider(orchardDataSource);
            
        }

        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config) {
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            //// Grant only the rights needed to support the client application.
            //config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead
            //     | EntitySetRights.WriteMerge
            //     | EntitySetRights.WriteReplace);
            //config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead
            //    | EntitySetRights.AllWrite);
            //config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead);
        }

        #region Implementation of IServiceProvider

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <returns>
        /// A service object of type <paramref name="serviceType"/>.-or- null if there is no service object of type <paramref name="serviceType"/>.
        /// </returns>
        /// <param name="serviceType">An object that specifies the type of service object to get. </param><filterpriority>2</filterpriority>
        public object GetService(Type serviceType) {
            if (serviceType == typeof(IDataServiceMetadataProvider))
            {
                return _orchardDataServiceMetadataProvider;
            }
            if (serviceType == typeof(IDataServicePagingProvider))
            {
                return new OrchardDataServicePagingProvider();
            }
            if (serviceType == typeof(IDataServiceQueryProvider))
            {
                if (_query == null)
                    _query = new OrchardDataServiceQueryProvider<T>(_orchardDataSource, this);
                return _query;
            }
            //if (serviceType == typeof(IDataServiceStreamProvider))
            //{
            //    return new MetaFormsDataServiceStreamProvider();
            //}
            //if (serviceType == typeof(IDataServiceUpdateProvider))
            //{
            //    return new MetaFormsDataServiceUpdateProvider(DataSource);
            //}
            return null;
        }

        #endregion
    }
}