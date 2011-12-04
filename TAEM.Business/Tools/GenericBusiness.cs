using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace TAEM.Business.Tools
{
    public static class GenericBusiness
    {
        public static ISession GetCurrentSession()
        {
            return GetCurrentSession(null);
        }

        public static ISession GetCurrentSession(string sessionName)
        {
            PersistenceManager persistence = new PersistenceManager(sessionName);
            return persistence.Session;
        }

        public static T Load<T>(object id, string sessionName)
        {
            PersistenceManager persistence = new PersistenceManager(sessionName);
            return persistence.Load<T>(id);
        }

        public static T Load<T>(object id)
        {
            return Load<T>(id, null);
        }

        public static T Get<T>(object id, string sessionName)
        {
            PersistenceManager persistence = new PersistenceManager(sessionName);
            return persistence.Get<T>(id);
        }

        public static T Get<T>(object id)
        {
            return Get<T>(id, null);
        }

        public static T Update<T>(T domain, bool transaccional, string sessionName)
        {
            PersistenceManager persistence = new PersistenceManager(sessionName);
            if (!transaccional)
            {
                persistence.Update(domain);
                persistence.Flush();
                return domain;
            }
            else
            {
                try
                {
                    persistence.BeginTransaction();
                    persistence.Update(domain);
                    persistence.Commit();
                    return domain;
                }
                catch
                {
                    //persistence.Rollback();
                    throw;
                }
            }
        }

        public static T Update<T>(T domain, bool transaccional)
        {
            return Update<T>(domain, transaccional, null);
        }

        public static T Create<T>(T domain, bool transaccional, string sessionName)
        {
            PersistenceManager persistence = new PersistenceManager(sessionName);
            if (!transaccional)
            {
                persistence.Save(domain);
                persistence.Flush();
                return domain;
            }
            else
            {
                try
                {
                    persistence.BeginTransaction();
                    persistence.Save(domain);
                    persistence.Commit();
                    return domain;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static T Create<T>(T domain, bool transaccional)
        {
            return Create<T>(domain, transaccional, null);
        }

        public static void Delete<T>(T domain, bool transaccional, string sessionName)
        {
            PersistenceManager persistence = new PersistenceManager(sessionName);
            if (!transaccional)
            {
                persistence.Delete(domain);
                persistence.Flush();
            }
            else
            {
                try
                {
                    persistence.BeginTransaction();
                    persistence.Delete(domain);
                    persistence.Commit();
                }
                catch
                {
                    //persistence.Rollback();
                    throw;
                }
            }
        }

        public static void Delete<T>(T domain, bool transaccional)
        {
            Delete<T>(domain, transaccional, null);
        }

        /// <summary>
        /// Permite obtener todos los objetos de un tipo
        /// </summary>
        /// <typeparam name="T">Objeto del dominio</typeparam>
        /// <param name="propiedad">nombre de la propiedad a ordenar</param>
        /// <param name="asc">tipo de orden</param>
        /// <param name="sessionName"></param>
        /// <returns></returns>
        public static IList<T> ListAll<T>(string propiedad, bool asc, string sessionName)
        {
            PersistenceManager persistence = new PersistenceManager(sessionName);
            ICriteria criteria = persistence.CreateCriteria(typeof(T));
            if (!string.IsNullOrEmpty(propiedad))
            {
                criteria.AddOrder(new Order(propiedad, asc));
            }
            return criteria.List<T>();
        }

        /// <summary>
        /// Permite obtener todos los objetos de un tipo de la clase (Usando PropiedadesSession)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propiedad">Propiedad por la que se ordenara</param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public static IList<T> ListAll<T>(string propiedad, bool asc)
        {
            return ListAll<T>(propiedad, asc, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> ListAll<T>()
        {
            return ListAll<T>(null, false, null);
        }

        public static void Refresh(object objeto)
        {
            Refresh(objeto, null);
        }

        public static void Refresh(object objeto, string sessionName)
        {
            PersistenceManager persistence = new PersistenceManager(sessionName);
            persistence.Refresh(objeto);
        }

        public static T GetUnproxy<T>(T objeto)
        {
            PersistenceManager persistence = new PersistenceManager();
            var dp = objeto;
            NHibernateUtil.Initialize(dp);
            T objetoRetorno = (T)persistence.Session.GetSessionImplementation().PersistenceContext.Unproxy(dp);
            return objetoRetorno;
        }

    }
}