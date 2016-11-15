using Nancy;
using ToDoList.Objects;
using System.Collections.Generic;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["/createTask.cshtml"];
      Get["/viewTasks"] = _ => {
        List<string> viewAll = Task.GetAll();
        return View["viewTasks.cshtml", viewAll];
      };
      Post["/taskAdded"] = _ => {
        Task newTask = new Task (Request.Form["newTask"]);
        newTask.Save();
        return View["taskAdded.cshtml", newTask];
      };
      Post["/tasks_cleared"] = _ => {
        Task.ClearAll();
        return View["tasks_cleared.cshtml"];
      };
    }
  }
}
