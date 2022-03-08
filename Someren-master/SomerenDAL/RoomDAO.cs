using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class RoomDAO : BaseDao
    {
        public List<Room>GetAllRooms()
        {
            // change attributes from Room, give them the right name. 
            string query = "SELECT roomNumber, capacity, type FROM [Room]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room()
                {
                    // studentID en teacherID? 
                    Number = (int)dr["roomNumber"],
                    Capacity = (int)dr["capacity"],
                    Type = (string)dr["type"]
                };
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
