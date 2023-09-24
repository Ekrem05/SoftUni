Select CountryName as 'Country Name', IsoCode as 'ISO Code'
from Countries
WHERE dataLENGTH(CountryName) - dataLENGTH(REPLACE(LOWER(CountryName), 'a', '')) >= 3
ORDER BY IsoCode