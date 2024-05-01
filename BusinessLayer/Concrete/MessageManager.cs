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
            throw new NotImplementedException();
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox( string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetListSendBox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
