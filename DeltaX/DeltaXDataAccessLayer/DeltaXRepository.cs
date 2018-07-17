using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaXDataAccessLayer
{
    public class DeltaXRepository
    {
        private DeltaXDBContext Context { get; set; }

        public DeltaXRepository()
        {
            Context = new DeltaXDBContext();
        }

        public List<Actor> FetchActor()
        {
            try
            {
                var data = Context.Actors.ToList();
                if (data!=null)
                    return data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool AddActor(Actor obj)
        {
            try
            {
                Actor a = new Actor();
                a.ActorName = obj.ActorName;
                a.ActorSex = obj.ActorSex;
                a.ActorDOB = obj.ActorDOB;
                a.ActorBio = obj.ActorBio;
                Context.Actors.Add(a);
                Context.SaveChanges();
                return true;   
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Producer> FetchProducer()
        {
            try
            {
                var data = Context.Producers.ToList();
                if (data != null)
                    return data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddProducer(Producer obj)
        {
            try
            {
                Producer a = new Producer();
                a.ProducerName = obj.ProducerName;
                a.ProducerSex = obj.ProducerSex;
                a.ProducerDOB = obj.ProducerDOB;
                a.ProducerBio = obj.ProducerBio;
                Context.Producers.Add(a);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Movie> FetchMovie()
        {
            try
            {
                var data = (from m in Context.Movies select m).ToList();
                if (data != null)
                    return data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddMovie(Movie obj, string[] ActorsIdArray)
        {
            try
            {
                Movie m = new Movie();
                m.MovieName = obj.MovieName;
                m.MoviePoster = obj.MoviePoster;
                m.MoviePlot = obj.MoviePlot;
                m.MovieYearOfRelease = obj.MovieYearOfRelease;
                m.ProducerId = obj.ProducerId;
                for (int i = 0; i < ActorsIdArray.Length; i++)
                {
                    var actId = Int32.Parse(ActorsIdArray[i]);
                    var actor = (from a in Context.Actors where a.ActorId == actId select a).Single();
                    m.Actors.Add(actor);
                }
                Context.Movies.Add(m);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMovie(Movie obj,string[] ActorsIdArray)
        {
            try
            {
                Movie m = Context.Movies.Find(obj.MovieId);
                m.MovieName = obj.MovieName;
                m.MoviePoster = obj.MoviePoster;
                m.MoviePlot = obj.MoviePlot;
                m.MovieYearOfRelease = obj.MovieYearOfRelease;
                m.ProducerId = obj.ProducerId;
                for (int i = 0; i < ActorsIdArray.Length; i++)
                {
                    var actId = Int32.Parse(ActorsIdArray[i]);
                    var actor = (from a in Context.Actors where a.ActorId == actId select a).Single();
                    m.Actors.Add(actor);
                }
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
