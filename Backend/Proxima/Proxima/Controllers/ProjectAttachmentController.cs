using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Helpers;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAttachmentController : ControllerBase
    {
        private readonly ProjectAttachmentsRepository _attachmentRepository;
        private readonly string _fileDirectory;
        public ProjectAttachmentController(ProjectAttachmentsRepository attachmentRepository)
        {
            _fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            _attachmentRepository = attachmentRepository;
        }

        #region Get All Attachments
        [HttpGet]
        public IActionResult GetAllAttachments()
        {
            var attachments = _attachmentRepository.GetAllAttachments();
            if (attachments == null || attachments.Count == 0)
            {
                return NotFound("No attachments found.");
            }
            return Ok(attachments);
        }
        #endregion

        #region Get AttachmentsByAttachmentID
        [HttpGet("AttachmentByAttachmentID/{attachmentID}")]
        public IActionResult GetAttachmentByAttachmentID(int attachmentID)
        {
            var attachments = _attachmentRepository.GetAttachmentByAttachmentID(attachmentID);
            if (attachments == null)
            {
                return NotFound("No attachments found.");
            }
            return Ok(attachments);
        }
        #endregion

        #region Get AttachmentsByProjectID
        [HttpGet("AttachmentByProjectID/{projectID}")]
        public IActionResult GetAttachmentByProjectID(int projectID)
        {
            var attachments = _attachmentRepository.GetAttachmentsByProject(projectID);
            if (attachments == null || attachments.Count == 0)
            {
                return NotFound("No attachments found.");
            }
            return Ok(attachments);
        }
        #endregion

        #region Add Attachment
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, int projectId, int uploadedBy)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file.");

            // Save file to directory
            string savedFileName = FileHelper.SaveFile(file, _fileDirectory);
            if (string.IsNullOrEmpty(savedFileName))
                return BadRequest("File upload failed.");

            string filePath = Path.Combine(savedFileName);
            string fileType = Path.GetExtension(file.FileName);

            // Call the repository method to insert attachment details
            ProjectAttachmentSave attachment = new ProjectAttachmentSave
            {
                ProjectID = projectId,
                FileName = file.FileName,
                FileType = fileType,
                FilePath = filePath,
                UploadedBy = uploadedBy
            };

            bool isSaved = _attachmentRepository.AddAttachment(attachment);
            if (!isSaved)
                return StatusCode(500, "Failed to save attachment details.");

            return Ok(new { Message = "File uploaded successfully.", FilePath = filePath });
        }

        #endregion

        #region Update Attachment
        [HttpPut("{attachmentID}")]
        public IActionResult UpdateAttachment(int attachmentID, [FromBody] UpdateAttachmentModel attachment)
        {
            if (attachment == null || attachmentID != attachment.AttachmentID)
            {
                return BadRequest("Invalid attachment data.");
            }

            bool isUpdated = _attachmentRepository.UpdateAttachment(attachment);
            if (isUpdated)
            {
                return Ok(new { Message = "Attachment updated successfully." });
            }
            return StatusCode(500, "An error occurred while updating the attachment.");
        }
        #endregion

        #region Delete Attachment
        [HttpDelete("{attachmentId}")]
        public async Task<IActionResult> DeleteAttachment(int attachmentId)
        {
            // Fetch the attachment details from the database
            var attachment = _attachmentRepository.GetAttachmentByAttachmentID(attachmentId);
            if (attachment == null)
                return NotFound("Attachment not found.");

            string fullFilePath = Path.Combine(_fileDirectory, attachment.FilePath);

            // Delete file from directory
            if (System.IO.File.Exists(fullFilePath))
            {
                System.IO.File.Delete(fullFilePath);
            }

            // Delete from database
            bool isDeleted = _attachmentRepository.DeleteAttachment(attachmentId);
            if (!isDeleted)
                return StatusCode(500, "Failed to delete attachment from database.");

            return Ok(new { Message = "Attachment deleted successfully." });
        }
        #endregion




    }
}
