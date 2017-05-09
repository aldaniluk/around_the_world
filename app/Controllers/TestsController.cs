using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using app.Models;

namespace app.Controllers
{
    public class TestsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        //show test's types
        public ActionResult Index()
        {
            return View(db.TestTypes.ToList());
        }

        //show questions in one type
        //public ActionResult PassTest(int id)
        //{
        //    ViewBag.Header = db.TestTypes.Find(id).Type;

        //    IList<QuestionsViewModel> model = new List<QuestionsViewModel> ();
        //    IEnumerable<Question> questionmy;

        //    int quantity = db.Questions.Count();
        //    Random r = new Random();
        //    int[] arr = new int[5];

        //    Question quest = null;

        //    for (int i=1; i<=arr.Length; i++)
        //    {
        //        int rand = r.Next(1, quantity+1);
        //        if(arr.Contains(rand))
        //        {
        //            i--;
        //            continue;
        //        }
        //        quest = db.Questions.Find(rand);
        //        if(quest.TestTypes_Id != id)
        //        {
        //            i--;
        //            continue;
        //        }
        //        arr[i - 1] = rand;
        //        Question q = null;
        //        List<Answer> a = new List<Answer> ();

        //        if (quest.TestTypes_Id == id)
        //        {
        //            q = quest;
        //            foreach(var j in db.Answers)
        //            {
        //                if(j.Questions_Id == quest.Id)
        //                {
        //                    a.Add(j);
        //                }

        //            }
        //            model.Add(new QuestionsViewModel()
        //            {
        //                Question = q,
        //                Answers = a
        //            });
        //        }
        //    }
        //    if (id == 1)
        //        return View("PassTest", model);
        //    else
        //        return View("~/Views/Tests/PassTest_Img.cshtml", model);
        //}

        public ActionResult PassTest(int id)
        {
            ViewBag.Header = db.TestTypes.Find(id).Type;

            List<Question> listquestions = new List<Question>();
            Question quest = null;

            int quantity = db.Questions.Count();
            Random r = new Random();
            int[] arr = new int[5];

            for (int i = 1; i <= arr.Length; i++) //find 5 appropriated questions
            {
                int rand = r.Next(1, quantity + 1);
                if (arr.Contains(rand))
                {
                    i--;
                    continue;
                }
                quest = db.Questions.Find(rand);
                if (quest.TestTypes_Id != id) //id questions are repeated, search new question
                {
                    i--;
                    continue;
                }
                arr[i - 1] = rand;
                listquestions.Add(quest); //add appropriated questions
            }
            if (id == 1)
                return View("PassTest", listquestions);
            else
                return View("~/Views/Tests/PassTest_Img.cshtml", listquestions);
        }

        //show a right answer
        public PartialViewResult AjaxCheckAnswer(int id)
        {
            int idQuestion = db.Answers.Find(id).Questions_Id;

            //QuestionsViewModel model = new QuestionsViewModel()
            //{
            //    Questions = (Question)db.Questions.Find(idQuestion),
            //    Answers = (IList<Answer>)db.Answers.Where(i => i.Questions_Id == idQuestion)
            //};

            List<Answer> newlist = new List<Answer>();
            foreach (var i in db.Answers.Where(i => i.Questions_Id == idQuestion))
            {
                newlist.Add(i);
            }

            if (db.Answers.Find(id).Right == true)
            {
                ViewBag.WrongAns = null;
            }
            else
            {
                ViewBag.WrongAns = db.Answers.Find(id);
            }

            if(db.Questions.Find(idQuestion).TestTypes_Id == 1)
                return PartialView("_PartialView_Answers", newlist);
            else
                return PartialView("_PartialView_Answers_Img", newlist);
        }
    }
}