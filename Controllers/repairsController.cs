﻿using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fixture02.Models;
using PagedList;

namespace Fixture02.Controllers
{
    public class RepairsController : BaseController
    {
        private fixtureEntities db = new fixtureEntities();

        // GET: repairs
        public ActionResult Index()
        {
            return View(db.repair.ToList());
        }

        // GET: repairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repair.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // GET: repairs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: repairs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepairID,CheckID,ItemID,Code,Name,FamilyID,FamilyName,Model,PartNo,Problem,Pic,AddDate,AddUserID,AddUserName,RepairDate,RepairUserName,RepairState")] repair repair)
        {
            if (ModelState.IsValid)
            {
                repair.AddDate = DateTime.Now;
                repair.RepairState = "新增";
                Employee user = (Employee)System.Web.HttpContext.Current.Session["user"];
                repair.AddUserID = user.EmployeeID;
                repair.AddUserName = user.EmployeeName;
                db.repair.Add(repair);
                db.SaveChanges();
                changeJigitemState(repair.ItemID, "维修");
                return RedirectToAction("Index");
            }

            return View(repair);
        }

        // GET: repairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repair.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: repairs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepairID,CheckID,ItemID,Code,Name,FamilyID,FamilyName,Model,PartNo,Problem,Pic,AddDate,AddUserID,AddUserName,RepairDate,RepairUserName,RepairState")] repair repair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repair);
        }

        // GET: repairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repair.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repair repair = db.repair.Find(id);
            db.repair.Remove(repair);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //the action below is written by fangyu
        //written by fangyu 20200208

        public ActionResult RepairHandling()            /*前往报修处理界面*/
        {
            return View(db.repair.ToList());
        }

        public ActionResult RepairSuccess(int? id)          /*修复成功*/
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repair.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            repair.RepairState = "修复";
            repair.RepairDate = DateTime.Now;
            repair.RepairUserName = "session.user.username";
            db.SaveChanges();
            changeJigitemState(repair.ItemID, "库存");
            return RedirectToAction("Index");
        }

        public ActionResult RepairFail(int? id)         /*修复失败*/
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repair.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            repair.RepairState = "未修复";
            repair.RepairDate = DateTime.Now;

            Employee user = (Employee)System.Web.HttpContext.Current.Session["user"];
            repair.RepairUserName = user.EmployeeName;

            db.SaveChanges();
            changeJigitemState(repair.ItemID, "报废");
            return RedirectToAction("Index");
        }

        public ActionResult changeJigitemState(int? itemid, string statename)
        {
            if (itemid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repair.Find(itemid);
            if (repair == null)
            {
                return HttpNotFound();
            }
            var otherController = DependencyResolver.Current.GetService<JigitemsController>();
            var action = otherController.changeItemState(itemid, statename);
            return action;
        }

        public ActionResult repairSubmit()
        {
            return View(db.repair.ToList());
        }

        public ActionResult repairSearch(String addUserName,String repairState, int page = 1, int pageSize = 4)
        {
            var name = db.repair.Include(e => e.AddUserID);
            if (!String.IsNullOrEmpty(addUserName))
            {
                name = name.Where(h => h.AddUserName.Contains(addUserName));
            }
            if (!String.IsNullOrEmpty(repairState))
            {
                name = name.Where(h => h.RepairState.Contains(repairState));
            }
            //用于分页，顺便跳转

            return View(name.OrderBy(x => x.AddUserID).ToPagedList(page, pageSize));
        }
    }
}
