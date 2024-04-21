using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public  class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş geçemezisimiz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen 3 en az üç karakter girişi yapın");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın");

            ///Olmayan bir validasyon yazmak için
            //RuleFor(p => p.CategoryName).Must(StartWithA).WithMessage("Kategori İsmi 'A' ile başlamalı");
        }

            //public bool StartWithA(string arg)
            //{
            //    return arg.StartsWith("A");
            //}
        

    }
}
