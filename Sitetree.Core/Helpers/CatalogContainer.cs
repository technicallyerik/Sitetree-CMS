using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace Sitetree.Core.Helpers
{
    public class CatalogContainer
    {
        private static CompositionContainer _singleton;

        public static CompositionContainer Current
        {
            get
            {
                if (_singleton == null)
                {
                    // An aggregate catalog that combines multiple catalogs
                    var catalog = new AggregateCatalog();

                    // Adds all the parts found in all assemblies in 
                    // the same directory as the executing program
                    catalog.Catalogs.Add(
                        new DirectoryCatalog(
                            Path.Combine(
                                AppDomain.CurrentDomain.BaseDirectory, "bin")));

                    //Create the CompositionContainer with the parts in the catalog
                    _singleton = new CompositionContainer(catalog);
                }

                return _singleton;
            }
        }
    }
}