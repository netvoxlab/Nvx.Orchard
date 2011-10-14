using System;
using System.Collections.Generic;
using System.Data.Services.Providers;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Models;

namespace Nvx.Orchard.OData.Models {
    public class  OrchardDataServiceMetadataProvider: IDataServiceMetadataProvider {
        public OrchardDataSource OrchardDataSource { get; set; }
        private Dictionary<string, ResourceType> resourceTypes = new Dictionary<string, ResourceType>();
        private Dictionary<string, ResourceSet> resourceSets = new Dictionary<string, ResourceSet>();
        public OrchardDataServiceMetadataProvider(OrchardDataSource source)
        {
            OrchardDataSource = source;

            foreach (var definition in OrchardDataSource.ContentManager.GetContentTypeDefinitions())
            {
                var name = definition.Name;
                var r = new ResourceType(typeof(ContentItem), ResourceTypeKind.EntityType, null, null, name, false);

                r.AddProperty(new ResourceProperty("Id", ResourcePropertyKind.Primitive|ResourcePropertyKind.Key, ResourceType.GetPrimitiveResourceType(typeof(int))));
                r.AddProperty(new ResourceProperty("Version", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(int))));

                foreach (var part in definition.Parts) {
                    var propertyResourceType = GetComplexResourceType(part);
                    var resourceProperty = new ResourceProperty(part.PartDefinition.Name, ResourcePropertyKind.ComplexType, propertyResourceType);
                    resourceProperty.CanReflectOnInstanceTypeProperty = false;
                    r.AddProperty(resourceProperty);
                }

                r.SetReadOnly();
                resourceTypes.Add(name, r);
                var s = new ResourceSet(name, r);
                s.CustomState = definition;
                s.SetReadOnly();
                resourceSets.Add(name, s);
            }
        }

        private ResourceType GetComplexResourceType(ContentTypePartDefinition part) {
            ResourceType t;
            var name = part.PartDefinition.Name;
            if (resourceTypes.TryGetValue(name, out t))
                return t;
            t = new ResourceType(typeof(ContentPart), ResourceTypeKind.ComplexType, null, null, name, false);
            t.CanReflectOnInstanceType = false;
            t.AddProperty(new ResourceProperty("Id", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(int))));
            foreach (var field in part.PartDefinition.Fields)
            {
            }
            t.SetReadOnly();
            resourceTypes.Add(name, t);

            return t;
        }

        #region Implementation of IDataServiceMetadataProvider

        /// <summary>
        /// Tries to get a resource set based on the specified name.
        /// </summary>
        /// <returns>
        /// true when resource set with the given <paramref name="name"/> is found; otherwise false.
        /// </returns>
        /// <param name="name">Name of the <see cref="T:System.Data.Services.Providers.ResourceSet"/> to resolve.</param><param name="resourceSet">Returns the resource set or a null value if a resource set with the given <paramref name="name"/> is not found.</param>
        public bool TryResolveResourceSet(string name, out ResourceSet resourceSet) {
            return resourceSets.TryGetValue(name, out resourceSet); 
        }

        /// <summary>
        /// Gets the <see cref="T:System.Data.Services.Providers.ResourceAssociationSet"/> instance when given the source association end.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Data.Services.Providers.ResourceAssociationSet"/> instance.
        /// </returns>
        /// <param name="resourceSet">Resource set of the source association end.</param><param name="resourceType">Resource type of the source association end.</param><param name="resourceProperty">Resource property of the source association end.</param>
        public ResourceAssociationSet GetResourceAssociationSet(ResourceSet resourceSet, ResourceType resourceType, ResourceProperty resourceProperty) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tries to get a resource type based on the specified name.
        /// </summary>
        /// <returns>
        /// true when resource type with the given <paramref name="name"/> is found; otherwise false.
        /// </returns>
        /// <param name="name">Name of the type to resolve.</param><param name="resourceType">Returns the resource type or a null value if a resource type with the given <paramref name="name"/> is not found.</param>
        public bool TryResolveResourceType(string name, out ResourceType resourceType) {
            return resourceTypes.TryGetValue(name, out resourceType); 
        }

        /// <summary>
        /// Attempts to return all types that derive from the specified resource type.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> collection of derived <see cref="T:System.Data.Services.Providers.ResourceType"/> objects.
        /// </returns>
        /// <param name="resourceType">The base <see cref="T:System.Data.Services.Providers.ResourceType"/>.</param>
        public IEnumerable<ResourceType> GetDerivedTypes(ResourceType resourceType) {
            yield break;
        }

        /// <summary>
        /// Determines whether a resource type has derived types.
        /// </summary>
        /// <returns>
        /// true when <paramref name="resourceType"/> represents an entity that has derived types; otherwise false.
        /// </returns>
        /// <param name="resourceType">A <see cref="T:System.Data.Services.Providers.ResourceType"/> object to evaluate.</param>
        public bool HasDerivedTypes(ResourceType resourceType) {
            return false;
        }

        /// <summary>
        /// Tries to get a service operation based on the specified name.
        /// </summary>
        /// <returns>
        /// true when service operation with the given <paramref name="name"/> is found; otherwise false.
        /// </returns>
        /// <param name="name">Name of the service operation to resolve.</param><param name="serviceOperation">Returns the service operation or a null value if a service operation with the given <paramref name="name"/> is not found.</param>
        public bool TryResolveServiceOperation(string name, out ServiceOperation serviceOperation) {
            serviceOperation = null;
            return false;
        }

        /// <summary>
        /// Namespace name for the data source.
        /// </summary>
        /// <returns>
        /// String that contains the namespace name.
        /// </returns>
        public string ContainerNamespace {
            get { return "Orchard"; }
        }

        /// <summary>
        /// Container name for the data source.
        /// </summary>
        /// <returns>
        /// String that contains the name of the container.
        /// </returns>
        public string ContainerName {
            get { return "ContentTypes"; }
        }

        /// <summary>
        /// Gets all available containers.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> collection of <see cref="T:System.Data.Services.Providers.ResourceSet"/> objects.
        /// </returns>
        public IEnumerable<ResourceSet> ResourceSets {
            get { return this.resourceSets.Values; }
        }

        /// <summary>
        /// Returns all the types in this data source.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> collection of <see cref="T:System.Data.Services.Providers.ResourceType"/> objects.
        /// </returns>
        public IEnumerable<ResourceType> Types {
            get { return this.resourceTypes.Values; }
        }

        /// <summary>
        /// Returns all the service operations in this data source.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> collection of <see cref="T:System.Data.Services.Providers.ServiceOperation"/> objects.
        /// </returns>
        public IEnumerable<ServiceOperation> ServiceOperations {
            get { yield break; }
        }

        #endregion
    }
}