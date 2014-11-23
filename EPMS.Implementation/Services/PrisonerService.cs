using System;
using System.Collections.Generic;
using System.Linq;
using EPMS.Interfaces.IServices;
using EPMS.Interfaces.Repository;
using EPMS.Models.DomainModels;
using EPMS.Models.ModelMapers;
using EPMS.Models.RequestModels;
using EPMS.Models.ResponseModels;

namespace EPMS.Implementation.Services
{
    public class PrisonerService : IPrisonerService
    {
        //private readonly IPrisonerRepository iRepository;

        //public PrisonerService(IPrisonerRepository xRepository)
        //{
        //    iRepository = xRepository;
        //}

        ////private bool IfExists(Prisoner paramData)
        ////{
        ////    Prisoner oDbVersion = iRepository.CheckByCnic(paramData);
        ////    return oDbVersion != null;
        ////}
        //public IEnumerable<Prisoner> LoadAll()
        //{
        //    return iRepository.GetAllPrisoners();
        //}

        //public Prisoner Find(int id)
        //{
        //    return iRepository.Find(id);
        //}

        //public bool Add(Prisoner oData)
        //{
        //    try
        //    {
        //        iRepository.Add(oData);
        //        iRepository.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //    return false;
        //}

        //public bool Update(Prisoner oData)
        //{
        //    try
        //    {
        //        iRepository.Update(oData);
        //        iRepository.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //    return false;
        //}
        //public void Delete(Prisoner oData)
        //{
        //    iRepository.Delete(oData);
        //    iRepository.SaveChanges();
        //}
        
        #region Private

        private readonly IPrisonerRepository prisonerRepository;
        private void UpdatePrisonerAttachment(Prisoner prisoner)
        {
            if (prisoner.Attachments != null && prisoner.Attachments.Any())
            {
                prisoner.Attachments.LastOrDefault().FileName = prisoner.PrisonerId + "-" +
                                                                prisoner.Attachments.LastOrDefault().FileName;
                prisonerRepository.Update(prisoner);
                prisonerRepository.SaveChanges();
            }
        }
        #endregion

        #region Constructor

        public PrisonerService(IPrisonerRepository prisonerRepository)
        {
            this.prisonerRepository = prisonerRepository;
        }

        #endregion

        #region Public
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prisoner"></param>
        /// <returns></returns>
        public bool AddPrisoner(Prisoner prisoner)
        {
            prisonerRepository.Add(prisoner);
            prisonerRepository.SaveChanges();
            UpdatePrisonerAttachment(prisoner);
            //Update Attachment
            return true;
        }

        public PrisonerResponse GetAllPrisoners(PrisonerSearchRequest prisonerSearchRequest)
        {
            return prisonerRepository.GetAllPrisoners(prisonerSearchRequest);
        }

        public Prisoner FindPrisonerById(int? id)
        {
            if (id != null) return prisonerRepository.FindPrisonerById((int)id);
            return null;

        }

        public IEnumerable<Prisoner> GetAllPrisoners()
        {
            return prisonerRepository.GetAllPrisoners();
        }

        public IEnumerable<Prisoner> GetAllDetainedPrisoners(DateTime from, DateTime to)
        {
            from = SetStTime(from);
            to = SetEndTime(to);
            return prisonerRepository.GetAllDetainedPrisoners(from, to);
        }

        public IEnumerable<Prisoner> GetAllReleasedPrisoners(DateTime from, DateTime to)
        {
            return prisonerRepository.GetAllReleasedPrisoners(from, to);
        }

        public bool UpdatePrisoner(Prisoner prisoner)
        {
            var prisonerToupdate = FindPrisonerById(prisoner.PrisonerId);
            if (prisonerToupdate != null)
            {
                prisoner.UpdateTo(prisonerToupdate);
                prisonerRepository.Update(prisonerToupdate);
                prisonerRepository.SaveChanges();
                return true;
            }
            return false;
        }

        

        public void DeletePrisoner(Prisoner prisoner)
        {
            prisonerRepository.Delete(prisoner);
            prisonerRepository.SaveChanges();
        }
        
        #endregion

        private DateTime SetStTime(DateTime dt)
        {
            dt= new DateTime(dt.Year,dt.Month,dt.Day,0,0,0);
            return dt;
        }

        private DateTime SetEndTime(DateTime dt)
        {
            dt = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            return dt;
        }

        public IEnumerable<Prisoner> LoadAllPrisoners()
        {
            return prisonerRepository.GetAll();
            
        } 
    }
}
