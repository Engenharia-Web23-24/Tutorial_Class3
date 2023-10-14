namespace Class03.Models
{
    public class DocFiles
    {
        //This method gets all filenames from folder...
        // ... instead of get them from a database or other storage kind

        public List<FileViewModel> GetFiles(IHostEnvironment e)
        {
            List<FileViewModel> list =  new List<FileViewModel>();

            // Get all information from "wwwroot/Documents" folder
            DirectoryInfo dirInfo = new DirectoryInfo(
                    Path.Combine(e.ContentRootPath, "wwwroot/Documents")
                );

            // use the information from folder to get the files names
            foreach(var item in dirInfo.GetFiles())
            {
                list.Add(new FileViewModel
                {
                    Name = item.Name,
                    Size = item.Length
                });
            }

            return list;
        }
    }
}
