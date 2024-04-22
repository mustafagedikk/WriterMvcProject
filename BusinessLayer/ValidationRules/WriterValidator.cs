using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public  class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyadını boş geçemezisimiz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezisimiz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezisimiz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen 3 en az üç karakter girişi yapın");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın");

          
        }


    }
}
