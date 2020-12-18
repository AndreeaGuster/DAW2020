using lab3_miercuri.Models.MyDatabaseInitializer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace lab3_miercuri.Models.MyValidation
{
    public class CNPValidator : ValidationAttribute
    {
        private bool BeUnique(string cnp)
        {
            DbCtx db = new DbCtx();
            return db.ContactsInfo.FirstOrDefault(ci => ci.CNP == cnp) == null;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ContactInfo contact = (ContactInfo)validationContext.ObjectInstance;

            string cnp = contact.CNP;

            if (cnp == null)
                return new ValidationResult("CNP field is required!");

            Regex regex = new Regex(@"^([1-9]\d+)$");
            if (!regex.IsMatch(cnp))
                return new ValidationResult("CNP must contain only digits!");

            if (cnp.Length != 13)
                return new ValidationResult("CNP must contain 13 digits!");

            if (!BeUnique(cnp))
                return new ValidationResult("CNP must be unique!");

            char s = cnp.ElementAt(0);
            string aa = cnp.Substring(1, 2);
            string ll = cnp.Substring(3, 2);
            string zz = cnp.Substring(5, 2);
            string jj = cnp.Substring(7, 2);
            string nnn = cnp.Substring(9, 3);
            char c = cnp.ElementAt(12);

            switch (s)
            {
                case '1':
                    if (!(contact.GenderType.Equals(Gender.Male) && contact.BirthYear >= 1900 && contact.BirthYear <= 1999))
                        return new ValidationResult("S part is not valid!");
                    break;
                case '2':
                    if (!(contact.GenderType.Equals(Gender.Female) && contact.BirthYear >= 1900 && contact.BirthYear <= 1999))
                        return new ValidationResult("S part is not valid!");
                    break;
                case '3':
                    if (!(contact.GenderType.Equals(Gender.Male) && contact.BirthYear >= 1800 && contact.BirthYear <= 1899))
                        return new ValidationResult("S part is not valid!");
                    break;
                case '4':
                    if (!(contact.GenderType.Equals(Gender.Female) && contact.BirthYear >= 1800 && contact.BirthYear <= 1899))
                        return new ValidationResult("S part is not valid!");
                    break;
                case '5':
                    if (!(contact.GenderType.Equals(Gender.Male) && contact.BirthYear >= 2000 && contact.BirthYear <= 2099))
                        return new ValidationResult("S part is not valid!");
                    break;
                case '6':
                    if (!(contact.GenderType.Equals(Gender.Female) && contact.BirthYear >= 2000 && contact.BirthYear <= 2099))
                        return new ValidationResult("S part is not valid!");
                    break;
                case '7':
                    if (!(contact.GenderType.Equals(Gender.Male) && contact.Resident.Equals(true)))
                        return new ValidationResult("S part is not valid!");
                    break;
                case '8':
                    if (!(contact.GenderType.Equals(Gender.Female) && contact.Resident.Equals(true)))
                        return new ValidationResult("S part is not valid!");
                    break;
                default: return new ValidationResult("S part is not valid!");
            }

            string lastTwoDigits = contact.BirthYear.ToString().Substring(2, 2);
            if (!aa.Equals(lastTwoDigits))
                return new ValidationResult("AA part is not valid!");

            if (!ll.Equals(contact.BirthMonth))
                return new ValidationResult("LL part is not valid!");

            if (!zz.Equals(contact.BirthDay))
                return new ValidationResult("ZZ part is not valid!");

               int regionNo = contact.RegionId;
               string region;

               if (regionNo < 10)
                   region = "0" + regionNo.ToString();
               else
                   region = regionNo.ToString();

              if (!jj.Equals(region))
                   return new ValidationResult("JJ part is not valid!");
           
             regex = new Regex(@"^((00[1-9])|(0[1-9]\d)|([1-9]\d{2}))$");
             if (!regex.IsMatch(nnn))
                 return new ValidationResult("NNN part is not valid!");
           
           // validam componenta C
           int rez = (s - '0') * 2;
           rez += (aa.ElementAt(0) - '0') * 7 + (aa.ElementAt(1) - '0') * 9;
           rez += (ll.ElementAt(0) - '0') * 1 + (ll.ElementAt(1) - '0') * 4;
           rez += (zz.ElementAt(0) - '0') * 6 + (zz.ElementAt(1) - '0') * 3;
           rez += (jj.ElementAt(0) - '0') * 5 + (jj.ElementAt(1) - '0') * 8;
           rez += (nnn.ElementAt(0) - '0') * 2 + (nnn.ElementAt(1) - '0') * 7 + (nnn.ElementAt(2) - '0') * 9;
           rez %= 11;
           if (rez == 10)
           {
               if (!c.Equals('1'))
                   return new ValidationResult("C part is not valid!");
           }
           else
           {
               if ((c - '0') != rez)
                   return new ValidationResult("C part is not valid!");
           }
            return ValidationResult.Success;
        }
    }
}