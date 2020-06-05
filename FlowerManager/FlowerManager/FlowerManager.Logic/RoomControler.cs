using FlowerManager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerManager.Logic
{
    public class RoomControler : ITableControler
    {
        public void AddRecord(string name)
        {
            Room room = new Room()
            {
                Name = name
            };
            AddRecord(room);
        }

        public void AddRecord(IRow row)
        {
            using (FlowerManagerEntities context = new FlowerManagerEntities())
            {
                context.Room.Add((Room)row);
                context.SaveChanges();
            }
        }

        public void UpdateRecord(int id)
        {
            throw new NotImplementedException();
        }

        public IRow GetRecord(int id)
        {
            throw new NotImplementedException();
        }

        public List<IRow> GetRecords()
        {
            throw new NotImplementedException();
        }

        public int GetID(string name)
        {
            int id = 0;
            using (FlowerManagerEntities context = new FlowerManagerEntities())
            {
                id = context.Room.Where(r => r.Name == name).ToList().First().ID;
            }
            return id;
        }
    }
}
