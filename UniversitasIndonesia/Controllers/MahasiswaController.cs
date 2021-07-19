using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitasIndonesia.Data;
using UniversitasIndonesia.Models;

namespace UniversitasIndonesia.Controllers
{
    [Authorize]
    public class MahasiswaController : Controller
    {
        private readonly UniversitasIndonesiaDbContext _db;


        public MahasiswaController(UniversitasIndonesiaDbContext db)
        {
            _db = db;
        }
        //GET INDEX
        public IActionResult Index()
        {
            IEnumerable<Mahasiswa> objList = _db.Mahasiswa;
            return View(objList);
        }
        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mahasiswa obj)
        {
            if (ModelState.IsValid)
            {
                _db.Mahasiswa.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(obj);


        }

        //GET EDIT
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Mahasiswa.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mahasiswa obj)
        {
            if (ModelState.IsValid)
            {
                _db.Mahasiswa.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(obj);


        }

        //GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Mahasiswa.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Mahasiswa.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Mahasiswa.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}
