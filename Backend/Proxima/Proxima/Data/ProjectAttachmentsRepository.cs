using System.Data;
using System.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class ProjectAttachmentsRepository
    {
        private readonly string _connectionString;

        public ProjectAttachmentsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region AddAttachment
        public bool AddAttachment(ProjectAttachmentSave attachment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_ProjectAttachments_InsertProjectAttachment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProjectID", attachment.ProjectID);
                cmd.Parameters.AddWithValue("@FileName", attachment.FileName);
                cmd.Parameters.AddWithValue("@FileType", attachment.FileType);
                cmd.Parameters.AddWithValue("@FilePath", attachment.FilePath);
                cmd.Parameters.AddWithValue("@UploadedBy", attachment.UploadedBy);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region GetAttachmentsByAttachmentID
        public ProjectAttachmentModel GetAttachmentByAttachmentID(int attachmentID)
        {
            ProjectAttachmentModel attachment = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_ProjectAttachments_GetAttachmentsByID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@AttachmentID", attachmentID);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) // Read only once since we need a single object
                {
                    attachment = new ProjectAttachmentModel
                    {
                        AttachmentID = Convert.ToInt32(reader["AttachmentID"]),
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        ProjectName = reader["Title"].ToString(),
                        FileName = reader["FileName"].ToString(),
                        FileType = reader["FileType"].ToString(),
                        FilePath = reader["FilePath"].ToString(),
                        UploadedBy = Convert.ToInt32(reader["UserID"]),
                        UploadedByUser = reader["UploadedBy"].ToString(),
                        UploadedAt = Convert.ToDateTime(reader["UploadedAt"])
                    };
                }
            }
            return attachment;
        }

        #endregion

        #region GetAttachmentsByProject
        public List<ProjectAttachmentModel> GetAttachmentsByProject(int projectId)
        {
            var attachments = new List<ProjectAttachmentModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_ProjectAttachments_GetAttachmentsByProject", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProjectID", projectId);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    attachments.Add(new ProjectAttachmentModel
                    {
                        AttachmentID = Convert.ToInt32(reader["AttachmentID"]),
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        ProjectName = reader["Title"].ToString(),
                        FileName = reader["FileName"].ToString(),
                        FileType = reader["FileType"].ToString(),
                        FilePath = reader["FilePath"].ToString(),
                        UploadedBy = Convert.ToInt32(reader["UserID"]),
                        UploadedByUser = reader["UploadedBy"].ToString(),
                        UploadedAt = Convert.ToDateTime(reader["UploadedAt"])
                    });
                }
            }
            return attachments;
        }
        #endregion

        #region GetAllAttachments
        public List<ProjectAttachmentModel> GetAllAttachments()
        {
            var attachments = new List<ProjectAttachmentModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_ProjectAttachments_GetAllAttachments", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    attachments.Add(new ProjectAttachmentModel
                    {
                        AttachmentID = Convert.ToInt32(reader["AttachmentID"]),
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        ProjectName = reader["Title"].ToString(),
                        FileName = reader["FileName"].ToString(),
                        FileType = reader["FileType"].ToString(),
                        FilePath = reader["FilePath"].ToString(),
                        UploadedBy = Convert.ToInt32(reader["UserID"]),
                        UploadedByUser = reader["UploadedByUser"].ToString(),
                        UploadedAt = Convert.ToDateTime(reader["UploadedAt"])
                    });
                }
            }
            return attachments;
        }
        #endregion

        #region UpdateAttachment
        public bool UpdateAttachment(UpdateAttachmentModel attachment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_ProjectAttachments_EditProjectAttachment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@AttachmentID", attachment.AttachmentID);
                cmd.Parameters.AddWithValue("@FileName", attachment.FileName);
                cmd.Parameters.AddWithValue("@FileType", attachment.FileType);
                cmd.Parameters.AddWithValue("@FilePath", attachment.FilePath);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region DeleteAttachment
        public bool DeleteAttachment(int attachmentId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_ProjectAttachments_RemoveProjectAttachment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@AttachmentID", attachmentId);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion




    }
}
