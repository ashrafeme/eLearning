using Learning.Data;
using Learning.Services;
using Learning.Web.DI.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Learning.Web {
    public static class UnityConfig {

        public class UnityRepository<TEntity> : EntityRepository<TEntity, DbContext>
        where TEntity : Learning.Data.Entities.BaseEntity, new() {
            public UnityRepository(TEntity entity) : base(new DataContext("DefaultConnection")) { }
        }

        public static void RegisterComponents() {

            
        var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            

            container.RegisterType<DbContext, DataContext>(new HierarchicalLifetimeManager());

            container.RegisterType(typeof(IEntityRepository<>), typeof(UnityRepository<>), new HierarchicalLifetimeManager());

            container.RegisterType<ICourseService, CourseService>(new HierarchicalLifetimeManager());

            //container.RegisterType<StudentsController, StudentsController>(new HierarchicalLifetimeManager());

            

            GlobalConfiguration.Configuration.DependencyResolver =
                new UnityDependencyResolver(container);
        }
    }
}