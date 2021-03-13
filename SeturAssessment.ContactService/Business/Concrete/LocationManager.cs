using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.Dto;
using SeturAssessment.ContactService.Utilities.Results;

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

        public IDataResult<IList<ContactLocation>> GetAll()
        {
            var query = _contactLocationRepository.GetAll("Location").ToList();
            return new SuccessDataResult<List<ContactLocation>>(query, "Lokasyonlar Adresleri Başarıyla Alındı");

        }

        public IDataResult<ContactLocation> Get(Guid contactId)
        {
            var query =  _contactLocationRepository.Get(q=>q.ContactId==contactId, "Location");
            return new SuccessDataResult<ContactLocation>(query, "Lokasyon Adresleri Başarıyla Alındı");

        }

        public IResult Add(ContactLocationAddDto location)
        {
            var result = LocationIsAddedContactBefore(location.LocationName, location.ContactId);
            if (!result.IsSuccess)
            {
                return result;
            }

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
            return new SuccessResult("Lokasyon Başarıyla Kaydedildi.");

        }

        public IResult Update(ContactLocationDto contactLocation)
        {
            var entitiy = _contactLocationRepository.Get(q => q.Id == contactLocation.ContactLocationId);
            var result = LocationIsAddedContactBefore(contactLocation.LocationName, entitiy.ContactId);
            if (!result.IsSuccess)
            {
                return result;
            }
            var locationHaveBefore = LocationNameExist(contactLocation.LocationName, out var locationId);
            if (locationHaveBefore)
            {
                entitiy.LocationId = locationId;
                _contactLocationRepository.Update(entitiy,entitiy.Id);
            }
            else
            {
                //Transaction 
                var newLocation = new Location() { LocationName = contactLocation.LocationName };
                _locationRepository.Add(newLocation);
                entitiy.LocationId = newLocation.Id;
                _contactLocationRepository.Update(entitiy, entitiy.Id);
            }
            return new SuccessResult("Lokasyon Başarıyla Güncellendi.");

        }


        public IResult Delete(ContactLocation contactLocation)
        {
            _contactLocationRepository.Delete(contactLocation,contactLocation.Id);
            return new SuccessResult("Lokasyon Başarıyla Silindi.");

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

        private IResult LocationIsAddedContactBefore(string locationName,Guid contactId)
        {

            var location = _locationRepository.Get(q => q.LocationName.Trim().ToLower() == locationName.Trim().ToLower());
            if (location !=  null)
            {
                var result = _contactLocationRepository.GetAll().Any(q => q.ContactId == contactId && q.LocationId == location.Id);
                if (result)
                {
                    return new ErrorResult("Bu Lokasyon Bu Kullanıcıya daha önce Eklenmiş");
                }

                return new SuccessResult();
            }

            return new SuccessResult();
        }
    }
}
