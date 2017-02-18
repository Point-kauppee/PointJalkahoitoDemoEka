using System;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using PointJalkahoitoDemoEka.Models;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Month;
using DayPilot.Web.Mvc.Enums;
using System.Web;
using DayPilot.Web.Mvc.Events.Calendar;



namespace PointJalkahoitoDemoEka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backend()
        {
            return new Dpm().CallBack(this);
        }

        //class Dpm : DayPilotMonth
        class Dpm : DayPilotCalendar
        {
            //kauppeedbEntities db = new kauppeedbEntities();

            //protected override void OnInit(InitArgs e)
            //{
            //    Update(CallBackUpdateType.Full);
            //}
            protected override void OnInit(DayPilot.Web.Mvc.Events.Calendar.InitArgs e)
            {
                kauppeedbEntities db = new kauppeedbEntities();
                Events = from ev in db.Varaus select ev;

                DataIdField = "Varaus_id";
                DataTextField = "Palvelun_nimi";
                DataStartField = "Alku";
                DataEndField = "Loppu";

                Update();
            }

            protected override void OnCommand(DayPilot.Web.Mvc.Events.Calendar.CommandArgs e)
            {
                switch (e.Command)
                {
                    case "previous":
                        StartDate = StartDate.AddDays(-7);
                        Update(CallBackUpdateType.Full);
                        break;
                    case "next":
                        StartDate = StartDate.AddDays(7);
                        Update(CallBackUpdateType.Full);
                        break;
                }
                //base.OnCommand(e);
            }
            protected override void OnEventResize(DayPilot.Web.Mvc.Events.Calendar.EventResizeArgs e)
            //protected override void OnInit(DayPilot.Web.Mvc.Events.Month.InitArgs e)
            {
                kauppeedbEntities db = new kauppeedbEntities();
                var eid = Convert.ToInt32(e.Id);
                //var toBeResized = (from ev in db.Varaus where ev.Varaus_id == Convert.ToInt32(e.Id) select ev).First();
                var toBeResized = (from ev in db.Varaus where ev.Varaus_id == eid select ev).First();
                toBeResized.Alku = e.NewStart;
                toBeResized.Loppu = e.NewEnd;
                //toBeResized.Alku = Convert.ToString(e.NewStart);
                //toBeResized.Loppu = Convert.ToString(e.NewEnd);
                //db.SubmitChanges();
                db.SaveChanges();
                Update();
            }


            //    Update();
            //}
            protected override void OnEventMove(DayPilot.Web.Mvc.Events.Calendar.EventMoveArgs e)
            {
                //var db = new kauppeedbEntities();
                kauppeedbEntities db = new kauppeedbEntities();

                var eid = Convert.ToInt32(e.Id);
                //var toBeResized = (from ev in db.Varaus where ev.Varaus_id == Convert.ToInt32(e.Id) select ev).First();
                var toBeResized = (from ev in db.Varaus where ev.Varaus_id == eid select ev).First();
                toBeResized.Alku = e.NewStart;
                toBeResized.Loppu = e.NewEnd;
                //toBeResized.Alku = Convert.ToString(e.NewStart);
                //toBeResized.Loppu = Convert.ToString(e.NewEnd);
                //db.SubmitChanges();
                db.SaveChanges();
                Update();
            }

            //protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            //{
            //    string name = (string)e.Data["name"];
            //    if (String.IsNullOrEmpty(name))
            //    {
            //        name = "(default)";
            //    }
            //    new EventManager(Controller).EventCreate(e.Start, e.End, name);
            //    Update();
            //}



            protected override void OnTimeRangeSelected(DayPilot.Web.Mvc.Events.Calendar.TimeRangeSelectedArgs e)
            {

                kauppeedbEntities db = new kauppeedbEntities();
                //var edata = (string)e.Data["name"];
                //var edata = Convert.ToString(e.Data["name"]);
                //var toBeCreated = new Varaus { Alku = Convert.ToString(e.Start), Loppu = Convert.ToString(e.End), Palvelun_nimi = (string)e.Data["name"] };
                //var toBeCreated = new Varaus { Alku = Convert.ToString(e.Start), Loppu = Convert.ToString(e.End), Palvelun_nimi = (string)e.Data["name"] };
                var toBeCreated = new Varaus { Alku = e.Start, Loppu = e.End, Palvelun_nimi = (string)e.Data["name"] };
                //var toBeCreated = new Varaus { Alku = e.Start, Loppu = e.End, Palvelun_nimi = Convert.ToString(e.Data["name"]) };
                //var toBeCreated = new Varaus { Alku = e.Start, Loppu = e.End, Palvelun_nimi = "Nettivaraus + [e.name]" };
                //var toBeCreated = new Varaus { Alku = e.Start, Loppu = e.End, Palvelun_nimi = edata};

                //db.Varaus.InsertOnSubmit(toBeCreated);
                db.Varaus.Add(toBeCreated);
                db.SaveChanges();
                //db.SubmitChanges();
                Update();
                }


            protected override void OnFinish()
            {
                if (UpdateType == CallBackUpdateType.None)
                {
                    return;
                }

                kauppeedbEntities db = new kauppeedbEntities();               //Events = new EventManager(Controller).Data.AsEnumerable();
                Events = from ev in db.Varaus select ev;
                //Events = from varaus_id in db.Varaus select varaus_id;

                DataIdField = "Varaus_id";
                DataTextField = "Palvelun_nimi";
                DataStartField = "Alku";
                DataEndField = "Loppu";

            }
        }
    }
}
