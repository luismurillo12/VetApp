namespace VetApp
{
    public class SaveImage
    {
        public static string SaveImageBase64(string ImgStr, string ImgName)
        {
            String path = "wwwroot/UsersPictures"; //Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = ImgName + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);


            ImgStr = ImgStr.Substring(ImgStr.LastIndexOf(',') + 1);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return imgPath.Replace("wwwroot/","");
        }
    }
}
