using System.Collections.Generic;
using System.Linq;

namespace FinalProject
{
    public class FleetLogic : BaseLogic
    {
        public FleetModel GetOneCar(int id)
        {
            return GetFleetCar()
                .Where(c => c.carID == id)
                .SingleOrDefault();
        }

        public List<FleetModel> GetEntireFleet()
        {
            return GetFleetCar()
                .ToList();
        }

        public FleetModel AddNewCar(FleetModel car)
        {
            Fleet newCar = new Fleet
            {
                LicensePlate = car.licensePlate,
                ModelID = car.modelID
            };
            DB.Fleets.Add(newCar);
            DB.SaveChanges();
            return GetOneCar(newCar.CarID);
        }

        private IQueryable<FleetModel> GetFleetCar()
        {
            return DB.Fleets
                .Select(c => new FleetModel
                {
                    carID = c.CarID,
                    licensePlate = c.LicensePlate,
                    model = DB.Models
                        .Where(mo => mo.ModelID == c.ModelID)
                        .Select(mo => new ModelModel
                        {
                            id = mo.ModelID,
                            modelName = mo.ModelName,
                            dailyPrice = mo.DailyPrice,
                            picture = mo.Picture,
                            maker = DB.Makers
                                .Where(ma => ma.MakerID == mo.MakerID)
                                .Select(ma => new MakerModel
                                {
                                    id = ma.MakerID,
                                    makerName = ma.MakerName
                                }).FirstOrDefault()
                        }).FirstOrDefault()
                }).AsQueryable();
        }
    }
}
