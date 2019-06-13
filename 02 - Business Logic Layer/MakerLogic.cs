using System.Linq;

namespace FinalProject
{
    public class MakerLogic : BaseLogic
    {
        public MakerModel GetOneMaker(int id)
        {
            return DB.Makers
                .Where(m => m.MakerID == id)
                .Select(m => new MakerModel
                {
                    id = m.MakerID,
                    makerName = m.MakerName
                }).SingleOrDefault();
        }

        public MakerModel AddNewMaker(MakerModel maker)
        {
            Maker newMaker = new Maker
            {
                MakerName = maker.makerName
            };
            DB.Makers.Add(newMaker);
            DB.SaveChanges();
            return GetOneMaker(newMaker.MakerID);
        }
    }
}
