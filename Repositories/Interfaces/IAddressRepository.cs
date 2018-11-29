using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IAddressRepository
    {
        //Create
        Address Add(Address address);

        //Read
        List<Address> GetAddress(Guid userId);

        //Update
        Address Update(Guid userId, Address address);    

        //Delete
        bool Delete(Guid id);
    }
}
