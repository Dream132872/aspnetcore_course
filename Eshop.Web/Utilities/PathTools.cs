namespace Eshop.Web.Utilities
{
    public static class PathTools
    {
        #region slider

        public static string SliderImage = "/content/images/sliders/";
        public static string SliderImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/sliders/");
        public static string SliderImageThumbnail = "/content/images/sliders/thumbs/";
        public static string SliderImageThumbnailServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/sliders/thumbs/");

        #endregion
    }
}
