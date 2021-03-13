using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.Dto;

namespace SeturAssessment.ContactService.Business.Concrete
{
    public class LocationManager:ILocationManager
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IContactLocationRepository _contactLocationRepository;

        public LocationManager(ILocationRepository locationRepository, IContactLocationRepository contactLocationRepository)
        {
            _locationRepository = locationRepository;
            _contactLocationRepository = contactLocationRepository;
        }

        public IList<ContactLocation> GetAll()
        {
            return _contactLocationRepository.GetAll("Location").ToList();
        }

        public ContactLocation Get(Guid contactId)
        {
            return _contactLocationRepository.Get(q=>q.ContactId==contactId, "Location");
        }

        public void Add(ContactLocationDto location)
        {
            var locationHaveBefore = LocationNameExist(location.LocationName,out var locationId);
            if (locationHaveBefore)
            {
                _contactLocationRepository.Add(new ContactLocation(){ContactId = location.ContactId, LocationId = locationId});
            }
            else
            {
                //Transaction 
                var newLocation = new Location() {LocationName = location.LocationName};
                _locationRepository.Add(newLocation);
                _contactLocationRepository.Add(new ContactLocation() { ContactId = location.ContactId, LocationId = newLocation.Id });

            }

        }

        public void Update(int id, ContactLocationDto location)
        {
            var entitiy = _contactLocationRepository.Get(q => q.Id == id);
            var locationHaveBefore = LocationNameExist(location.LocationName, out var locationId);
            if (locationHaveBefore)
            {
                entitiy.LocationId = locationId;
                _contactLocationRepository.Update(entitiy,entitiy.Id);
            }
            else
            {
                //Transaction 
                var newLocation = new Location() { LocationName = location.LocationName };
                _locationRepository.Add(newLocation);
                entitiy.LocationId = newLocation.Id;
                _contactLocationRepository.Update(entitiy, entitiy.Id);
            }
        }


        public void Delete(ContactLocation contactLocation)
        {
            _contactLocationRepository.Delete(contactLocation,contactLocation.LocationId);
        }



        //İş Kodu
        private Boolean LocationNameExist(string locationName, out int locationId)
        {
           var result =  _locationRepository.Get(q => q.LocationName.Trim().ToLower() == locationName.Trim().ToLower());
           if (result==null)
           {
               locationId = 0;
               return false;
           }

           locationId = result.Id;
           return true;
        }
    }
}
