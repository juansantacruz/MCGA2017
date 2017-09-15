﻿//using Glimpse.Mvc.AlternateType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.WbSite.Constants;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Services.Cache
{
    public class DataCache
    {
        #region singleton
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
                        _instance = new DataCache();
                    }
                }
                return _instance;
            }
        }
        #endregion

        private readonly ICacheService _cacheServices;
        private DataCache()
        {
            _cacheServices = DependencyResolver.Current.GetService<ICacheService>();
        }

        public List<Category> CategoryList()
        {
            _cacheServices.Remove(DataCacheSetting.Category.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Category.Key,
                () =>
                {
                    var cp = new CategoryProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Category.SlidingExpiration);
            return lista;

        }

        public void CategoryListRemove()
        {
            _cacheServices.Remove(DataCacheSetting.Category.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Category.Key,
                () =>
                {
                    var cp = new CategoryProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Category.SlidingExpiration);
            //return lista;

        }
    }
}
