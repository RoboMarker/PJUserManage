using UserManageRepository.Models.Data;

namespace UserManageRepository.Interface
{
    public interface IUserRepositoryEnity
    {
        Task<IList<User>> GetUser();
    }
}
