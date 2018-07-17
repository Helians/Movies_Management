using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeltaXDataAccessLayer;
using DeltaXWebApplication.RepositoryMapper;
namespace DeltaXWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetAllMovieDetails()
        {
            DeltaXMapper<Movie, Models.Movie> mapobj = new DeltaXMapper<Movie, Models.Movie>();
            DeltaXRepository obj = new DeltaXRepository();
            var mov = obj.FetchMovie();
            var MovieList = new List<Models.Movie>();
            MovieList = mov.Select(x => new Models.Movie
            {
                MovieName = x.MovieName,
                MoviePlot = x.MoviePlot,
                MoviePoster = x.MoviePoster,
                MovieYearOfRelease = x.MovieYearOfRelease,
                MovieId = x.MovieId,
                ProducerId = x.ProducerId,
                ProducerName = x.Producer.ProducerName,
                Actors = x.Actors.Select(z => z.ActorName).ToList()
            }).ToList();
            return View(MovieList);

        }

        public ActionResult CreateMovie()
        {
            DeltaXRepository obj = new DeltaXRepository();
            ViewBag.producerList = obj.FetchProducer();
            ViewBag.ActorList = obj.FetchActor();
            return View();
        }

        public ActionResult CreateActor(Models.Actor record)
        {
            DeltaXMapper<Models.Actor, Actor> mapobj = new DeltaXMapper<Models.Actor, Actor>();
            DeltaXRepository obj = new DeltaXRepository();
            obj.AddActor(mapobj.Translate(record));
            return RedirectToAction("CreateMovie");
        }

        public ActionResult CreateProducer(Models.Producer record)
        {
            DeltaXMapper<Models.Producer, Producer> mapobj = new DeltaXMapper<Models.Producer, Producer>();
            DeltaXRepository obj = new DeltaXRepository();
            obj.AddProducer(mapobj.Translate(record));
            return RedirectToAction("CreateMovie");
        }

        public ActionResult AddMovieDetails(Models.Movie record)
        {
                DeltaXMapper<Models.Movie, Movie> mapobj = new DeltaXMapper<Models.Movie, Movie>();
                DeltaXMapper<Producer, Models.Producer> mapobj1 = new DeltaXMapper<Producer, Models.Producer>();
                DeltaXRepository obj = new DeltaXRepository();
                var ActorsIdArray = record.ActorList.Split(',');
                var mov = obj.AddMovie(mapobj.Translate(record), ActorsIdArray);
                return RedirectToAction("GetAllMovieDetails");

        }

        public ActionResult UpdateMovie(int id)
        {
            DeltaXRepository obj = new DeltaXRepository();
            DeltaXMapper<Movie, Models.Movie> mapobj = new DeltaXMapper<Movie, Models.Movie>();
            ViewBag.producerList = obj.FetchProducer();
            ViewBag.ActorList = obj.FetchActor();
            var mov = obj.FetchMovie().Where(x => x.MovieId == id).Single();
            return View(mapobj.Translate(mov));
        }

        public ActionResult UpdateMovieDetails(Models.Movie record)
        {
            DeltaXMapper<Models.Movie, Movie> mapobj = new DeltaXMapper<Models.Movie, Movie>();
            DeltaXRepository obj = new DeltaXRepository();
            var ActorsIdArray = record.ActorList.Split(',');
            var mov = obj.UpdateMovie(mapobj.Translate(record), ActorsIdArray);
            return RedirectToAction("GetAllMovieDetails");

        }
        public PartialViewResult RenderAddActor()
        {
            return PartialView();
        }

        public PartialViewResult RenderAddProducer()
        {
            return PartialView();
        }
        
    }
}