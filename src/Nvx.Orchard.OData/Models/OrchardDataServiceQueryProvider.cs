using System;
using System.Collections.Generic;
using System.Data.Services.Providers;
using System.Linq;

namespace Nvx.Orchard.OData.Models {
    public class OrchardDataServiceQueryProvider<T>:IDataServiceQueryProvider where T : OrchardDataSource {
        private OrchardDataSource _dataSource;
        private readonly ServiceProvider<T> _serviceProvider;

        public OrchardDataServiceQueryProvider(OrchardDataSource dataSource, ServiceProvider<T> serviceProvider)
        {
            _dataSource = dataSource;
            _serviceProvider = serviceProvider;
        }

        #region Implementation of IDataServiceQueryProvider

        /// <summary>
        /// Gets the <see cref="T:System.Linq.IQueryable`1"/> that represents the container. 
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable`1"/> that represents the resource set, or a null value if there is no resource set for the specified <paramref name="resourceSet"/>.
        /// </returns>
        /// <param name="resourceSet">The resource set.</param>
        public IQueryable GetQueryRootForResourceSet(ResourceSet resourceSet) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the resource type for the instance that is specified by the parameter.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Data.Services.Providers.ResourceType"/> of the supplied object. 
        /// </returns>
        /// <param name="target">Instance to extract a resource type from.</param>
        public ResourceType GetResourceType(object target) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value of the open property.
        /// </summary>
        /// <returns>
        /// Value for the property.
        /// </returns>
        /// <param name="target">Instance of the type that declares the open property.</param><param name="resourceProperty">Value for the open property.</param>
        public object GetPropertyValue(object target, ResourceProperty resourceProperty) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value of the open property.
        /// </summary>
        /// <returns>
        /// The value of the open property.
        /// </returns>
        /// <param name="target">Instance of the type that declares the open property.</param><param name="propertyName">Name of the open property.</param>
        public object GetOpenPropertyValue(object target, string propertyName) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the name and values of all the properties that are defined in the given instance of an open type.
        /// </summary>
        /// <returns>
        /// A collection of name and values of all the open properties.
        /// </returns>
        /// <param name="target">Instance of the type that declares the open property.</param>
        public IEnumerable<KeyValuePair<string, object>> GetOpenPropertyValues(object target) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invokes the given service operation and returns the results.
        /// </summary>
        /// <returns>
        /// The result of the service operation, or a null value for a service operation that returns void.
        /// </returns>
        /// <param name="serviceOperation">Service operation to invoke.</param><param name="parameters">Values of parameters to pass to the service operation.</param>
        public object InvokeServiceOperation(ServiceOperation serviceOperation, object[] parameters) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The data source object from which data is provided.
        /// </summary>
        /// <returns>
        /// The data source.
        /// </returns>
        public object CurrentDataSource {
            get { return _dataSource; }
            set { _dataSource = (OrchardDataSource)value; }
        }

        /// <summary>
        /// Gets a value that indicates whether null propagation is required in expression trees.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Boolean"/> value that indicates whether null propagation is required.
        /// </returns>
        public bool IsNullPropagationRequired {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}