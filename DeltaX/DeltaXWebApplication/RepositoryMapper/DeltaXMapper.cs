using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DeltaXDataAccessLayer;

namespace DeltaXWebApplication.RepositoryMapper
{
    public class DeltaXMapper<Source,Destination>
        where Source : class
        where Destination : class
    {
        MapperConfiguration config;
        public DeltaXMapper()
        {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Models.Actor, Actor>();
                cfg.CreateMap<Actor, Models.Actor>();
                cfg.CreateMap<Models.Movie, Movie>();
                cfg.CreateMap<Movie, Models.Movie>();
                cfg.CreateMap<Models.Producer, Producer>();
                cfg.CreateMap<Producer, Models.Producer>();
            });
        }
        public Destination Translate(Source obj)
        {
            IMapper Mapper = config.CreateMapper();
            return Mapper.Map<Source, Destination>(obj);
        }
    }
}