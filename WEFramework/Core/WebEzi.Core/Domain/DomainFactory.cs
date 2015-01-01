using System;
using System.Collections.Generic;
using System.Reflection;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base;
using WebEzi.Core.Domain.Base.Application;
using WebEzi.Core.Domain.Base.Model;
using WebEzi.Core.Domain.Base.ModelFactory;
using WebEzi.Core.Domain.Base.Repository;
using WebEzi.Core.Domain.Base.Service;
using WebEzi.Core.Exception.Domain;

namespace WebEzi.Core.Domain
{
    /// <summary>
    /// Generate the kind of the domain factory
    /// </summary>
    public class DomainFactory
    {
        private DomainFactory()
        {
        }

        #region Variable

        private readonly Dictionary<string, object> _repositoyMaps = new Dictionary<string, object>();
        private readonly Dictionary<string, object> _modelFactoryMaps = new Dictionary<string, object>();
        private readonly Dictionary<string, object> _serviceMaps = new Dictionary<string, object>();
        private readonly Dictionary<string, object> _applicationMaps = new Dictionary<string, object>();

        private static readonly object padlock = new object();
        private static DomainFactory _domainFactory;

        #endregion

        public static DomainFactory GetInstance()
        {
            lock (padlock)
            {
                return _domainFactory ?? (_domainFactory = new DomainFactory());
            }
        }

        /// <summary>
        /// Generate the facotry
        /// </summary>
        /// <typeparam name="T">BaseFactory</typeparam>
        /// <returns>Factory</returns>
        public T GetModelFactory<T>()
            where T : ModelFactoryBase
        {
            var typeName = typeof (T).Name;

            lock (_modelFactoryMaps)
            {
                if (!_modelFactoryMaps.ContainsKey(typeName))
                {
                    var modelFactoryInstance = (T) Activator.CreateInstance(typeof (T), true);

                    _modelFactoryMaps.Add(typeName, modelFactoryInstance);

                    return modelFactoryInstance;
                }
                else
                {
                    return (T) _modelFactoryMaps[typeName];
                }
            }
        }

        /// <summary>
        /// Generate the repository factory
        /// </summary>
        /// <typeparam name="T">IRepository</typeparam>
        /// <returns>Repository facotry</returns>
        public T GetRepository<T>()
            where T : IRepository
        {
            var typeName = typeof(T).Name;

            lock (_repositoyMaps)
            {
                if (!_repositoyMaps.ContainsKey(typeName))
                {
                    var repositoryInstance = (T)Activator.CreateInstance(typeof(T), true);

                    _repositoyMaps.Add(typeName, repositoryInstance);

                    return repositoryInstance;
                }
                else
                {
                    return (T)_repositoyMaps[typeName];
                }
            }
        }

        /// <summary>
        /// Generate the repository factory
        /// </summary>
        /// <typeparam name="T">IRepository</typeparam>
        /// <returns>Repository facotry</returns>
        public T GetApplication<T>()
            where T : IApplication
        {
            var typeName = typeof(T).Name;

            lock (_applicationMaps)
            {
                if (!_applicationMaps.ContainsKey(typeName))
                {
                    var aplicationInstance = (T)Activator.CreateInstance(typeof(T), true);

                    _applicationMaps.Add(typeName, aplicationInstance);

                    return aplicationInstance;
                }
                else
                {
                    return (T)_applicationMaps[typeName];
                }
            }
        }

        /// <summary>
        /// Generate the servoce facotry
        /// </summary>
        /// <typeparam name="T">BaseService</typeparam>
        /// <returns>Service factory</returns>
        public T GetService<T>()
            where T : ServiceBase
        {
            var typeName = typeof(T).Name;

            lock (_serviceMaps)
            {
                if (!_serviceMaps.ContainsKey(typeName))
                {
                    var serviceInstance = (T)Activator.CreateInstance(typeof(T), true);

                    _serviceMaps.Add(typeName, serviceInstance);

                    return serviceInstance;
                }
                else
                {
                    return (T)_serviceMaps[typeName];
                }
            }
        }
    }
}