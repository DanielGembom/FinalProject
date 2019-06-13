using System.Linq;

namespace FinalProject
{
    public class ModelLogic : BaseLogic
    {
        public ModelModel GetOneModel(int id)
        {
            return DB.Models
                .Where(m => m.ModelID == id)
                .Select(m => new ModelModel
                {
                    id = m.ModelID,
                    maker = new MakerModel { id = m.MakerID },
                    modelName = m.ModelName,
                    dailyPrice = m.DailyPrice,
                    picture = m.Picture
                }).SingleOrDefault();
        }

        public ModelModel AddNewModel(ModelModel model)
        {
            Model newModel = new Model
            {
                MakerID = model.makerID,
                ModelName = model.modelName,
                DailyPrice = model.dailyPrice,
                Picture = model.picture
            };
            DB.Models.Add(newModel);
            DB.SaveChanges();
            return GetOneModel(newModel.ModelID);
        }
    }
}
