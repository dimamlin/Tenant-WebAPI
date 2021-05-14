using FluentValidation;
using TestTask.Data.Models;

namespace TestTask.Data.Validators
{
    public class TenantValidator : AbstractValidator<Tenant>
	{
		public TenantValidator()
		{
			RuleFor(x => x.Id).NotNull().NotEmpty();
			RuleFor(x => x.FirstName).NotNull().NotEmpty();
			RuleFor(x => x.LastName).NotNull().NotEmpty();
			RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Must(IsPhoneValid).Length(13);
		}

		private bool IsPhoneValid(string phone)
		{
			return phone.StartsWith("+375");
		}
	}
}
