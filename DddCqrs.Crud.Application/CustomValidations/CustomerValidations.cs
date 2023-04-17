namespace DddCqrs.Crud.Application.CustomValidations
{
    using PhoneNumbers;
    using System;
    using System.Net.Mail;

    public interface ICustomerValidations
    {
        bool IsValidPhoneNumber(string phoneNumber);

        bool IsValidMail(string email);

        bool IsValidBankAccount(string bankAccount);
    }

    public class CustomerValidations : ICustomerValidations
    {
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            try
            {
                PhoneNumberUtil validationUtil = PhoneNumberUtil.GetInstance();
                PhoneNumbers.PhoneNumber phone = validationUtil.Parse(phoneNumber.ToString(), "US");

                return validationUtil.IsValidNumber(phone);
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public bool IsValidMail(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        public bool IsValidBankAccount(string bankAccount)
        {
            if (string.IsNullOrEmpty(bankAccount) || bankAccount.Length < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
