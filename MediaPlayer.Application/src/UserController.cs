using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Application.src
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public PlayList? AddNewList(string name, int userId)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("name can not be empty");
            else if (userId < 0) throw new ArgumentException("user id is invalid");
            else return _userService.AddNewList(name, userId);
        }

        public bool EmptyOneList(int listId, int userId)
        {
            if (listId <=0 || userId < 0) throw new ArgumentException("invalid id, id can not be negative");
            else return _userService.EmptyOneList(listId, userId);
        }

        public string GetAllList(int userId)
        {
            if (userId < 0) throw new ArgumentException("user id is invalid");
            else return _userService.GetAllList(userId);
        }

        public PlayList? GetListById(int listId, int userId)
        {
            if (listId <=0 || userId < 0) throw new ArgumentException("invalid id, id can not be negative");
            else return _userService.GetListById(listId, userId);
        }

        public bool RemoveAllLists(int userId)
        {
            if (userId < 0) throw new ArgumentException("user id is invalid");
            else return _userService.RemoveAllLists(userId);
        }

        public bool RemoveOneList(int listId, int userId)
        {
            if (userId < 0) throw new ArgumentException("user id is invalid");
            else return _userService.RemoveOneList(listId, userId);
        }
    }
}