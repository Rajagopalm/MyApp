using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.API.Helpers;
using MyApp.API.Models;

namespace MyApp.API.Data
{
    public interface IMyAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id, bool isCurrentUser);
        Task<Photo> GetPhoto(int id);
        Task<Photo> GetMainPhotoForUser(int userId);
        Task<Like> GetLike(int userId, int recipientId);
        Task<Message> GetMessage(int id);
        Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
        Task<PagedList<Student>> GetStudents(StudentParams studentParams);
        Task<List<District>> GetDistrictsAsync();
        Task<List<SubDistrict>> GetSubDistrictsAsync();
        Task<Student> GetStudent(int id);

    }
}