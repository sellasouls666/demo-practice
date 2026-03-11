using DemoLib.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Pickup
{
    public class PickupService
    {
        private IPickupRepository repository_;
        public PickupService(IPickupRepository repository)
        {
            repository_ = repository;
        }

        public string GetPickupAddress(int idPickup)
        {
            return repository_.GetPickupAddress(idPickup);
        }
    }
}
