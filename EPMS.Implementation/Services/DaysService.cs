using System;
using System.Collections.Generic;
using ES.Interfaces.IServices;
using ES.Interfaces.Repository;
using ES.Models.DomainModels;

namespace ES.Implementation.Services
{
    class DaysService:IDaysService
    {
        private readonly IDaysRepository oRepository;
        public DaysService(IDaysRepository iRepository)
        {
            oRepository = iRepository;
        }
        public IEnumerable<Days> GetDays()
        {
            return oRepository.LoadDays();
        }
        public IEnumerable<Days> GetUnavailableDays()
        {
            return oRepository.LoadUnavailableDays();
        }
        public Days Find(int id)
        {
            return oRepository.Find(id);
        }

        public bool Add(Days oData)
        {
            try
            {
                oRepository.Add(oData);
                oRepository.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(Days oData)
        {
            try
            {
                oRepository.Update(oData);
                oRepository.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
