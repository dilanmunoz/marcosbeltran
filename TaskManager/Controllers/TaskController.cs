using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private TaskDbContext db = new TaskDbContext();
        // GET: Task
        public ActionResult Index()
        {
            var tasks = db.Tasks.ToList();
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                TempData["SuccessMessage"] = "La tarea se creó correctamente.";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Hubo un error al crear la tarea.";
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            var task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "La tarea se edito correctamente.";
                return RedirectToAction("Index");
            }
            return View(task);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var task = db.Tasks.Find(id);
            if (task == null)
            {
                return Json(new { success = false, message = "Tarea no encontrada" });
            }

            task.IsCompleted = !task.IsCompleted;
            db.SaveChanges();

            return Json(new { success = true, isCompleted = task.IsCompleted });
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            var task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var task = db.Tasks.Find(id);
                if (task == null)
                {
                    TempData["ErrorMessage"] = "La tarea no fue encontrada o ya fue eliminada.";
                    return RedirectToAction("Index");
                }

                db.Tasks.Remove(task);
                db.SaveChanges();

                TempData["SuccessMessage"] = "La tarea se eliminó correctamente.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al eliminar la tarea. Intente nuevamente.";
            }

            return RedirectToAction("Index");
        }
    }
}