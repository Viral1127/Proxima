namespace Proxima.Helpers
{
    public class FileHelper
    {
        public static string SaveFile(IFormFile file, string directoryPath)
        {
            if (file == null || file.Length == 0)
                return null;

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Get file extension and validate
            string fileExtension = Path.GetExtension(file.FileName);
            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                return null; // Invalid file
            }

            // Generate a unique file name
            string fileName = $"{Guid.NewGuid()}{fileExtension}";
            string fullPath = Path.Combine(directoryPath, fileName);

            // Save the file
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName; // Return only the file name, not full path
        }

        public static byte[] ReadFileBytes(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return null;

            return File.ReadAllBytes(filePath);
        }
    }
}
