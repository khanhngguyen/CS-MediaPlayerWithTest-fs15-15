using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Business.src.ServiceInterface
{
    public interface IUserService
    {
        PlayList? AddNewList(string name, int userId);
        bool RemoveOneList(int listId, int userId);
        bool RemoveAllLists(int userId);
        bool EmptyOneList(int listId, int userId);
        string GetAllList(int userId);
        PlayList? GetListById(int listId, int userId);
    }
}