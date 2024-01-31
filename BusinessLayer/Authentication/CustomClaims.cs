using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authentication
{
    public class CustomClaims
    {
        private readonly AppUser _user;
        private Claim? Age;

        public CustomClaims(AppUser user)
        {
            _user = user;
        }

        public Claim GetAge()
        {
            if (Age == null)
            {
                SetAge();
            }

            return Age;
        }
        private void SetAge()
        {
            if (_user.Birthdate == null)
            {
                Age = new Claim("Age", "Unspecified");

                return;
            }

            int age = CalculateAgeValue(
                _user.Birthdate.GetValueOrDefault());

            Age = new Claim("Age", age.ToString());
        }
        private int CalculateAgeValue(DateTime birthdate)
        {
			DateTime now = DateTime.Now;
			int age = now.Year - birthdate.Year;

            // is it a full year
			if (now.Month < birthdate.Month)
			{
				age = age - 1;
			}
			else if (now.Month == birthdate.Month)
			{
				if (now.Day < birthdate.Day)
				{
					age = age - 1;
				}
			}

            return age;
		}
    }
}
