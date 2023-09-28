using Eshop.Web.Context;
using Eshop.Web.Entities.Catalog;
using Eshop.Web.Utilities;
using Eshop.Web.Utilities.ImageHelper;
using Eshop.Web.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Areas.Admin.Controllers;

public class SliderController : AdminBaseController
{
    // Ajax delete, Paging, permission checker
    
    #region constructor

    private readonly ApplicationDbContext _context;

    public SliderController(ApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region filter sliders

    public IActionResult Index(FilterSlidersViewModel filter)
    {
        var query = _context.Sliders.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(s => s.Title.Contains(filter.Title));

        if (!string.IsNullOrEmpty(filter.Url))
            query = query.Where(s => s.Url.Contains(filter.Url));

        filter.SetPaging(query);

        return View(filter);
    }

    #endregion

    #region create slider

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(CreateSliderViewModel slider)
    {
        if (ModelState.IsValid)
        {
            // 1- create new instance of slider entity
            var newSlider = new Slider()
            {
                Title = slider.Title,
                Url = slider.Url,
                Description = slider.Description,
                Image = "image.png"
            };

            // 2- save image in wwwroot
            // todo: add image to wwwroot directory
            string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(slider.Image.FileName);
            slider.Image.AddImageToServer(imageName, PathTools.SliderImageServerPath, 75, 75, PathTools.SliderImageThumbnailServerPath);
            newSlider.Image = imageName;

            // 3- add slider to db
            _context.Sliders.Add(newSlider);
            _context.SaveChanges();
            return RedirectToAction("Index", "Slider", new { area = "Admin" });
        }

        return View(slider);
    }

    #endregion

    #region edit slider

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var slider = _context.Sliders.SingleOrDefault(s => s.Id == id);

        if (slider == null) return NotFound();

        var sliderVm = new EditSliderViewModel
        {
            Title = slider.Title,
            Description = slider.Description,
            Url = slider.Url,
            Id = slider.Id,
            ImageName = slider.Image
        };

        return View(sliderVm);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EditSliderViewModel slider)
    {
        var dbSlider = _context.Sliders.SingleOrDefault(s => s.Id == id);
        if (dbSlider == null) return NotFound();

        if (ModelState.IsValid)
        {
            dbSlider.Title = slider.Title;
            dbSlider.Description = slider.Description;
            dbSlider.Url = slider.Url;
            if (slider.Image != null)
            {
                string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(slider.Image.FileName);
                slider.Image.AddImageToServer(imageName, PathTools.SliderImageServerPath, 75, 75, PathTools.SliderImageThumbnailServerPath, dbSlider.Image);
                dbSlider.Image = imageName;
            }

            _context.Sliders.Update(dbSlider);
            _context.SaveChanges();
            return RedirectToAction("Index", "Slider", new { area = "admin" });
        }

        return View();
    }

    #endregion

    #region delete slider

    /// <summary>
    /// delete slider by its id
    /// </summary>
    /// <param name="id">id of slider</param>
    /// <returns>json response to check sliders has been deleted or not</returns>
    public IActionResult DeleteSlider(int id)
    {
        // get slider by id
        var slider = _context.Sliders.SingleOrDefault(s => s.Id == id);
        // check slider is exists or not
        if (slider == null) return Json(new { status = "not-found" });
        // delete slider
        _context.Sliders.Remove(slider);
        _context.SaveChanges();
        return Json(new { status = "success" });
    }

    #endregion
}