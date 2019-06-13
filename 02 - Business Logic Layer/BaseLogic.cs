using System;

namespace FinalProject
{
    public class BaseLogic : IDisposable
    {
        protected CarRentalEntities DB = new CarRentalEntities();
        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
