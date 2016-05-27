using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Autofac.Integration.Mvc;
using MefContrib.Containers;
using MefContrib.Integration.Autofac;

namespace Sitetree.Core.Helpers
{
    /// <summary>
    ///     Injects Autofac libraries into Managed Extensibility Framework
    /// </summary>
    public class CatalogContainer
    {
        internal static CompositionContainer Singleton;

        /// <summary>
        ///     Retrieves the singleton current composition container
        /// </summary>
        public static CompositionContainer Current
        {
            get
            {
                if (Singleton == null)
                {
                    // An aggregate catalog that combines multiple catalogs
                    var catalog = new AggregateCatalog();

                    // Adds all the parts found in all assemblies in 
                    // the same directory as the executing program
                    catalog.Catalogs.Add(
                        new DirectoryCatalog(
                            Path.Combine(
                                AppDomain.CurrentDomain.BaseDirectory, "bin")));

                    // Inject Autofac libraries into catalog container
                    var adapter = new AutofacContainerAdapter(AutofacDependencyResolver.Current.ApplicationContainer);
                    var provider = new ContainerExportProvider(adapter);

                    //Create the CompositionContainer with the parts in the catalog
                    Singleton = new CompositionContainer(catalog, provider);
                }

                return Singleton;
            }
        }
    }
}