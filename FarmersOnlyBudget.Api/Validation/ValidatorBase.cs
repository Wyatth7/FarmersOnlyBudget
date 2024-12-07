using FluentValidation;

namespace FarmersOnlyBudget.Api.Validation;

public class ValidatorBase<TType> : AbstractValidator<TType> { }