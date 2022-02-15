using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Ticketing.Entities;

namespace TicketingSystem.Ticketing.Repositories
{
    public class TicketPurchaseRepository : ITicketPurchaseRepository
    {
        public void Add(TicketPurchase entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(TicketPurchase entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public IList<TicketPurchase> Get(Expression<Func<TicketPurchase, bool>> filter, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public (IList<TicketPurchase> data, int total, int totalDisplay) Get(Expression<Func<TicketPurchase, bool>> filter = null, Func<IQueryable<TicketPurchase>, IOrderedQueryable<TicketPurchase>> orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public IList<TicketPurchase> Get(Expression<Func<TicketPurchase, bool>> filter = null, Func<IQueryable<TicketPurchase>, IOrderedQueryable<TicketPurchase>> orderBy = null, string includeProperties = "", bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public IList<TicketPurchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public TicketPurchase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Expression<Func<TicketPurchase, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public (IList<TicketPurchase> data, int total, int totalDisplay) GetDynamic(Expression<Func<TicketPurchase, bool>> filter = null, string orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public IList<TicketPurchase> GetDynamic(Expression<Func<TicketPurchase, bool>> filter = null, string orderBy = null, string includeProperties = "", bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TicketPurchase entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Remove(Expression<Func<TicketPurchase, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
