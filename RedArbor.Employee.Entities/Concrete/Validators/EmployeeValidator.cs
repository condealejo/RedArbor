using FluentValidation;
using RedArbor.Employee.Entities.Abstract;

namespace RedArbor.Employee.Entities.Concrete.Validators
{
    public class EmployeeValidator : AbstractValidatorBase<Employee.Employee>
    {
        /// <summary>
        /// Validación de campos básicos. 
        /// </summary>
        public EmployeeValidator() 
        {
            RuleFor(x => x.CompanyID).GreaterThan(0).WithMessage(MessageValidatorResource.Rule001);
            RuleFor(x => x.Email).EmailAddress().WithMessage(MessageValidatorResource.Rule002);
            RuleFor(x => x.UserName).NotEmpty().WithMessage(MessageValidatorResource.Rule003);
            RuleFor(x => x.PortalID).GreaterThan(0).WithMessage(MessageValidatorResource.Rule004);
            RuleFor(x => x.RoleID).GreaterThan(0).WithMessage(MessageValidatorResource.Rule005);
            RuleFor(x => x.StatusID).GreaterThan(0).WithMessage(MessageValidatorResource.Rule006);
            RuleFor(x => x.Password).Length(10,100).WithMessage(MessageValidatorResource.Rule007);
        }
    }
}
