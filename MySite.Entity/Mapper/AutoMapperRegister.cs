using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MySite.Entity.Mapper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySite.Entity.Mapper
{
    public static class AutoMapperRegister
    {
        /// <summary>
        /// Register and configure AutoMapper
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="typeFinder">Type finder</param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            //find mapper configurations provided by other assemblies
            var mapperConfigurations = AppDomain.CurrentDomain.GetAssemblies().FindClassesOfType<IOrderedMapperProfile>();

            //create and sort instances of mapper configurations
            var instances = mapperConfigurations
                .Select(mapperConfiguration => (IOrderedMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var instance in instances)
                {
                    cfg.AddProfile(instance.GetType());
                }
            });

            //register
            AutoMapperConfiguration.Init(config);
        }
    }
}
