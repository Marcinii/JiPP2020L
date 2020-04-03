using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace unitconverter.logic
{
    class database
    {
        DisplayDataUsingEF();
        /*
        LOCAL DATABASE
        -----DATABASE STRUCTURE-----

        CREATE TABLE converters(
	        id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	        converter_name VARCHAR(30)
        );

        INSERT INTO converters VALUES 
        ('capacity'),
        ('lenght'),
        ('temperature'),
        ('time'),
        ('weight')

        CREATE TABLE conversions(
	        id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	        converter INT NOT NULL FOREIGN KEY REFERENCES converters(id),
	        units_from TEXT NOT NULL,
	        units_to TEXT NOT NULL,
	        value_from TEXT NOT NULL,
	        value_to TEXT NOT NULL,
	        conversion_date DATETIME DEFAULT GETDATE(),
        );

         -----DATABASE STRUCTURE-----
         */

        public static void DisplayDataUsingEF()
        {
            using (CompanyDataEntities context = new CompanyDataEntities())
        }
    }
}
