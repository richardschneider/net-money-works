# net-money-works

[![build status](https://ci.appveyor.com/api/projects/status/github/richardschneider/net-money-works?branch=master&svg=true)](https://ci.appveyor.com/project/richardschneider/net-money-works) 
[![Coverage Status](https://coveralls.io/repos/richardschneider/net-money-works/badge.svg?branch=master&service=github)](https://coveralls.io/github/richardschneider/net-money-works?branch=master)
[![Version](https://img.shields.io/nuget/v/MoneyWorks.svg)](https://www.nuget.org/packages/MoneyWorks)

Work with money in multiple currencies and different cultures.

## Features

- [Banker's rounding](https://en.wikipedia.org/wiki/Rounding) to the precision of the currency 
- Precise [decimal](https://msdn.microsoft.com/en-us/library/system.decimal(v=vs.110).aspx) arithmetic
- [ISO-4217](https://en.wikipedia.org/wiki/ISO_4217) currency codes
- Uses [Martin Folwer's](http://martinfowler.com/) design pattern for [Money](http://martinfowler.com/eaaCatalog/money.html)
- Allocation of funds without loosing pennies (smallest denomination)

## Getting started

Published releases of Money Works are available on [NuGet](https://www.nuget.org/packages/MoneyWorks/).  To install, run the following command in the [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console).

    PM> Install-Package MoneyWorks
