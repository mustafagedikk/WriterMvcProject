using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddMessage(Message message)
        {
            _messageDal.Insert(message);
        }

        public void DeleteMessage(Message message)
        {
            _messageDal.Update(message);
        }

        public int GetByCountGarbageMessage(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.Status == false || x.SenderMail == p && x.Status == false).OrderByDescending(x => x.MessageDate).ToList().Count();
        }

        public int GetByCountReceiverMessage(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.Status == true).Count();
        }

        public int GetByCountSenderMessage(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.Status == true).Count();
        }

        public int GetByCountTaskMessage(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.TaskStatus == true).Count();
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListByTask(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.TaskStatus == true).OrderByDescending(x=>x.MessageDate).ToList();
        }

        public List<Message> GetListGarbage(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.Status==false || x.SenderMail == p && x.Status == false).OrderByDescending(x => x.MessageDate).ToList();
        }

        public List<Message> GetListInbox( string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.Status==true).OrderByDescending(x => x.MessageDate).ToList();
        }

        public List<Message> GetListInboxSearch(string p, string search)
        {
            return _messageDal
                .List(x=>x.ReceiverMail==p && x.Status==true && x.MessageContent.Contains(search))
                .ToList();
        }
        public List<Message> GetListSendBox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.Status == true && x.TaskStatus==false).OrderByDescending(x => x.MessageDate).ToList();
        }

        public List<Message> GetListSendboxSearch(string p, string search)
        {
            return _messageDal
               .List(x => x.SenderMail == p && x.Status == true && x.MessageContent.Contains(search))
               .ToList();
        }

        public void UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
