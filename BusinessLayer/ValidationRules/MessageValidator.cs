using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public  class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Gönderen Mail Adresini Boş Geçemezsiniz.").EmailAddress().WithMessage("Geçerli bir e-posta giriniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemmezsiniz.").MinimumLength(30).WithMessage("En Az 30 Karakter giriniz"); 
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen 3 en az üç karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 3 en az üç karakter girişi yapın");
        }
     
    }
}
