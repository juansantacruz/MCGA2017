using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.UI.WbSite.Constants;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Services.Cache
{
    public class DataCache
    {
        #region Singleton
        private static DataCache _instance;
        private static readonly object InstanceLock = new object();
        public static DataCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataCache();
                        }
                    }
                }
                return _instance;
            }
            
        }
        #endregion

        private readonly ICacheService _cacheService;
        private DataCache()
        {
            _cacheService = DependencyResolver.Current.GetService<ICacheService>();
        }

        public List<Category> CategoryList()
        {
            var lista = _cacheService.GetOrAdd(
                DataCacheSetting.Category.Key,
                () =>
                {
                    var cp = new CategoryProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Category.SlidingExpiration);
            return lista;

           // _cacheService.Remove(DataCacheSetting.Category.Key);
        }

        public void CategoryListRemoveCache()
        {
            _cacheService.Remove(DataCacheSetting.Category.Key);

        }
      

    }

}
