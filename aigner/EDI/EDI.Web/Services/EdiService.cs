using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EDI.DataAccess;
using EDI.DataAccess.Entities;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Templates.EdifactD96A;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EDI.Web.Services
{
    public class EdiService
    {
        public IServiceProvider ServiceProvider { get; }
        public ApplicationDbContext dbContext { get; }
        private static ILog log = LogManager.GetLogger(typeof(EdiService));
        public EdiService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            dbContext = ServiceProvider.GetService<ApplicationDbContext>();
        }

        public async Task AddEdi(IEdiMasterMessage ediMasterMessage)
        {
            if (ediMasterMessage.GetType() == typeof(EdiOrder))
            {
                await dbContext.EdiOrder.AddAsync((EdiOrder)ediMasterMessage);
            }
            else if (ediMasterMessage.GetType() == typeof(EdiInvoice))
            {
                await dbContext.EdiInvoice.AddAsync((EdiInvoice)ediMasterMessage);
            }
            //else if (ediMasterMessage.GetType() == typeof(EdiOrderChange))
            //{
            //    await dbContext.EdiOrderChange.AddAsync((EdiOrderChange)ediMasterMessage);
            //}
            else if (ediMasterMessage.GetType() == typeof(EdiScheduleAgreement))
            {
                await dbContext.EdiScheduleAgreement.AddAsync((EdiScheduleAgreement)ediMasterMessage);
            }
            else if (ediMasterMessage.GetType() == typeof(EdiOrderConfirmation))
            {
                await dbContext.EdiOrderConfirmation.AddAsync((EdiOrderConfirmation)ediMasterMessage);
            }
            else if (ediMasterMessage.GetType() == typeof(EdiDeliveryNote))
            {
                await dbContext.EdiDeliveryNote.AddAsync((EdiDeliveryNote)ediMasterMessage);
            }

            await dbContext.SaveChangesAsync();
        }

        #region Get each Edi

        public async Task<EdiOrder> GetOrder(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiOrder.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync()
                            : await dbContext.EdiOrder.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.Status == status);
            return order;
        }
        public async Task<EdiOrderConfirmation> GetOrderComfirmation(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiOrderConfirmation.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync()
                            : await dbContext.EdiOrderConfirmation.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.Status == status);
            return order;
        }
        public async Task<EdiScheduleAgreement> GetOrderSchedule(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiScheduleAgreement.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync()
                            : await dbContext.EdiScheduleAgreement.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.Status == status);
            return order;
        }
        public async Task<EdiInvoice> GetInvoice(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiInvoice.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync()
                            : await dbContext.EdiInvoice.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.Status == status);
            return order;
        }
        public async Task<EdiDeliveryNote> GetDeliveryNote(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiDeliveryNote.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync()
                : await dbContext.EdiDeliveryNote.Include(x => x.LineItems).OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.Status == status);
            return order;
        }

        #endregion

        #region Get Edi list

        public async Task<List<EdiOrder>> GetOrderList(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiOrder.Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync()
                            : await dbContext.EdiOrder.Where(x => x.Status == status).Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync();
            return order;
        }
        public async Task<List<EdiOrderConfirmation>> GetOrderComfirmationList(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiOrderConfirmation.Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync()
                            : await dbContext.EdiOrderConfirmation.Where(x => x.Status == status).Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync();
            return order;
        }
        public async Task<List<EdiScheduleAgreement>> GetOrderScheduleList(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiScheduleAgreement.Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync()
                            : await dbContext.EdiScheduleAgreement.Where(x => x.Status == status).Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync();
            return order;
        }
        public async Task<List<EdiInvoice>> GetInvoiceList(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiInvoice.Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync()
                            : await dbContext.EdiInvoice.Where(x => x.Status == status).Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync();
            return order;
        }
        public async Task<List<EdiDeliveryNote>> GetDeliveryNoteList(MessageStatus? status = null)
        {
            var order = status == null ? await dbContext.EdiDeliveryNote.Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync()
                : await dbContext.EdiDeliveryNote.Where(x => x.Status == status).Include(x => x.LineItems).OrderByDescending(x => x.Id).ToListAsync();
            return order;
        }


        #endregion

        public async Task ChangeEdiStatus<TEntity>(int id, MessageStatus beforeStaus, MessageStatus afterStatus) where TEntity : class, IEdiMasterMessage
        {
            var entity = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Status == beforeStaus && id == x.Id);
            //if (entities.Any())
            //{
            //    log.Info($"Change status: {beforeStaus.ToString()} to staus: {afterStatus} ids:[ {string.Join(',', entities.Select(x => x.Id))}]");
            //    entities.ForEach(x => x.Status = afterStatus);
            //    await dbContext.SaveChangesAsync();
            //}
            if (entity != null)
            {
                log.Info($"Change status: {beforeStaus.ToString()} to staus: {afterStatus} id: {id }");
                entity.Status = afterStatus;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                log.Error($"Cannot find  id: {id } to change status: {beforeStaus.ToString()} to staus: {afterStatus} ");
            }

        }

        public async Task LogErrorEdiMessage<TEntity>(int id, Exception e) where TEntity : class, IEdiMasterMessage
        {
            var entity = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => id == x.Id);
            if (entity != null)
            {
                if (e.GetType() == typeof(ValidateException))
                {
                    entity.SendValidationError =  e.Message;
                }
                else
                {
                    entity.SendErrorCount =  entity.SendErrorCount + 1;
                    entity.SendErrorMessage = e.Message;
                }

                await dbContext.SaveChangesAsync();
            }
            else
            {
                log.Error($"Cannot find  id: {id} to log error SendErrorCount, SendErrorMessage and SendValidationError ");
            }

            
        }
        public async Task ClearErrorEdiMessage<TEntity>(int id) where TEntity : class, IEdiMasterMessage
        {
            var entity = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => id == x.Id);
            if (entity != null)
            {
                entity.SendValidationError = null;
                entity.SendErrorCount = 0;
                entity.SendErrorMessage = null;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                log.Error($"Cannot find  id: {id} to clear error SendErrorCount, SendErrorMessage and SendValidationError ");
            }


        }
        public async Task ClearValidateEdiMessage<TEntity>(int id) where TEntity : class, IEdiMasterMessage
        {
            var entity = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => id == x.Id);
            if (entity != null)
            {
                entity.SendValidationError = null;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                log.Error($"Cannot find  id: {id} to clear error SendErrorCount, SendErrorMessage and SendValidationError ");
            }


        }

        //public List<TEntity> GetEdiFromStatus<TEntity>(DbSet<TEntity> dbSet, MessageStatus status) where TEntity : EdiMasterMessage<TEntity>
        //{
        //    var entities = dbSet.AsNoTracking().Where(x => x.Status == status).ToList();

        //    return entities;
        //}

    }
}
