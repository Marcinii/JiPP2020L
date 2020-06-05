using FlowerManager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerManager.Logic
{
    public class FlowerControler : ITableControler
    {
        public void AddRecord(string name, int frequency, int roomid)
        {
            Flower flower = new Flower()
            {
                Name = name,
                RoomID = roomid,
                LastWatered = System.DateTime.Now,
                WateredFrequency = frequency
            };
            AddRecord(flower);
        }

        public void AddRecord(IRow row)
        {
            using (FlowerManagerEntities context = new FlowerManagerEntities())
            {
                context.Flower.Add((Flower)row);
                context.SaveChanges();
            }
        }

        public List<IRow> GetRecords()
        {
            List<Flower> flowers;
            using (FlowerManagerEntities context = new FlowerManagerEntities())
            {

                flowers = context.Flower.OrderBy(f => f.LastWatered).ToList();
            }
            return flowers.Cast<IRow>().ToList();
        }

        public List<Flower> GetDyingFlowers()
        {
            List<Flower> flowers = GetRecords().Cast<Flower>().ToList();
            return flowers.FindAll(f => isDead(f));
        }

        public void UpdateRecord(int id)
        {
            using (FlowerManagerEntities context = new FlowerManagerEntities())
            {
                Flower flower = context.Flower.Where(f => f.ID == id).ToList().First();
                flower.LastWatered = System.DateTime.Now;
                context.SaveChanges();
            }
        }

        public IRow GetRecord(int id)
        {
            throw new NotImplementedException();
        }

        public bool isDead(Flower flower)
        {
            return (System.DateTime.Now - flower.LastWatered).Days >= flower.WateredFrequency;
        }


    }
}
