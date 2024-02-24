using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class AddressService
    {
        private readonly AddressRepository _addressrepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressrepository = addressRepository;
        }



        public AddressEntity CreateAddress(string streetName, string postalCode, string city)
        {
            var addressEntity = _addressrepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            addressEntity ??= _addressrepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city});
            return addressEntity;
        }

        public AddressEntity GetAddressByStreetName(string streetName, string postalCode, string city)
        {
            var addressEntity = _addressrepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return addressEntity;
        }

        public AddressEntity GetAddressById(int id)
        {
            var addressEntity = _addressrepository.Get(x => x.Id == id);
            return addressEntity;
        }

        public IEnumerable<AddressEntity> GetAddresses()
        {
            var addresses = _addressrepository.GetAll();
            return addresses;
        }

        public AddressEntity UpdateAddress(AddressEntity addressEntity)
        {
            var updatedAddressEntity = _addressrepository.Update(x => x.Id == addressEntity.Id, addressEntity);
            return updatedAddressEntity;
        }

        public void DeleteAddress(int id)
        {
            _addressrepository.Delete(x => x.Id == id);
        }
    }
}
