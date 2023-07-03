using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Domain.src.RepositoryInterface
{
    public interface IUserRepository
    {
        PlayList? AddNewList(string name, int userId);
        bool RemoveOneList(int listId, int userId);
        bool RemoveAllLists(int userId);
        bool EmptyOneList(int listId, int userId);
        string GetAllList(int userId);
        PlayList? GetListById(int listId, int userId);
    }
}