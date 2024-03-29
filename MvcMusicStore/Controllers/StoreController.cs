﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

using System.Data.Entity;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {

        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }

        //
        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genreModel);
        }

        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            //var album = storeDB.Albums.Find(id);
            var album = storeDB.Albums.Include(x=>x.Artist).Include(x=>x.Genre).Single(g=>g.AlbumId==id);
            return View(album);
        }

        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }

    }
}
