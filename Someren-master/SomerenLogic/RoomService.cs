using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class RoomService
    {
        RoomDAO studentdb;

        public RoomService()
        {
            studentdb = new RoomDAO();
        }

        public List<Room> GetRooms()
        {
            List<Room> rooms = studentdb.GetAllRooms();
            return rooms;
        }
    }
}
