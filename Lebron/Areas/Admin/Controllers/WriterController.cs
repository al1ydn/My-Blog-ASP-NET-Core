using Lebron.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lebron.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateJsonDetail(int writerId)
        {
            var writer = writerModels.FirstOrDefault(x => x.Id == writerId);

            return Json(JsonConvert.SerializeObject(writer));
        }

        public IActionResult CreateJsonWriters()
        {
            return Json(JsonConvert.SerializeObject(writerModels));
        }

        public IActionResult Add(WriterModel writerModel)
        {
            writerModels.Add(writerModel);

            return Json(JsonConvert.SerializeObject(writerModels));
        }

        public IActionResult Delete(int writerId)
        {
            WriterModel selectedModel = writerModels.FirstOrDefault(x => x.Id == writerId);
            writerModels.Remove(selectedModel);

            return Json(JsonConvert.SerializeObject(writerModels));
        }

        public IActionResult Update(WriterModel writerModel)
        {
            WriterModel selectedModel = writerModels.FirstOrDefault(x => x.Id == writerModel.Id);
            selectedModel.Name = writerModel.Name;

            return Json(JsonConvert.SerializeObject(writerModels));
        }

        public static List<WriterModel> writerModels = new List<WriterModel>
        {
            new WriterModel
            {
                Id = 1,
                Name = "tee",
            },
            new WriterModel
            {
                Id = 2,
                Name = "gee",
            },
            new WriterModel
            {
                Id = 3,
                Name = "vee",
            }
        };
    }
}
